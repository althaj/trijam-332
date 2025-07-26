using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EventPanel : MonoBehaviour
{
    [SerializeField] private RectTransform background;
    [SerializeField] private RectTransform panel;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private RectTransform buttonsPanel;
    [SerializeField] private EventButton buttonPrefab;
    [SerializeField] private string closeButtonText;

    public EventButton[] EventButtons { get; private set; } = new EventButton[0];

    public UnityEvent<int> OnButtonClicked;

    void Start()
    {
        ClosePanel();       
    }

    public void OpenPanel(string eventTitle, string eventDescription, string[] buttonNames)
    {
        if (background != null)
        {
            background.gameObject.SetActive(true);
        }

        if (panel != null)
        {
            panel.gameObject.SetActive(true);
        }

        if (titleText != null)
        {
            titleText.text = eventTitle;
        }

        if (eventDescription != null)
        {
            descriptionText.text = eventDescription;
        }

        RemoveCurrentButtons();
        CreateNewButtons(buttonNames);
    }

    private void CreateNewButtons(string[] buttonNames)
    {
        if (buttonsPanel == null)
        {
            return;
        }

        EventButtons = new EventButton[buttonNames.Length + 1];

        for (int i = 0; i < buttonNames.Length; i++)
        {
            EventButtons[i] = Instantiate(buttonPrefab, buttonsPanel);
            if (EventButtons[i] != null)
            {
                EventButtons[i].SetText(buttonNames[i]);
                EventButtons[i].OnClicked.AddListener(() => OnButtonClicked?.Invoke(i));
            }
        }

        EventButtons[EventButtons.Length - 1] = Instantiate(buttonPrefab, buttonsPanel);
        EventButtons[EventButtons.Length - 1].SetText(closeButtonText);
        EventButtons[EventButtons.Length - 1].OnClicked.AddListener(ClosePanel);
    }

    private void RemoveCurrentButtons()
    {
        for (int i = 0; i < EventButtons.Length; i++)
        {
            if (EventButtons[i] == null)
            {
                continue;
            }

            EventButtons[i].OnClicked.RemoveAllListeners();
            Destroy(EventButtons[i].gameObject);
        }
    }

    public void ClosePanel()
    {
        if (background != null)
        {
            background.gameObject.SetActive(false);
        }

        if (panel != null)
        {
            panel.gameObject.SetActive(false);
        }
    }
}
