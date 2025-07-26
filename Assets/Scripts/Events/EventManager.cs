using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    [SerializeField] private EventPanel eventPanel;
    [SerializeField] private GameEvent startEvent;
    [SerializeField] private GameEvent winEvent;
    [SerializeField] private GameEvent lossEvent;
    [SerializeField] private GameEvent famineEvent;
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

        eventPanel.OnButtonClicked.RemoveAllListeners();

        eventPanel.OpenPanel(currentEvent.GetTitle(), currentEvent.GetDescription(), currentEvent.GetButtonNames());
        eventPanel.OnButtonClicked.AddListener(currentEvent.ButtonClicked);
    }

    public void ShowRandomEvent()
    {
        if (Random.Range(0, 3) != 0)
        {
            return;
        }

        GameEvent[] availableEvents = randomEvents.Where(e => e.IsExecutable()).ToArray();
        if (availableEvents.Length == 0)
        {
            return;
        }

        ShowEvent(availableEvents[Random.Range(0, availableEvents.Length)]);
    }

    internal void ShowWinEvent()
    {
        ShowEvent(winEvent);
    }

    internal void ShowLossEvent()
    {
        ShowEvent(lossEvent);
    }

    internal void ShowFamineEvent()
    {
        ShowEvent(famineEvent);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
