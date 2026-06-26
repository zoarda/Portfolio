using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChoiceUI : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform container;

    public void Show(List<ChoiceOption> options)
    {
        gameObject.SetActive(true);

        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        foreach (var option in options)
        {
            GameObject btnObj = Instantiate(buttonPrefab, container);
            Text txt = btnObj.GetComponentInChildren<Text>();
            txt.text = option.text;

            Button btn = btnObj.GetComponent<Button>();
            int nextId = option.nextId;

            btn.onClick.AddListener(() =>
            {
                StoryManager.Instance.GoTo(nextId);
            });
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
