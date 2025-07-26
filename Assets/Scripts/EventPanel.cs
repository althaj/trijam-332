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

    private EventButton[] eventButtons;

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

        eventButtons = new EventButton[buttonNames.Length + 1];

        for (int i = 0; i < buttonNames.Length; i++)
        {
            eventButtons[i] = Instantiate(buttonPrefab, buttonsPanel);
            if (eventButtons[i] != null)
            {
                eventButtons[i].SetText(buttonNames[i]);
                eventButtons[eventButtons.Length - 1].OnClicked.AddListener(() => OnButtonClicked?.Invoke(i));
            }
        }

        eventButtons[eventButtons.Length - 1] = Instantiate(buttonPrefab, buttonsPanel);
        eventButtons[eventButtons.Length - 1].SetText(closeButtonText);
        eventButtons[eventButtons.Length - 1].OnClicked.AddListener(ClosePanel);
    }

    private void RemoveCurrentButtons()
    {
        for (int i = 0; i < eventButtons.Length; i++)
        {
            if (eventButtons[i] == null)
            {
                continue;
            }

            eventButtons[i].OnClicked.RemoveAllListeners();
            Destroy(eventButtons[i].gameObject);
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
