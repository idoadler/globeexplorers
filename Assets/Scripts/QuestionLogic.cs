using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class QuestionLogic : MonoBehaviour
{
    private const int QUESTION = 0;
    private const int ANSWER = 1;

    public string iconsPath = "Icons";
    public PanelIconTest panel;
    public Answer[] answers;
    public TextAsset[] csv;
    public Puzzle puzzle;
    public Button fiftyFiftyButton;

    private Dictionary<string, string[,]> lines = new Dictionary<string, string[,]>();
    public bool debug = false;
    private Dictionary<string, Sprite> icons = new Dictionary<string, Sprite>();

    void Awake()
    {
        foreach (TextAsset t in csv)
        {
            lines.Add(t.name, CSVReader.SplitCsvGrid(t.text));
        }
    }

    // Use this for initialization
    void Start()
    {
        if (debug)
            SetQuestion(0);
    }

    public void SetQuestion(int teamNumber)
    {
        fiftyFiftyButton.gameObject.SetActive(true);
        string subject = StaticData.teamIcons[teamNumber].name;
        icons = new Dictionary<string, Sprite>();

        Sprite[] sprites = Resources.LoadAll<Sprite>(iconsPath);
        foreach (Sprite s in sprites)
        {
            icons.Add(s.name, s);
        }

        int length = lines[subject].GetLength(1) - 1;
        int r = Random.Range(0, length);
        string line = lines[subject][QUESTION, r];
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

        panel.Clear();

        panel.Init(words, images.ToArray());
        answers[0].Init(lines[subject][ANSWER, r]);
        for (int i = 1; i < answers.Length; i++)
        {
            // TODO: check against all previous answers, not just the correct one
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

        UpdateNavigation();
    }

    private void UpdateNavigation()
    {
        //fix button navigation & focus
        Transform answerParent = answers[0].transform.parent;
        Button[] answerButtons = new Button[answerParent.childCount];

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i] = answerParent.GetChild(i).GetComponent<Button>();
        }

        Navigation newNavigation = new Navigation();
        newNavigation.mode = Navigation.Mode.Explicit;
        Button first = null;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (answerButtons[i].interactable)
            {
                if (first == null)
                {
                    first = answerButtons[i];
                }

                bool haveNext = false;
                for (int j = i + 1; j < answerButtons.Length; j++)
                {
                    if (answerButtons[j].interactable)
                    {
                        haveNext = true;
                        newNavigation.selectOnRight = answerButtons[j];
                        break;
                    }
                }
                if (!haveNext)
                {
                    if (fiftyFiftyButton.gameObject.activeSelf)
                    {
                        newNavigation.selectOnRight = fiftyFiftyButton;
                    }
                    else
                    {
                        newNavigation.selectOnRight = first;
                    }
                }

                answerButtons[i].navigation = newNavigation;
            }
        }

        if (fiftyFiftyButton.gameObject.activeSelf)
        {
            newNavigation.selectOnRight = first;
            fiftyFiftyButton.navigation = newNavigation;
        }
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(first.gameObject);
    }

    public void TryAnswer(Answer answer)
    {
        puzzle.UpdateBoard(answer.isCorrectAnswer);
        StaticData.currentUIManager.SwitchPanel(2);
    }

    public void HalfAnswers()
    {
        int keep = Random.Range(1, answers.Length);
        for (int i = 1; i < answers.Length; i++)
        {
            if (i != keep)
            {
                answers[i].Hide();
            }
        }
        fiftyFiftyButton.gameObject.SetActive(false);
        UpdateNavigation();
    }
}
