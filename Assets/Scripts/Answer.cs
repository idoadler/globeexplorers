using System;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public bool isCorrectAnswer;
    public Text answer;

    public void Init(string text)
    {
        GetComponent<Button>().interactable = true;
        answer.text = ArabicSupport.ArabicFixer.Fix(text);
    }

    internal void Hide()
    {
        GetComponent<Button>().interactable = false;
    }
}
