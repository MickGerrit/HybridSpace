using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPuzzle : MonoBehaviour {
    private List<Joycon> joycons;
    private string order = "xbay";
    public string inputOrder = "";
    public int jc_ind = 0;
    public Material matA;
    public Material matB;
    public Material matX;
    public Material matY;
    public Color colorIdle;
    public Color colorWrong;
    public GameObject[] lavaEmitters;

    private GameObject gameManager;
    // Use this for initialization
    void Start() {
        gameManager = GameObject.Find("GameManager");
        SetEmittingOn();
        inputOrder = "";
        SetColorBack();
        // get the public Joycon array attached to the JoyconManager in scene
        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind + 1) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        if (joycons.Count > 0) {
            Joycon j = joycons[jc_ind];
            InputToString(j);
            if (order.Substring(0, inputOrder.Length) != inputOrder) {
                inputOrder = "";
                StartCoroutine(SetColorWrong(j));
                SetEmittingOn();
            }
            if (order == inputOrder) {
                gameManager.GetComponent<PuzzleCheck>().finishedPuzzle1 = true;
            }
        }
    }

    private void InputToString(Joycon j) {
        if (j.GetButtonDown(Joycon.Button.DPAD_DOWN)) {
            inputOrder += "b";
            matB.color = Color.green;
            lavaEmitters[1].SetActive(false);
        }
        if (j.GetButtonDown(Joycon.Button.DPAD_RIGHT)) {
            inputOrder += "a";
            matA.color = Color.green;
            lavaEmitters[0].SetActive(false);
        }
        if (j.GetButtonDown(Joycon.Button.DPAD_LEFT)) {
            inputOrder += "y";
            matY.color = Color.green;
            lavaEmitters[3].SetActive(false);
        }
        if (j.GetButtonDown(Joycon.Button.DPAD_UP)) {
            inputOrder += "x";
            matX.color = Color.green;
            lavaEmitters[2].SetActive(false);
        }
    }

    private IEnumerator SetColorWrong(Joycon j) {
        matA.color = colorWrong;
        matB.color = colorWrong;
        matX.color = colorWrong;
        matY.color = colorWrong;
        j.SetRumble(30, 130, 2f, 100);
        yield return new WaitForSeconds(1f);
        j.SetRumble(0, 0, 0f, 0);
        SetColorBack();
    }
    private void SetColorBack() {
        matA.color = colorIdle;
        matB.color = colorIdle;
        matX.color = colorIdle;
        matY.color = colorIdle;
    }

    private void SetEmittingOn() {
        for (int i = 0; i <= 3; i++) {
            lavaEmitters[i].SetActive(true);
        }
    }
}

