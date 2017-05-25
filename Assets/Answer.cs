using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour {
    public Text answer;

    public void Init(string text)
    {
        answer.text = ArabicSupport.ArabicFixer.Fix(text);
    }
}
