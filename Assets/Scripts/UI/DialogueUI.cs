using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public Text speakerText;
    public Text contentText;
    public Button nextButton;

    private StoryNode currentNode;

    private void Start()
    {
        nextButton.onClick.AddListener(OnNext);
    }

    public void Show(StoryNode node)
    {
        gameObject.SetActive(true);

        currentNode = node;

        speakerText.text = node.speaker;
        contentText.text = node.content;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnNext()
    {
        if (currentNode.nextId > 0)
        {
            StoryManager.Instance.GoTo(currentNode.nextId);
        }
    }
}
