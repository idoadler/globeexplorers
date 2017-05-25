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
            for (int j = 0; j < parsed.GetLength(0); j++)
            {
                result += parsed[j, i] + " | ";
            }
            result += "\n";
        }
        display.text = result;
    }
}