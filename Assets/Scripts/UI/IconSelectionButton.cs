﻿using UnityEngine;
using UnityEngine.UI;

public class IconSelectionButton : MonoBehaviour
{
    public Button myButton { get; private set; }
    private int myIndex;
    private UIManager _manager;
    
    public void Init(int iconIndex, UIManager manager)
    {
        myIndex = iconIndex;
        myButton = GetComponent<Button>();
        Image myImage = GetComponent<Image>();

        myImage.sprite = StaticData.iconPool[myIndex];
    }

    public void ChooseThisIcon()
    {
        StaticData.ChangeTeamIcon(StaticData.currentTeam, myIndex);
        
    }

}