using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(GridLayoutGroup))]
public class Puzzle : MonoBehaviour
{
    private const float LERP_TIME = 2;

    //We will put here reference to prefab in Editor
    public Image PiecePrefab;
    public Sprite[] backgrounds;
    public int size = 5;
    public Color standard;
    public Color selected;
    public QuestionLogic questionLogic;

    private Color empty = new Color(0,0,0,0);
    private Image[,] pieces;
    private bool midGame = false;
    private Image fadeToEmpty = null;
    private float fadeTime = 0;

    private void OnEnable()
    {
        if (!midGame)
        {
            Init();
        }
    }

    public void Init()
    {
        midGame = true;

        if (backgrounds.Length > 0)
        {
            GetComponent<Image>().sprite = backgrounds[Random.Range(0, backgrounds.Length)];
        }

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

        UpdateBoard(false);
    }

    public bool IsFinished()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (pieces[i, j].color != empty && pieces[i,j] != fadeToEmpty)
                    return false;
            }
        }
        return true;
    }

    public bool UpdateBoard(bool success)
    {
        if (success)
            AnimateSuccess();
        else
            pieces[r1, r2].color = standard;

        if (IsFinished())
            return false;

        SelectRandomPiece();

        return true;
    }

    private void AnimateSuccess()
    {
        if (fadeToEmpty != null)
        {
            fadeToEmpty.color = empty;
        }
        fadeToEmpty = pieces[r1, r2];
    }

    int r1, r2;
    private void SelectRandomPiece()
    {
        r1 = Random.Range(0, size);
        r2 = Random.Range(0, size);
        while (pieces[r1, r2].color == empty || pieces[r1,r2] == fadeToEmpty)
        {
            r1 = Random.Range(0, size);
            r2 = Random.Range(0, size);
        }
        pieces[r1, r2].color = selected;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StaticData.currentUIManager.SwitchPanel(3);
            questionLogic.SetQuestion(StaticData.currentTeam);
        }

        if (fadeToEmpty != null)
        {
            fadeTime += Time.deltaTime / LERP_TIME;
            if (fadeTime < 1)
            {
                fadeToEmpty.color = Color.Lerp(standard, empty, fadeTime);
            }
            else
            {
                fadeToEmpty.color = empty;
                fadeToEmpty = null;
                fadeTime = 0;
            }
        }
    }
}
