using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSelectionPopulator : MonoBehaviour
{

    [SerializeField] private IconSelectionButton iconSelectionButtonPrefab;
    private Transform buttonParent;

    private IconSelectionButton[] buttons;
    private bool doneInit = false;

    private void OnEnable()
    {
        if (!doneInit)
        {
            PopulateIconSelection();
        }
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
    }

    private void PopulateIconSelection()
    {
        buttonParent = transform;
        buttons = new IconSelectionButton[StaticData.iconPool.Length];

        for (int i = 0; i < buttons.Length; i++)
        {
            IconSelectionButton button = Instantiate(iconSelectionButtonPrefab, buttonParent, false);
            button.Init(i);
            buttons[i] = button;

            if (i > 0)
            {
                Navigation newNavigation = new Navigation();
                newNavigation.mode = Navigation.Mode.Explicit;
                newNavigation.selectOnRight = button.myButton;
                buttons[i - 1].myButton.navigation = newNavigation;

                if (i == buttons.Length - 1)
                {
                    newNavigation.selectOnRight = buttons[0].myButton;
                    button.myButton.navigation = newNavigation;
                }
            }
        }
    }
}
