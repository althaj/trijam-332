using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] private RectTransform characterListPanel;
    [SerializeField] private Image portraitImage;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI bioText;
    [SerializeField] private TextMeshProUGUI abilityText;
    [SerializeField] private RectTransform buttonsPanel;

    [SerializeField] private CharacterButton characterButtonPrefab;

    public void Initialize(CharacterManager characterManager, List<Character> characters)
    {
        if (characterListPanel == null || characterButtonPrefab == null)
        {
            return;
        }

        for (int i = 0; i < characters.Count; i++)
        {
            CharacterButton button = Instantiate(characterButtonPrefab, characterListPanel);
            if (button == null)
            {
                continue;
            }

            button.Initialize(characters[i].GetTitle(), characters[i].GetPortrait(), i);
            button.OnClicked.AddListener((int index) => characterManager?.SelectCharacter(index));
        }
    }

    public void SelectCharacter(Character character)
    {
        if (character == null)
        {
            return;
        }

        if (portraitImage != null)
        {
            portraitImage.sprite = character.GetPortrait();
        }

        if (titleText != null)
        {
            titleText.text = character.GetTitle();
        }

        if (bioText != null)
        {
            bioText.text = character.GetBio();
        }

        if (abilityText != null)
        {
            abilityText.text = character.GetAbilityText();
        }

        if (buttonsPanel != null)
        {
            buttonsPanel.gameObject.SetActive(character.CurrentActivity == Character.Activity.None);
        }
    }
}
