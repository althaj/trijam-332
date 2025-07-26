using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SacrificeEvent : GameEvent
{
    [SerializeField][TextArea(2, 5)] private string descriptionNoResources;
    [SerializeField] private string[] buttonNamesNoResources;
    [SerializeField] private UnityEvent[] buttonActionsNoResources;

    [SerializeField] private Character.Activity activity;
    [SerializeField] private int resourceCost;
    [SerializeField] private int foodCost;
    [SerializeField] private int moneyCost;

    private Character character;

    public override bool IsExecutable()
    {
        CharacterManager characterManager = FindFirstObjectByType<CharacterManager>();
        if (characterManager == null)
        {
            return false;
        }

        character = characterManager.Characters.FirstOrDefault(ch => ch.CurrentActivity == activity);
        return character != null;
    }

    private bool HasResources()
    {
        ResourceManager resourceManager = FindFirstObjectByType<ResourceManager>();
        if (resourceManager == null)
        {
            return false;
        }

        if (resourceManager.GetResources() < resourceCost || resourceManager.GetFood() < foodCost || resourceManager.GetMoney() < moneyCost)
        {
            return false;
        }

        return true;
    }

    public override string GetDescription() => HasResources() ? description.Replace("{characterTitle}", character?.GetTitle()) : descriptionNoResources.Replace("{characterTitle}", character?.GetTitle());
    public override string[] GetButtonNames() => HasResources() ? buttonNames : buttonNamesNoResources;
    public override void ButtonClicked(int index)
    {
        if (HasResources() && buttonActions[index] != null)
        {
            buttonActions[index].Invoke();
        }
        else if (buttonActionsNoResources[index] != null)
        {
            buttonActionsNoResources[index].Invoke();
        }
    }

    public void Sacrifice()
    {
        CharacterManager characterManager = FindFirstObjectByType<CharacterManager>();
        if (characterManager == null || character == null)
        {
            return;
        }

        characterManager.Sacrifice(character);
    }

    public void Heal()
    {
        ResourceManager resourceManager = FindFirstObjectByType<ResourceManager>();
        if (resourceManager == null)
        {
            return;
        }

        resourceManager.ChangeResources(-resourceCost);
        resourceManager.ChangeFood(-foodCost);
        resourceManager.ChangeMoney(-moneyCost);
    }
}
