using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance;

    private Dictionary<int, StoryNode> storyDict;
    private int currentId;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        storyDict = StoryLoader.LoadStory("story.json");

        StartStory(1);
    }

    public void StartStory(int startId)
    {
        currentId = startId;
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
        currentId = nextId;

        SaveManager.Save(currentId); // 如果已經有 SaveManager

        ShowNode();
    }
}