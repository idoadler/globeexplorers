using UnityEngine;
using UnityEngine.UI;

public class SubjectSelectionButton : MonoBehaviour
{
    public Button myButton { get; private set; }
    private string mySubject;
    private UIManager _manager;
    
    public void Init(string subjectString, UIManager manager)
    {
        mySubject = subjectString;
        myButton = GetComponent<Button>();
        Image myImage = GetComponent<Image>();

        myImage.sprite = StaticData.subjects[mySubject];

        _manager = manager;
    }

    public void ChooseThisIcon()
    {
        StaticData.ChangeTeamSubject(StaticData.currentTeam, mySubject);
        _manager.ToLastPanel();
    }

}
