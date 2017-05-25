using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class IconDemo : MonoBehaviour {
    public string iconsPath = "/Resources/Icons";
    public ReadDemo questionsFile;
    public PanelIconTest panel;
    public Text[] answers;

    private Dictionary<string, Sprite> icons = new Dictionary<string, Sprite>();

	// Use this for initialization
	void Start () {
        Sprite[] sprites = Resources.LoadAll<Sprite>(iconsPath);
        foreach (Sprite s in sprites)
        {
            icons.Add(s.name, s);
        }

        int r = Random.Range(0, 4);
        string line = questionsFile.lines[0, r];
        string[] words = Regex.Split(line, @"\W+");
        List<Sprite> images = new List<Sprite>();
        foreach(string word in words)
        {
            if (icons.ContainsKey(word))
                images.Add(icons[word]);
            else
                images.Add(null);
        }

        panel.Init(words, images.ToArray());
        answers[0].text = ArabicSupport.ArabicFixer.Fix(questionsFile.lines[1, r]);
        for (int i = 1; i < answers.Length; i++)
        {
            int r2 = Random.Range(0, questionsFile.lines.GetLength(1)-1);
            while (r2 == r)
            {
                r2 = Random.Range(0, questionsFile.lines.GetLength(1)-1);
            }
            answers[i].text = ArabicSupport.ArabicFixer.Fix(questionsFile.lines[1, r2]);
        }
        //icons = IconMatcher.GetIcons(iconsPath);
	}


}
