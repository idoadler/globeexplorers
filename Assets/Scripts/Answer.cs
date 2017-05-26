using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Answer : MonoBehaviour
{
    public bool isCorrectAnswer;
    public Text answer;
    public GameObject solution;

    public void Init(string text) 
    {
        GetComponent<Button>().interactable = true;
        answer.text = ArabicSupport.ArabicFixer.Fix(text);
        solution.SetActive(false);
    }

    public void Hide()
    {
        GetComponent<Button>().interactable = false;
    }

    public void Reveal()
    {
        solution.SetActive(true);
    }
}
