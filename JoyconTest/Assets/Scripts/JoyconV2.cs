﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconV2 : MonoBehaviour {

    private List<Joycon> joycons;
    public bool holdToRotate;
    // Values made available via Unity
    public float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    public int jc_ind = 0;
    public Quaternion orientation;
    public Vector3 orientationXYZ;
    public Joycon j;
    public Vector3 oldOrientationXYZ;
    public Vector3 newOrientationXYZ;

    void Start() {
        holdToRotate = true;
        gyro = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        // get the public Joycon array attached to the JoyconManager in scene
        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind + 1) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        // make sure the Joycon only gets checked if attached
        if (joycons.Count > 0) {
            j = joycons[jc_ind];
            // GetButtonDown checks if a button has been pressed (not held)
            if (j.GetButtonDown(Joycon.Button.SHOULDER_2)) {
                Debug.Log("Shoulder button 2 pressed");
                // GetStick returns a 2-element vector with x/y joystick components
                Debug.Log(string.Format("Stick x: {0:N} Stick y: {1:N}", j.GetStick()[0], j.GetStick()[1]));

                // Joycon has no magnetometer, so it cannot accurately determine its yaw value. Joycon.Recenter allows the user to reset the yaw value.
                j.Recenter();
            }
            // GetButtonDown checks if a button has been released
            if (j.GetButtonUp(Joycon.Button.SHOULDER_2)) {
                Debug.Log("Shoulder button 2 released");
            }
            // GetButtonDown checks if a button is currently down (pressed or held)
            if (j.GetButton(Joycon.Button.SHOULDER_2)) {
                Debug.Log("Shoulder button 2 held");
            }

            if (j.GetButtonDown(Joycon.Button.DPAD_DOWN)) {
                Debug.Log("Rumble");

                // Rumble for 200 milliseconds, with low frequency rumble at 160 Hz and high frequency rumble at 320 Hz. For more information check:
                // https://github.com/dekuNukem/Nintendo_Switch_Reverse_Engineering/blob/master/rumble_data_table.md

                //j.SetRumble(30, 130, 2f, 100);

                // The last argument (time) in SetRumble is optional. Call it with three arguments to turn it on without telling it when to turn off.
                // (Useful for dynamically changing rumble values.)
                // Then call SetRumble(0,0,0) when you want to turn it off.
            }

            stick = j.GetStick();

            // Gyro values: x, y, z axis values (in radians per second)
            gyro = j.GetGyro();

            // Accel values:  x, y, z axis values (in Gs)
            accel = j.GetAccel();
            if (j.GetButtonDown(Joycon.Button.DPAD_DOWN) || !holdToRotate) {
                orientation = j.GetVector();
                orientation = Quaternion.Inverse(new Quaternion(orientation.x, orientation.z, orientation.y, orientation.w));
                newOrientationXYZ = orientation.eulerAngles;
                newOrientationXYZ = new Vector3(newOrientationXYZ.x, newOrientationXYZ.y, newOrientationXYZ.z);
            }
             
            if (j.GetButton(Joycon.Button.DPAD_DOWN) || !holdToRotate) {
                SetRotation();
                if (((gameObject.transform.localRotation.x - Quaternion.Euler(orientationXYZ).x) >=100) ||
                    ((gameObject.transform.localRotation.y - Quaternion.Euler(orientationXYZ).y) >= 100) ||
                    ((gameObject.transform.localRotation.z - Quaternion.Euler(orientationXYZ).z) >= 100)) {
                        gameObject.transform.localRotation = Quaternion.Euler(orientationXYZ);
                } else {
                    gameObject.transform.localRotation = Quaternion.Slerp(gameObject.transform.localRotation, 
                        Quaternion.Euler(orientationXYZ), Time.deltaTime * 8);
                }
                
            }
            if (j.GetButtonUp(Joycon.Button.DPAD_DOWN) || !holdToRotate) {
                oldOrientationXYZ = orientationXYZ;
            }

           

        }

    }
    private void SetRotation() {
        orientation = j.GetVector();
        orientation = Quaternion.Inverse(new Quaternion(orientation.x, orientation.z, orientation.y, orientation.w));
        orientationXYZ = orientation.eulerAngles;
        //orientationXYZ = RoundedVector3InDegrees(new Vector3(orientationXYZ.x, orientationXYZ.y, orientationXYZ.z) - newOrientationXYZ + oldOrientationXYZ);
    }

    private Vector3 RoundedVector3InDegrees(Vector3 a) {
        if (a.x < 0) {
            a = new Vector3(360 + a.x, a.y,a.z);
        }
        if (a.y < 0) {
            a = new Vector3(a.x, 360 + a.y, a.z);
        }
        if (a.z < 0) {
            a = new Vector3(a.x, a.y, 360 + a.z);
        }

        if (a.x > 360) {
            a = new Vector3(a.x - 360, a.y, a.z);
        }
        if (a.y > 360) {
            a = new Vector3(a.x, a.y - 360, a.z);
        }
        if (a.z > 360) {
            a = new Vector3(a.x, a.y, a.z - 360);
        }
        return a;
    }
}