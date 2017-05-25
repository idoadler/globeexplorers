using UnityEngine;
using UnityEngine.UI;

public class ReadDemo : MonoBehaviour
{
    public TextAsset csv;
    public Text display;
    public string[,] lines;

    void Awake()
    {
        lines = CSVReader.SplitCsvGrid(csv.text);
    }

    void Start()
    {
        CSVReader.DebugOutputGrid(lines);

        if (display != null)
        {
            string result = "";
            for (int i = 0; i < lines.GetLength(1); i++)
            {
                result += lines[0, i] + " | " + lines[1, i] + "\n";
            }
            display.text = ArabicSupport.ArabicFixer.Fix(result);
        }

    }
}