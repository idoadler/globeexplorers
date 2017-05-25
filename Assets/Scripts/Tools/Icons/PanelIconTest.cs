using UnityEngine;

public class PanelIconTest : MonoBehaviour
{

    //We will put here reference to prefab in Editor
    public CellExample CellPrefab;


    // Use this for initialization
    public void Init(string[] words, Sprite[] images)
    {

        for (int i = 0; i < words.Length; i++)
        {
            GameObject newCell = Instantiate(CellPrefab.gameObject) as GameObject;
            newCell.GetComponent<CellExample>().Init(words[i], images[i]);

            newCell.transform.SetParent(this.gameObject.transform, false);

        }


    }
}