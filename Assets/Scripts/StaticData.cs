using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class StaticData
{
    public static Sprite[] teamIcons;
    public static Dictionary<string, Sprite> subjects;

    public static int currentTeam = 0;

    private static Sprite[] _subjectIcons;
    private static string[] _subjectStrings;
    private const string _subjectIconPath = "SubjectIcons/";
    private const string _textAssetPath = "Questions/";

    public static void Init()
    {
        //load subject icons
        _subjectIcons = Resources.LoadAll<Sprite>(_subjectIconPath);
        
        //load subject strings
        TextAsset[] textAssets = Resources.LoadAll<TextAsset>(_textAssetPath);
        _subjectStrings = new string[textAssets.Length];
        for (int i = 0; i < _subjectStrings.Length; i++)
        {
            _subjectStrings[i] = textAssets[i].name;
        }

        //link both to dictionary
        subjects = new Dictionary<string, Sprite>();

        for (int i = 0; i < _subjectStrings.Length; i++)
        {
            for (int j = 0; j < _subjectIcons.Length; j++)
            {
                if (_subjectStrings[i] == _subjectIcons[j].name)
                {
                    subjects.Add(_subjectStrings[i], _subjectIcons[j]);
                }
            }
        }

        //set team subjects to initial values
        teamIcons = new Sprite[2];
        ChangeTeamSubject(0, _subjectStrings[0]);
        ChangeTeamSubject(1, _subjectStrings[1]);
    }

    public static void ChangeTeamSubject(int team, string subject)
    {
        teamIcons[team] = subjects[subject];
    }
}

public struct Point
{
    public int X;
    public int Y;
    public static implicit operator Vector2(Point p)
    {
        return new Vector2(p.X, p.Y);
    }
}
