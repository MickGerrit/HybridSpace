using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : ArduinoManager {
    public float speed;
    public bool mirrorRot;
    public Vector3 onButtonGyroRot;
    public Vector3 lastRot;
    public Vector3 wantedRot;
    public bool setLastRot;

    private bool rotResetOnButton;

    private void Start() {
        setLastRot = false;
    }

    // Update is called once per frame
    void Update () {

        if (arduinoInput.button0 && mirrorRot) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler
            (arduinoInput.gyroRot.x, arduinoInput.gyroRot.y, arduinoInput.gyroRot.z), Time.deltaTime * speed);
            
        }



        if (!mirrorRot) {
            if (!arduinoInput.button0 && !setLastRot) {
                lastRot = transform.eulerAngles;
                setLastRot = true;
                rotResetOnButton = true;
                Debug.Log("No Button Pressed");
            }
            if (arduinoInput.button0) {
                setLastRot = false;
                if (rotResetOnButton) {
                    onButtonGyroRot = new Vector3(arduinoInput.gyroRot.x, arduinoInput.gyroRot.y, arduinoInput.gyroRot.z);
                    Debug.Log("Button Press Down");
                    rotResetOnButton = false;
                }
                wantedRot = arduinoInput.gyroRot - onButtonGyroRot + lastRot;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler
                (wantedRot.x, wantedRot.y, 
                wantedRot.z), Time.deltaTime * speed);
                Debug.Log("Button Holding");
            }
        }
    }
}
