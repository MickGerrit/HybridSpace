using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaryDiskPuzzle : MonoBehaviour {
    public GameObject[] disk;
    public float[] rotSnap;
    public float snapSpacing;

    public float[] minRotSnap;
    public float[] maxRotSnap;
    public bool[] snapped;

    public float timer;

    public GameObject forest;
    private GameObject gameManager;
    public GameObject emitter;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager");
        for (int i = 0; i <= disk.Length; i++) {
            minRotSnap[i] = rotSnap[i] - snapSpacing;
            maxRotSnap[i] = rotSnap[i] + snapSpacing;
            snapped[i] = false;
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (disk[0].transform.localRotation.eulerAngles.y >= (minRotSnap[0]) &&
            disk[0].transform.localRotation.eulerAngles.y <= maxRotSnap[0]) {
            snapped[0] = true;
            Debug.Log("Disk0");
        } else snapped[0] = false;
        if (disk[1].transform.localRotation.eulerAngles.y >= (minRotSnap[1]) &&
            disk[1].transform.localRotation.eulerAngles.y <= maxRotSnap[1]) {
            snapped[1] = true;
        } else snapped[1] = false;
        if (disk[2].transform.localRotation.eulerAngles.y >= (minRotSnap[2]) &&
            disk[2].transform.localRotation.eulerAngles.y <= maxRotSnap[2]) {
            snapped[2] = true;
        } else snapped[2] = false;
        if (snapped[0] && snapped[1] && snapped[2] == true) {
            Debug.Log("Completed");
            for (int i = 0; i <=2; i++) {
                disk[i].GetComponent<TreeRotate>().enabled = false;
                disk[i].GetComponent<RadialPuzzle>().enabled = false;
            }
            emitter.SetActive(true);
            timer -= Time.deltaTime;
        }
        if (timer <= 0) {
            forest.SetActive(true);
            gameManager.GetComponent<PuzzleCheck>().finishedPuzzle2 = true;
        }
    }
}
