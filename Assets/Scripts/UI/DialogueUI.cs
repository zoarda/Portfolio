using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public Text speakerText;
    public Text contentText;
    public Button nextButton;
    public TypewriterEffect typewriter;

    private StoryNode currentNode;

    private void Start()
    {
        nextButton.onClick.AddListener(OnNext);

        typewriter.OnTypingComplete += OnTypingComplete;
    }

    public void Show(StoryNode node)
    {
        gameObject.SetActive(true);

        currentNode = node;

        speakerText.text = node.speaker;

        typewriter.Play(node.content);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnNext()
    {
        Debug.Log($"typewriter = {typewriter}");
        Debug.Log($"currentNode = {currentNode}");
        Debug.Log($"StoryManager = {StoryManager.Instance}");

        if (typewriter == null)
        {
            Debug.LogError("typewriter is NULL");
            return;
        }

        if (currentNode == null)
        {
            Debug.LogError("currentNode is NULL");
            return;
        }

        if (StoryManager.Instance == null)
        {
            Debug.LogError("StoryManager.Instance is NULL");
            return;
        }

        Debug.Log($"nextId = {currentNode.nextId}");

        if (typewriter.IsTyping)
        {
            typewriter.Skip();
            return;
        }

        if (currentNode.nextId < 0)
        {
            Debug.Log("Story End");
            UIManager.Instance.ShowEnding();
            return;
        }
        StoryManager.Instance.GoTo(currentNode.nextId);
    }
    private void OnTypingComplete()
    {
        Debug.Log("Typing Finish");
    }
}
