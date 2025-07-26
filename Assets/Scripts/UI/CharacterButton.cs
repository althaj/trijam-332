using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CharacterButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private Image portraitImage;

    private int characterIndex;

    public int GetCharacterIndex() => characterIndex;

    public UnityEvent<int> OnClicked;

    public void Initialize(string title, Sprite portrait, int index)
    {
        characterIndex = index;

        if (titleText != null)
        {
            titleText.text = title;
        }

        if (portraitImage != null)
        {
            portraitImage.sprite = portrait;
        }

        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => OnClicked?.Invoke(characterIndex));
        }
    }
}
