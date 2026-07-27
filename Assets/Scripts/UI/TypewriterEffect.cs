using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private Text targetText;
    [SerializeField] private float interval = 0.03f;

    private Coroutine typingCoroutine;
    private string fullText;

    public bool IsTyping { get; private set; }

    public Action OnTypingComplete;

    public void Play(string content)
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        fullText = content;
        typingCoroutine = StartCoroutine(TypeRoutine());
    }

    IEnumerator TypeRoutine()
    {
        IsTyping = true;

        targetText.text = "";

        foreach (char c in fullText)
        {
            targetText.text += c;
            yield return new WaitForSeconds(interval);
        }

        IsTyping = false;

        OnTypingComplete?.Invoke();
    }

    public void Skip()
    {
        if (!IsTyping)
            return;

        StopCoroutine(typingCoroutine);

        targetText.text = fullText;

        IsTyping = false;

        OnTypingComplete?.Invoke();
    }
}