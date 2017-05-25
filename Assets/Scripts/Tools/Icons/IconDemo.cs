using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class IconDemo : MonoBehaviour {
    public string iconsPath = "/Resources/Icons";
    public ReadDemo questionsFile;
    public PanelIconTest panel;

    private Dictionary<string, Sprite> icons = new Dictionary<string, Sprite>();

	// Use this for initialization
	void Start () {
        Debug.Log("1: " + Resources.LoadAll("Icons").Length);
        Debug.Log("2: " + Resources.LoadAll("Resources/Icons").Length);
        Sprite[] sprites = Resources.LoadAll<Sprite>(iconsPath);
        Debug.Log("SPRITES: " + iconsPath + sprites.Length);
        foreach (Sprite s in sprites)
        {
            Debug.Log(s.name);
            icons.Add(s.name, s);
        }

        string line = questionsFile.lines[0, Random.Range(0,4)];
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
        //icons = IconMatcher.GetIcons(iconsPath);
	}


}
