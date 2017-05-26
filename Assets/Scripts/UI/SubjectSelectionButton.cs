using UnityEngine;
using UnityEngine.UI;

public class SubjectSelectionButton : MonoBehaviour
{
    public Button myButton { get; private set; }
    private string mySubject;
    
    public void Init(string subjectString)
    {
        mySubject = subjectString;
        myButton = GetComponent<Button>();
        Image myImage = GetComponent<Image>();

        myImage.sprite = StaticData.subjects[mySubject];
    }

    public void ChooseThisIcon()
    {
        StaticData.ChangeTeamSubject(StaticData.currentTeam, mySubject);
        StaticData.currentUIManager.ToLastPanel();
    }

}
