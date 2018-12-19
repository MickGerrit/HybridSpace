using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArduinoManager : MonoBehaviour {

    public ArduinoInputHandler arduinoInput;

	// Use this for initialization
	void Awake() {
        arduinoInput = GameObject.Find("ArduinoManager").GetComponent<ArduinoInputHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		if (arduinoInput == null) {
            Debug.Log("No ArduinoInputHandler");
        }
	}
}
