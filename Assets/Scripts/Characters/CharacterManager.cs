using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private List<Character> characters = new List<Character>();

    [SerializeField] private CharacterPanel characterPanel;

    [SerializeField] private TextMeshProUGUI monthText;
    [SerializeField] private EventManager eventManager;
    [SerializeField] private ResourceManager resourceManager;

    private int currentCharacterIndex = 0;

    public List<Character> Characters { get => characters; }

    private int currentMonth = 1;

    private int famine = 0;

    void Start()
    {
        if (characterPanel == null)
        {
            return;
        }

        characterPanel.Initialize(this, characters);
        SelectCharacter(0);
    }

    public void SelectCharacter(int index)
    {
        currentCharacterIndex = index;
        // TODO: Fix index out of bounds.
        Character currentCharacter = characters[currentCharacterIndex];
        if (currentCharacter == null || characterPanel == null)
        {
            return;
        }
        characterPanel.SelectCharacter(currentCharacter);
    }

    public void CollectWood()
    {
        if (resourceManager == null)
        {
            return;
        }

        // TODO: Fix index out of bounds.
        Character currentCharacter = characters[currentCharacterIndex];
        if (currentCharacter == null)
        {
            return;
        }

        if (currentCharacter.CurrentActivity != Character.Activity.None)
        {
            return;
        }

        if (resourceManager.GetMoney() < currentCharacter.GetMonthlyPay() + famine)
        {
            return;
        }

        currentCharacter.CollectWood();
        resourceManager.ChangeMoney(-currentCharacter.GetMonthlyPay() - famine);
        // Update UI
        SelectCharacter(currentCharacterIndex);
    }

    public void Hunt()
    {
        if (resourceManager == null)
        {
            return;
        }

        // TODO: Fix index out of bounds.
        Character currentCharacter = characters[currentCharacterIndex];
        if (currentCharacter == null)
        {
            return;
        }

        if (currentCharacter.CurrentActivity != Character.Activity.None)
        {
            return;
        }

        if (resourceManager.GetMoney() < currentCharacter.GetMonthlyPay() + famine)
        {
            return;
        }

        currentCharacter.Hunt();
        resourceManager.ChangeMoney(-currentCharacter.GetMonthlyPay() - famine);
        // Update UI
        SelectCharacter(currentCharacterIndex);
    }

    public void Ambush()
    {
        if (resourceManager == null)
        {
            return;
        }

        // TODO: Fix index out of bounds.
        Character currentCharacter = characters[currentCharacterIndex];
        if (currentCharacter == null)
        {
            return;
        }

        if (currentCharacter.CurrentActivity != Character.Activity.None)
        {
            return;
        }

        if (resourceManager.GetMoney() < currentCharacter.GetMonthlyPay() + famine)
        {
            return;
        }

        currentCharacter.Ambush();
        resourceManager.ChangeMoney(-currentCharacter.GetMonthlyPay() - famine);
        // Update UI
        SelectCharacter(currentCharacterIndex);
    }

    public void Defend()
    {
        if (resourceManager == null)
        {
            return;
        }

        // TODO: Fix index out of bounds.
        Character currentCharacter = characters[currentCharacterIndex];
        if (currentCharacter == null)
        {
            return;
        }

        if (currentCharacter.CurrentActivity != Character.Activity.None)
        {
            return;
        }

        if (resourceManager.GetMoney() < currentCharacter.GetMonthlyPay() + famine)
        {
            return;
        }

        currentCharacter.Defend();
        resourceManager.ChangeMoney(-currentCharacter.GetMonthlyPay() - famine);
        // Update UI
        SelectCharacter(currentCharacterIndex);
    }

    public void Construct()
    {
        if (resourceManager == null)
        {
            return;
        }

        // TODO: Fix index out of bounds.
        Character currentCharacter = characters[currentCharacterIndex];
        if (currentCharacter == null)
        {
            return;
        }

        if (currentCharacter.CurrentActivity != Character.Activity.None)
        {
            return;
        }

        if (resourceManager.GetMoney() < currentCharacter.GetMonthlyPay() + famine + 5)
        {
            return;
        }

        if (resourceManager.GetResources() < 10)
        {
            return;
        }

        if (eventManager != null)
        {
            eventManager.ShowWinEvent();
            resourceManager.ChangeMoney(-currentCharacter.GetMonthlyPay() - famine - 5);
            resourceManager.ChangeResources(-10);
        }

        // Update UI
        SelectCharacter(currentCharacterIndex);
    }

    public void EndCurrentMonth()
    {
        currentMonth++;
        if (currentMonth > 12)
        {
            if (eventManager != null)
            {
                eventManager.ShowLossEvent();
                return;
            }
        }

        if (monthText != null)
        {
            monthText.text = new DateTime(2025, currentMonth, 1).ToString("MMMM");
        }

        if (resourceManager != null)
        {
            if (resourceManager.GetFood() == 0)
            {
                if (eventManager != null)
                {
                    eventManager.ShowFamineEvent();
                    famine = 1;
                }
            }
            else
            {
                resourceManager.ChangeFood(-1);
                famine = 0;
            }
        }

        if (famine == 0 && eventManager != null)
        {
            eventManager.ShowRandomEvent();
        }

        foreach (Character character in characters)
        {
            if (character != null && character.CurrentActivity != Character.Activity.Sacrificed)
            {
                character.CurrentActivity = Character.Activity.None;
            }
        }

        SelectCharacter(currentCharacterIndex);
    }

    public void Sacrifice(Character character)
    {
        int index = characters.IndexOf(character);
        characters[index].CurrentActivity = Character.Activity.Sacrificed;
        SelectCharacter(currentCharacterIndex);
    }
}
