using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;

public class UITextFixer : MonoBehaviour
{
    public bool tashkeel = true;
    public bool hinduNumbers = true;

    // Use this for initialization
    void Start()
    {
        Text text = gameObject.GetComponent<Text>();
        text.text = ArabicFixer.Fix(text.text, tashkeel, hinduNumbers);
    }
}
