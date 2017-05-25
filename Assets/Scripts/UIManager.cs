using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject[] panels;

    private int _lastPanel = 0;
    private int _currentPanel = 0;
    private GameObject _lastSelected;

    #region Public Methods

    public void SwitchPanel(int targetPanel)
    {
        if (_currentPanel != _lastPanel)
        {
            _lastPanel = _currentPanel;
            panels[_lastPanel].SetActive(false);
        }

        _currentPanel = targetPanel;
        panels[_currentPanel].SetActive(true);
    }

    public void PanelOff(int panel)
    {
        _lastPanel = panel;
        panels[panel].SetActive(false);
    }

    public void ToLastPanel()
    {
        SwitchPanel(_lastPanel);
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

        SwitchPanel(0);
    }

    #endregion

}
