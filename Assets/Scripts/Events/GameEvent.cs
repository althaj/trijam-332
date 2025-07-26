using UnityEngine;
using UnityEngine.Events;

public class GameEvent : MonoBehaviour
{
    [SerializeField] private string title;
    [SerializeField] [TextArea(2, 5)] private string description;
    [SerializeField] private string[] buttonNames;
    [SerializeField] private UnityEvent[] buttonActions;

    public virtual bool IsExecutable() => true;

    public string GetTitle() => title;
    public string GetDescription() => description;
    public string[] GetButtonNames() => buttonNames;
    public void ButtonClicked(int index)
    {
        if (buttonActions[index] != null)
        {
            buttonActions[index].Invoke();
        }
    }
}
