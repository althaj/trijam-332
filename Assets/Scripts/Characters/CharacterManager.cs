using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private Character[] characters = new Character[0];

    [SerializeField] private CharacterPanel characterPanel;
    private int currentCharacterIndex = 0;

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

        currentCharacter.CollectWood();
    }
}
