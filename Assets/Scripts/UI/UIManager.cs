using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public DialogueUI dialogueUI;
    public ChoiceUI choiceUI;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialogue(StoryNode node)
    {
        choiceUI.Hide();
        dialogueUI.Show(node);
    }

    public void ShowChoices(List<ChoiceOption> options)
    {
        dialogueUI.Hide();
        choiceUI.Show(options);
    }
}
