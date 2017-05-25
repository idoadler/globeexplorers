using UnityEngine;
using UnityEngine.UI;

public static class StaticData
{

    public static Sprite[] teamIcons;
    public static Sprite[] iconPool;

    public static int currentTeam = 0;

    public static Selectable lastSelected;

    public static void Init()
    {
        iconPool = Resources.LoadAll<Sprite>("TeamIcons/");
        teamIcons = new Sprite[2];
        ChangeTeamIcon(0, 0);
        ChangeTeamIcon(1, 1);
    }

    public static void ChangeTeamIcon(int team, int icon)
    {
        teamIcons[team] = iconPool[icon];
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
