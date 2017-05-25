using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject iconSelectionPrefab;
    public GameObject[] panels;

    #region Public Methods

    public void PanelOn(int panel)
    {
        panels[panel].SetActive(true);
    }

    public void PanelOff(int panel)
    {
        panels[panel].SetActive(false);
    }

    #endregion

    #region Private Methods

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        InitPanels();
        StaticData.Init();
    }

    private void InitPanels()
    {
        for (int i = 1; i < panels.Length; i++)
        {
            PanelOff(i);
        }

        PanelOn(0);
    }

    #endregion

}
