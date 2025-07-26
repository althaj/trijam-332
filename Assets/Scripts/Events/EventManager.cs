using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private EventPanel eventPanel;
    [SerializeField] private GameEvent startEvent;
    [SerializeField] private GameEvent[] randomEvents;

    void Start()
    {
        ShowEvent(startEvent);
    }

    public void ShowEvent(GameEvent currentEvent)
    {
        if (eventPanel == null || currentEvent == null)
        {
            return;
        }

        eventPanel.OpenPanel(currentEvent.GetTitle(), currentEvent.GetDescription(), currentEvent.GetButtonNames());
        for (int i = 0; i < eventPanel.EventButtons.Length; i++)
        {
            eventPanel.OnButtonClicked.AddListener(currentEvent.ButtonClicked);
        }
    }
}
