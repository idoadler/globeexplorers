using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class QuestionLogic : MonoBehaviour {
    private const int QUESTION = 0;
    private const int ANSWER = 1;

    public string iconsPath = "Icons";
    public PanelIconTest panel;
    public Answer[] answers;
    public TextAsset[] csv;
    private List<string[,]> lines = new List<string[,]>();
    public int group1 = 0;
    public int group2 = 0;
    public bool debug = false;

    private Dictionary<string, Sprite> icons = new Dictionary<string, Sprite>();

    void Awake()
    {
        foreach (TextAsset t in csv)
        {
            lines.Add(CSVReader.SplitCsvGrid(t.text));
        }
    }

    // Use this for initialization
    void Start() {
        group1 = Random.Range(0, csv.Length);
        group2 = Random.Range(0, csv.Length);
        if (debug)
            SetQuestion(true);
    }

    public void SetQuestion(bool isGroup1)
    {
        int subject = group1;
        if (!isGroup1)
            subject = group2;

        Sprite[] sprites = Resources.LoadAll<Sprite>(iconsPath);
        foreach (Sprite s in sprites)
        {
            icons.Add(s.name, s);
        }

        int length = lines[subject].GetLength(1) - 1;
        int r = Random.Range(0, length);
        string line = lines[subject][QUESTION, r];
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
        answers[0].Init(lines[subject][ANSWER, r]);
        for (int i = 1; i < answers.Length; i++)
        {
            int r2 = Random.Range(0, length);
            while (r2 == r)
            {
                r2 = Random.Range(0, length);
            }
            answers[i].Init(lines[subject][ANSWER, r2]);
        }

        // randomize location
        int randomLoc = Random.Range(0, answers.Length);
        answers[0].transform.SetSiblingIndex(randomLoc);

        //fix button navigation & focus
        Transform answerParent = answers[0].transform.parent;
        Button[] answerButtons = new Button[answerParent.childCount];

        for (int i = 0; i < answerButtons.Length;  i++)
        {
            answerButtons[i] = answerParent.GetChild(i).GetComponent<Button>();
        }
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Navigation newNavigation = new Navigation();
            newNavigation.mode = Navigation.Mode.Explicit;

            if (i < answerButtons.Length - 1)
            {
                newNavigation.selectOnRight = answerButtons[i + 1];
            }
            else
            {
                newNavigation.selectOnRight = answerButtons[0];
            }
        }

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(answerButtons[0].gameObject);
    }


}
