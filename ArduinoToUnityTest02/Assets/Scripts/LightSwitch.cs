using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightSwitch : ArduinoManager {

    public bool shining;
    private bool switchReset;
    private Light myLightSource;

    public float lightIntensity;
    public float speed;

    public GameObject day1Handler;
    public GameObject canvas;
	// Use this for initialization
	void Start () {
        myLightSource = this.GetComponent<Light>();
        lightIntensity = myLightSource.intensity;
        switchReset = false;
        myLightSource.intensity = 0;

    }
	
	// Update is called once per frame
	void Update () {
		if (arduinoInput.button1 && switchReset) {
            shining = !shining;
            switchReset = false;
        }
        if (!arduinoInput.button1) {
            switchReset = true;
        }

        if (shining && myLightSource.intensity <= lightIntensity) {
            myLightSource.intensity += speed*Time.deltaTime;
        } else if (!shining && myLightSource.intensity > 0) {
            myLightSource.intensity -= speed * Time.deltaTime;
        }

        if (day1Handler.GetComponent<Day1Handler>().wasCold && day1Handler.GetComponent<Day1Handler>().wasHot && 
            myLightSource.intensity <= 0 && canvas.active) {
            SceneManager.LoadScene(1);

        }
	}
}
