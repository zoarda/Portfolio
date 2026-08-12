using UnityEngine;

public class EndingUI : MonoBehaviour
{
    public void Replay()
    {
        gameObject.SetActive(false);

        StoryManager.Instance.ReplayStory();
    }

    public void BackToMainMenu()
    {
        gameObject.SetActive(false);

        UIManager.Instance.ShowMainMenu();
    }
}
