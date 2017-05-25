using UnityEngine;
using UnityEngine.UI;

public class IconSelectionPopulator : MonoBehaviour
{

    [SerializeField] private IconSelectionButton _iconSelectionButtonPrefab;
    private Transform _buttonParent;
    private IconSelectionButton[] _buttons;
    private bool _doneInit = false;

    private void OnEnable()
    {
        if (!_doneInit)
        {
            PopulateIconSelection();
        }
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(_buttons[0].gameObject);
    }

    private void PopulateIconSelection()
    {
        UIManager manager = FindObjectOfType<UIManager>();
        _buttonParent = transform;
        _buttons = new IconSelectionButton[StaticData.iconPool.Length];

        for (int i = 0; i < _buttons.Length; i++)
        {
            IconSelectionButton button = Instantiate(_iconSelectionButtonPrefab, _buttonParent, false);
            button.Init(i, manager);
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
    }
}
