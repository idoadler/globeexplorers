using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{

    public static Sprite[] teamIcons;

    public static void Init()
    {
        teamIcons = new Sprite[2];
    }
}
