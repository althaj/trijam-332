using UnityEngine;

public class Character : MonoBehaviour
{
    public enum Activity
    {
        None,
        CollectingWood,
        Hunting,
        Ambushing,
        Defending,
        Sacrificed
    }

    [SerializeField] private string title;
    [SerializeField][TextArea(2, 5)] private string bio;
    [SerializeField][TextArea(2, 5)] private string abilityText;
    [SerializeField] private Sprite portrait;
    [SerializeField] int monthlyPay = 1;

    public string GetTitle() => title;
    public string GetBio() => bio;
    public string GetAbilityText() => abilityText;
    public Sprite GetPortrait() => portrait;
    public int GetMonthlyPay() => monthlyPay;

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

    public virtual void Hunt()
    {
        ResourceManager resourceManager = FindFirstObjectByType<ResourceManager>();
        if (resourceManager == null)
        {
            return;
        }

        resourceManager.ChangeFood(Random.Range(1, 2));

        CurrentActivity = Activity.Hunting;
    }

    public virtual void Ambush()
    {
        ResourceManager resourceManager = FindFirstObjectByType<ResourceManager>();
        if (resourceManager == null)
        {
            return;
        }

        resourceManager.ChangeMoney(Random.Range(1, 4));

        CurrentActivity = Activity.Ambushing;
    }

    public virtual void Defend()
    {
        ResourceManager resourceManager = FindFirstObjectByType<ResourceManager>();
        if (resourceManager == null)
        {
            return;
        }

        CurrentActivity = Activity.Defending;
    }
}
