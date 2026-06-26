using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        StoryManager.Instance.StartStory(1);
    }
}
