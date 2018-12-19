using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1Handler : ArduinoManager {

    public float lightTime;
    public float darkTime;

    public GameObject lighting;

    public float timeThreshold;

    public GameObject[] fire;
    public GameObject[] ice;

    public bool wasCold;
    public bool wasHot;

    public GameObject day1Begin; 
    public GameObject day1End;

    public float canvasTimer = 0;
    private bool beginCanvasOn;

	// Use this for initialization
	void Start () {
        lightTime = 0;
        darkTime = 0;
        wasCold = false;
        wasHot = false;
        beginCanvasOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (lighting.GetComponent<LightSwitch>().shining) {
            lightTime += Time.deltaTime;
            darkTime = 0;
            Ice(false);
        }
        if (arduinoInput.button1) {
            beginCanvasOn = true;
        }
        
        if (beginCanvasOn) {
            day1Begin.SetActive(true);
        }


        if (!lighting.GetComponent<LightSwitch>().shining && wasHot) {
            darkTime += Time.deltaTime;
            lightTime = 0;
            Fire(false);
            if (wasCold) {
                //switch to other scene
            }
        }
        

        if (lightTime > timeThreshold) Fire(true);
        
            
        if (darkTime > timeThreshold) Ice(true);

        if (wasCold && wasHot && (lightTime < timeThreshold && darkTime < timeThreshold)) {
            day1End.SetActive(true);
            day1Begin.SetActive(false);
        }

    }

    private void Fire(bool a) {
        for (int i = 0; i < fire.Length; i++) {
            fire[i].SetActive(a);
            if (a) wasHot = true;
        }
    }
    private void Ice(bool a) {
        for (int i = 0; i < ice.Length; i++) {
            ice[i].SetActive(a);
            if (a) wasCold = true;
        }
    }
    
}
