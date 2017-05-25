using UnityEngine;

public static class StaticData
{

    public static Sprite[] teamIcons;
    public static Sprite[] iconPool;

    public static int currentTeam = 0;

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
