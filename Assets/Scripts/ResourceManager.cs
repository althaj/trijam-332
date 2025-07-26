using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private int startingResources;
    [SerializeField] private int startingFood;
    [SerializeField] private int startingMoney;

    [SerializeField] private TextMeshProUGUI resourcesText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI moneyText;

    private int resources;
    private int food;
    private int money;

    public int GetResources() => resources;
    public int GetFood() => food;
    public int GetMoney() => money;

    public void ChangeResources(int amount)
    {
        resources += Mathf.Max(amount, 0);
        if (resourcesText != null)
        {
            resourcesText.text = $"Resources: {resources}";
        }
    }

    public void ChangeFood(int amount)
    {
        food += Mathf.Max(amount, 0);
        if (foodText != null)
        {
            foodText.text = $"Food: {food}";
        }
    }

    public void ChangeMoney(int amount)
    {
        money += Mathf.Max(amount, 0);
        if (moneyText != null)
        {
            moneyText.text = $"Money: {money}";
        }
    }
}
