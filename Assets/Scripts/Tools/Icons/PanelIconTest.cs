using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class PanelIconTest : MonoBehaviour
{

    //We will put here reference to prefab in Editor
    public CellExample CellPrefab;


    // Use this for initialization
    public void Init(string[] words, Sprite[] images)
    {
        int length = words.Length;

        float width = this.gameObject.GetComponent<RectTransform>().rect.width;
        width = Mathf.Min(width / length, this.gameObject.GetComponent<RectTransform>().rect.height*.8f);
        Vector2 newSize = new Vector2(width, (width * 1.25f));
        gameObject.GetComponent<GridLayoutGroup>().cellSize = newSize;

        for (int i = 0; i < length; i++)
        {
            GameObject newCell = Instantiate(CellPrefab.gameObject) as GameObject;
            newCell.GetComponent<CellExample>().Init(words[i], images[i]);

            newCell.transform.SetParent(this.gameObject.transform, false);

        }


    }
}