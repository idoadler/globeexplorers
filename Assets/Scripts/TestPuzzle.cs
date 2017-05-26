using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPuzzle : MonoBehaviour {
    public Puzzle puzzle;
    private bool running;

	// Use this for initialization
	void Start () {
        puzzle.Init();
        running = puzzle.UpdateBoard(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (running)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // is success on last question?
                running = puzzle.UpdateBoard(Random.value > 0.5);
            }
        }
    }
}
