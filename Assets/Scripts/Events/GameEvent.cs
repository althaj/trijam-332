using UnityEngine;
using UnityEngine.Events;

public class GameEvent : MonoBehaviour
{
    [SerializeField] protected string title;
    [SerializeField] [TextArea(2, 5)] protected string description;
    [SerializeField] protected string[] buttonNames;
    [SerializeField] protected UnityEvent[] buttonActions;

    public virtual bool IsExecutable() => true;

    public virtual string GetTitle() => title;
    public virtual string GetDescription() => description;
    public virtual string[] GetButtonNames() => buttonNames;
    public virtual void ButtonClicked(int index)
    {
        if (buttonActions[index] != null)
        {
            buttonActions[index].Invoke();
        }
    }
}
