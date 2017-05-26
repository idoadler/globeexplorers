using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class Puzzle : MonoBehaviour {
    //We will put here reference to prefab in Editor
    public Image PiecePrefab;
    public int size = 5;
    public Color standard;
    public Color selected;
    private Color empty = new Color(0,0,0,0);

    private Image[,] pieces;

	// Use this for initialization
	public void Init () {
        Rect rect = this.gameObject.GetComponent<RectTransform>().rect;
        Vector2 newSize = new Vector2(rect.width / size, rect.height / size);
        gameObject.GetComponent<GridLayoutGroup>().cellSize = newSize;

        pieces = new Image[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                GameObject newPiece = Instantiate(PiecePrefab.gameObject) as GameObject;
                newPiece.transform.SetParent(this.gameObject.transform, false);
                pieces[i, j] = newPiece.GetComponent<Image>();
                pieces[i, j].color = standard;
            }
        }
    }

    public bool IsFinished()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (pieces[i, j].color != empty)
                    return false;
            }
        }
        return true;
    }

    public bool UpdateBoard(bool success)
    {
        if (success)
            pieces[r1, r2].color = empty;
        else
            pieces[r1, r2].color = standard;

        if (IsFinished())
            return false;

        SelectRandomPiece();

        return true;
    }

    int r1, r2;
    private void SelectRandomPiece()
    {
        r1 = Random.Range(0, size);
        r2 = Random.Range(0, size);
        while (pieces[r1, r2].color == empty)
        {
            r1 = Random.Range(0, size);
            r2 = Random.Range(0, size);
        }
        pieces[r1, r2].color = selected;
    }
}
