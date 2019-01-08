using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//put this script on a parent object that has a child that needs to rotate
public class PlanetRotationV2 : ArduinoManager {
    public float speed;
    public bool mirrorRot;
    public Vector3 onButtonGyroRot;
    public Vector3 lastRot;
    public Vector3 wantedRot;
    public bool setLastRot;
    public bool wind = false;
    private GameObject myChild;

    private bool rotResetOnButton;

    private void Start() {
        setLastRot = false;
        myChild = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update() {
        if (wind) mirrorRot = false;
        if ((arduinoInput.button0 && mirrorRot) || wind) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler
            (arduinoInput.gyroRot.x, arduinoInput.gyroRot.y, arduinoInput.gyroRot.z), Time.deltaTime * speed);

        }



        if (!mirrorRot) {
            if (!arduinoInput.button0 && !setLastRot) {
                lastRot = new Vector3(myChild.transform.eulerAngles.x, myChild.transform.eulerAngles.y,
                    myChild.transform.eulerAngles.z);
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

                myChild.transform.localRotation = Quaternion.Slerp(myChild.transform.localRotation, Quaternion.Euler
                (myChild.transform.localRotation.x, wantedRot.y,
                wantedRot.z), Time.deltaTime * speed);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler
                (wantedRot.x, transform.localRotation.y,
                transform.localRotation.z), Time.deltaTime * speed);
                Debug.Log("Button Holding");
            }
        }
    }
}