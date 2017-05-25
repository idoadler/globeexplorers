using UnityEngine;
using UnityEngine.UI;

public class IconSelectionButton : MonoBehaviour
{

    private int myIndex;

    public void Init(int iconIndex)
    {
        myIndex = iconIndex;
        Image myImage = GetComponent<Image>();

        myImage.sprite = StaticData.iconPool[myIndex];
    }

    public void SelectThisIcon()
    {
        StaticData.ChangeTeamIcon(StaticData.currentTeam, myIndex);
    }

}
