using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class EventButton : MonoBehaviour
{
    public UnityEvent<int> OnClicked;

    private int buttonIndex;

    public void SetText(string text)
    {
        Button button = GetComponent<Button>();
        if (button == null)
        {
            return;
        }

        TextMeshProUGUI textMesh = button.GetComponentInChildren<TextMeshProUGUI>();
        if (textMesh == null)
        {
            return;
        }

        textMesh.text = text;
    }

    public void SetButtonIndex(int index)
    {
        buttonIndex = index;
    }

    void OnEnable()
    {
        Button button = GetComponent<Button>();
        if (button == null)
        {
            return;
        }

        button.onClick.AddListener(OnButtonClick);
    }

    void OnDisable()
    {
        Button button = GetComponent<Button>();
        if (button == null)
        {
            return;
        }

        button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        OnClicked?.Invoke(buttonIndex);
    }
}
