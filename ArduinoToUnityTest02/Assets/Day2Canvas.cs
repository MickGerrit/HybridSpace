using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day2Canvas : ArduinoManager {

    public GameObject canvas;

	// Use this for initialization
	void Start () {
        canvas.SetActive(true);
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (arduinoInput.button1) {
            canvas.SetActive(false);
            Time.timeScale = 1.0f;
        }
	}
}
