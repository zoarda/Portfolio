using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
[Header("Main UI")]
    public MainMenuUI mainMenuUI;

    [Header("Story UI")]
    public DialogueUI dialogueUI;
    public ChoiceUI choiceUI;

    [Header("Ending UI")]
    public EndingUI endingUI;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowMainMenu()
    {
        mainMenuUI.gameObject.SetActive(true);

        dialogueUI.gameObject.SetActive(false);
        choiceUI.gameObject.SetActive(false);
        endingUI.gameObject.SetActive(false);
    }

    public void ShowDialogue(StoryNode node)
    {
        mainMenuUI.gameObject.SetActive(false);
        choiceUI.gameObject.SetActive(false);
        endingUI.gameObject.SetActive(false);

        dialogueUI.Show(node);
    }

    public void ShowChoices(System.Collections.Generic.List<ChoiceOption> options)
    {
        mainMenuUI.gameObject.SetActive(false);
        dialogueUI.gameObject.SetActive(false);
        endingUI.gameObject.SetActive(false);

        choiceUI.Show(options);
    }

    public void ShowEnding()
    {
        mainMenuUI.gameObject.SetActive(false);
        dialogueUI.gameObject.SetActive(false);
        choiceUI.gameObject.SetActive(false);

        endingUI.gameObject.SetActive(true);
    }
}
