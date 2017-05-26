using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class PanelIconTest : MonoBehaviour
{
    private List<GameObject> _existingCells;

    //We will put here reference to prefab in Editor
    public CellExample CellPrefab;

    public void Init(string[] words, Sprite[] images)
    {
        if (_existingCells == null)
        {
            _existingCells = new List<GameObject>();
        }

        int length = words.Length;

        float width = this.gameObject.GetComponent<RectTransform>().rect.width;
        width = Mathf.Min(width / length, this.gameObject.GetComponent<RectTransform>().rect.height*.8f);
        Vector2 newSize = new Vector2(width, (width * 1.25f));
        gameObject.GetComponent<GridLayoutGroup>().cellSize = newSize;

        for (int i = 0; i < length; i++)
        {
            GameObject newCell = Instantiate(CellPrefab.gameObject) as GameObject;
            _existingCells.Add(newCell);
            newCell.GetComponent<CellExample>().Init(words[i], images[i]);

            newCell.transform.SetParent(this.gameObject.transform, false);
        }
    }

    public void Clear()
    {
        List<int> cellsToRemove = new List<int>();

        if (_existingCells != null && _existingCells.Count > 0)
        {
            for (int i = _existingCells.Count - 1; i >= 0; i--)
            {
                GameObject go = _existingCells[i];
                _existingCells.Remove(go);
                Destroy(go);
            }
        }
    }
}