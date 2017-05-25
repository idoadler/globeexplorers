using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSelectionPopulator : MonoBehaviour
{

    [SerializeField] private IconSelectionButton iconSelectionButtonPrefab;
    private Transform buttonParent;

    private void Start()
    {
        PopulateIconSelection();
    }

    private void PopulateIconSelection()
    {
        buttonParent = transform;

        for (int i = 0; i < StaticData.iconPool.Length; i++)
        {
            IconSelectionButton button = Instantiate(iconSelectionButtonPrefab, buttonParent, false);
            button.Init(i);
        }
    }

}
