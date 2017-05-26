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

        int r = Random.Range(0, 20);
        string line = questionsFile.lines[0, r];
        string[] words = Regex.Split(line, @"\s+");
        List<Sprite> images = new List<Sprite>();
        foreach(string word in words)
        {
            string cleanWord = Regex.Replace(word, @"\W", "");
            if (icons.ContainsKey(cleanWord))
                images.Add(icons[cleanWord]);
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
