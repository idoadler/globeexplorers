using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SubjectSelectionPopulator : MonoBehaviour
{

    [SerializeField] private SubjectSelectionButton _iconSelectionButtonPrefab;
    private Transform _buttonParent;
    private SubjectSelectionButton[] _buttons;
    private bool _doneInit = false;

    private void OnEnable()
    {
        if (!_doneInit)
        {
            PopulateIconSelection();
        }
        EventSystem.current.SetSelectedGameObject(_buttons[0].gameObject);
    }

    private void PopulateIconSelection()
    {
        UIManager manager = FindObjectOfType<UIManager>();
        _buttonParent = transform;
        _buttons = new SubjectSelectionButton[StaticData.subjects.Count];

        string[] subjectStrings = new string[_buttons.Length];
        StaticData.subjects.Keys.CopyTo(subjectStrings, 0);

        for (int i = 0; i < _buttons.Length; i++)
        {
            SubjectSelectionButton button = Instantiate(_iconSelectionButtonPrefab, _buttonParent, false);
            button.Init(subjectStrings[i], manager);
            _buttons[i] = button;

            if (i > 0)
            {
                Navigation newNavigation = new Navigation();
                newNavigation.mode = Navigation.Mode.Explicit;
                newNavigation.selectOnRight = button.myButton;
                _buttons[i - 1].myButton.navigation = newNavigation;

                if (i == _buttons.Length - 1)
                {
                    newNavigation.selectOnRight = _buttons[0].myButton;
                    button.myButton.navigation = newNavigation;
                }
            }
        }

        _doneInit = true;
    }
}
