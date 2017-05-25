using UnityEngine;
using UnityEngine.UI;

public class ReadDemo : MonoBehaviour
{

    public TextAsset csv;
    public Text display;

    void Start()
    {
        string[,] parsed = CSVReader.SplitCsvGrid(csv.text);
        CSVReader.DebugOutputGrid(parsed);
        string result = "";
        for (int i = 0; i < parsed.GetLength(1); i++)
        { 
            result += parsed[0, i] + " | " + parsed[1, i] + "\n";
        }
        display.text = ArabicSupport.ArabicFixer.Fix(result);
    }
}