using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject[] panels;

    private GameObject _lastSelected;

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

    private void Update()
    {
        if (Input.touchCount == 0 && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)) && EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(_lastSelected);
        }
        else
        {
            _lastSelected = EventSystem.current.currentSelectedGameObject;
        }
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
