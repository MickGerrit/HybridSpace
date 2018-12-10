using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck : MonoBehaviour {
    public Material colorBegin;
    public Material color1;
    public Material color2;
    public int finishedPuzzle;
    public bool finishedPuzzle1;
    public bool finishedPuzzle2;
    public GameObject planet;
    public float timer;
	// Use this for initialization
	void Start () {
        planet.GetComponent<Renderer>().material = colorBegin;
    }
	
	// Update is called once per frame
	void Update () {
		if (finishedPuzzle == 0) {
            planet.GetComponent<Renderer>().material = colorBegin;
        }
        if (finishedPuzzle == 1) {
            planet.GetComponent<Renderer>().material = color1;
        }
        if (finishedPuzzle == 2) {
            planet.GetComponent<Renderer>().material = color2;
        }
        if (finishedPuzzle1) {
            finishedPuzzle = 1;
            if (finishedPuzzle2) {
                finishedPuzzle = 2;
                timer -= Time.deltaTime;
            }
        }
        if (finishedPuzzle2) {
            finishedPuzzle = 1;
            if (finishedPuzzle1) {
                finishedPuzzle = 2;
                timer -= Time.deltaTime;
            }
        }
        if (timer <= 0) {
            this.GetComponent<GameManager>().LoadScene(2);
        }
    }
}
