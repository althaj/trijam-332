using UnityEngine;

public class Character : MonoBehaviour
{
    public enum Activity
    {
        None,
        CollectingWood
    }

    [SerializeField] private string title;
    [SerializeField][TextArea(2, 5)] private string bio;
    [SerializeField][TextArea(2, 5)] private string abilityText;
    [SerializeField] private Sprite portrait;

    public string GetTitle() => title;
    public string GetBio() => bio;
    public string GetAbilityText() => abilityText;
    public Sprite GetPortrait() => portrait;

    public Activity CurrentActivity = Activity.None;

    public virtual void CollectWood()
    {
        ResourceManager resourceManager = FindFirstObjectByType<ResourceManager>();
        if (resourceManager == null)
        {
            return;
        }

        resourceManager.ChangeResources(1);

        CurrentActivity = Activity.CollectingWood;
    }
}
