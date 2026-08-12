using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance;

    private Dictionary<int, StoryNode> storyDict;
    private int currentId;
    private string currentStoryFile;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }

    public void StartStory(string fileName)
    {
        currentStoryFile = fileName;

        storyDict = StoryLoader.LoadStory(fileName);

        currentId = 1;

        ShowNode();
    }

    public void ShowNode()
    {
        if (!storyDict.TryGetValue(currentId, out StoryNode node))
        {
            Debug.LogError($"Story Node Not Found : {currentId}");
            return;
        }

        Debug.Log(
            $"[Story] ID:{node.id} " +
            $"Type:{node.type} " +
            $"Speaker:{node.speaker} " +
            $"Content:{node.content}"
        );

        switch (node.type)
        {
            case "narration":
            case "dialogue":
                UIManager.Instance.ShowDialogue(node);
                break;

            case "choice":
                UIManager.Instance.ShowChoices(node.options);
                break;
        }
    }

    public void GoTo(int nextId)
    {
        if (nextId <= 0)
        {
            UIManager.Instance.ShowEnding();
            return;
        }

        currentId = nextId;

        SaveManager.Save(currentId);

        ShowNode();
    }
    public void ReplayStory()
    {
        if (string.IsNullOrEmpty(currentStoryFile))
        {
            Debug.LogError("No story has been played.");
            return;
        }

        StartStory(currentStoryFile);
    }
}