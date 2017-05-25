using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject[] panels;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        StaticData.Init();
        StaticData.teamIcons[0] = Resources.LoadAll<Sprite>("TeamIcons/")[0];
        StaticData.teamIcons[1] = Resources.LoadAll<Sprite>("TeamIcons/")[1];
    }

    public void ChangeTeamIcon(int team, int icon)
    {

    }

    public void PanelOn(int panel)
    {
        panels[panel].SetActive(true);
    }

    public void PanelOff(int panel)
    {
        panels[panel].SetActive(false);
    }

}
