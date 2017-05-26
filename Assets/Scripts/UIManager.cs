using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image[] _team0Images;
    [SerializeField] private Image[] _team1Images;
    [SerializeField] private GameObject[] _panels;
    [SerializeField] private GameObject _firstButton;
    [SerializeField] private Puzzle _puzzle;

    private int _lastPanel = 2;
    private int _currentPanel = 2;
    private GameObject _lastSelected;

    #region Public Methods

    public void SwitchPanel(int targetPanel)
    {
        if (_currentPanel != _lastPanel)
        {
            _lastPanel = _currentPanel;
            _panels[_lastPanel].SetActive(false);
        }

        _currentPanel = targetPanel;
        _panels[_currentPanel].SetActive(true);

        if (targetPanel == 0)
        {
            EventSystem.current.SetSelectedGameObject(_firstButton);
        }
    }

    public void PanelOff(int panel)
    {
        _lastPanel = panel;
        _panels[panel].SetActive(false);
    }

    public void ToLastPanel()
    {
        SwitchPanel(_lastPanel);
    }

    public void SelectSubjet(int team)
    {
        StaticData.currentTeam = team;
        SwitchPanel(1);
    }

    public void UpdateTeamIcons(int team)
    {
        if (team == 0)
        {
            for (int i = 0; i < _team0Images.Length; i++)
            {
                _team0Images[i].sprite = StaticData.teamIcons[0];
            }
        }
        else if (team == 1)
        {
            for (int i = 0; i < _team1Images.Length; i++)
            {
                _team1Images[i].sprite = StaticData.teamIcons[1];
            }
        }
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
        Input.simulateMouseWithTouches = false;
        Cursor.lockState = CursorLockMode.Locked;

        InitPanels();
        StaticData.Init(this);
    }

    private void InitPanels()
    {
        for (int i = 1; i < _panels.Length; i++)
        {
            PanelOff(i);
        }

        SwitchPanel(0);
    }

    #endregion

}
