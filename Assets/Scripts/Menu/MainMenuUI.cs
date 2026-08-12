using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Story List")]
    [SerializeField] private Transform storyList;

    [Header("Story Button")]
    [SerializeField] private Button storyButtonPrefab;

    private void Start()
    {
        LoadStoryList();
    }

    private void LoadStoryList()
    {
       StoryList data = StoryLoader.LoadStoryList();
        if (data != null && data.stories != null)
        {
            CreateStoryButtons(data.stories);
        }
        else
        {
            Debug.LogError("[MainMenuUI] Failed to load story list.");
        }
    }

    private void CreateStoryButtons(
        System.Collections.Generic.List<StoryInfo> stories)
    {
        foreach (StoryInfo story in stories)
        {
            Button button = Instantiate(
                storyButtonPrefab,
                storyList
            );

            button.GetComponentInChildren<Text>().text = story.title;

            button.onClick.AddListener(() =>
            {
                StartStory(story.fileName);
            });
        }
    }

    private void StartStory(string fileName)
    {
        StoryManager.Instance.StartStory(fileName);
    }
}