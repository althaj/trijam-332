using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BarbarianRaid : GameEvent
{
    [SerializeField][TextArea(2, 5)] private string descriptionNoDefense;

    private Character character;

    public override string GetDescription() => character != null ? description.Replace("{characterTitle}", character?.GetTitle()) : descriptionNoDefense.Replace("{characterTitle}", character?.GetTitle());

    public override bool IsExecutable()
    {
        CharacterManager characterManager = FindFirstObjectByType<CharacterManager>();
        if (characterManager == null)
        {
            return false;
        }

        character = characterManager.Characters.FirstOrDefault(ch => ch.CurrentActivity == Character.Activity.Defending);
        return true;
    }

    public void Close()
    {
        if (character != null)
        {
            return;
        }

        ResourceManager resourceManager = FindFirstObjectByType<ResourceManager>();
        if (resourceManager == null)
        {
            return;
        }

        resourceManager.ChangeResources(-Random.Range(0, 4));
        resourceManager.ChangeFood(-Random.Range(0, 4));
        resourceManager.ChangeMoney(-Random.Range(0, 4));
    }
}
