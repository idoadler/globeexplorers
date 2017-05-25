using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellExample : MonoBehaviour {
    public Image img;
    public Text txt;

    public void Init(string text, Sprite sprite)
    {
        txt.text = ArabicSupport.ArabicFixer.Fix(text);
        img.sprite = sprite;
    }
}
