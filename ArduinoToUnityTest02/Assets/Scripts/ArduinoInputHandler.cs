using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

//This script is put on an ArduinoManager (the prefab) and this gameobject needs to be put in the scene
public class ArduinoInputHandler : MonoBehaviour {

    public string comPort;
    SerialPort sp;

    [SerializeField]
    private string[] ardInput;
    private string[] tempArdInput;


    public bool button0;
    public bool button1;
    public bool button2;
    public bool button3;

    public Vector3 gyroRot;

    public float soundVal;
    public float curVibration;

    public float wantedVibration;

    public bool debugMode;

    // Use this for initialization
    void Start () {
        sp = new SerialPort(comPort, 9600);
        sp.Open();
	}
	
	// Update is called once per frame
	void Update () {
        if (sp.IsOpen) {
            try {
                //print(sp.ReadLine());
                tempArdInput = sp.ReadLine().Split('x', 'y', 'z', 'a', 'b', 'c', 'd', 's', 'v');
                if (tempArdInput.Length == 10) ardInput = tempArdInput;

                
                if (ardInput[0] == "" && ardInput[1] != "" && ardInput[2] != "" &&
                    ardInput[3] != "" && ardInput[4] != "" && ardInput[5] != "" && ardInput[6] != ""
                    && ardInput[7] != "" && ardInput[8] != "" && ardInput[9] != "") //Check if all values are recieved
{
                    if (ardInput[4] == "1") {
                        button0 = true;
                    } else button0 = false;
                    if (ardInput[5] == "1") {
                        button1 = true;
                    } else button1 = false;
                    if (ardInput[6] == "1") {
                        button2 = true;
                    } else button2 = false;
                    if (ardInput[7] == "1") {
                        button3 = true;
                    } else button3 = false;
                    if (!debugMode) {
                        soundVal = float.Parse(ardInput[8]);
                    } 
                    curVibration = float.Parse(ardInput[9]);
                    if (!debugMode) {
                        gyroRot = new Vector3(float.Parse(ardInput[1]), float.Parse(ardInput[2]), float.Parse(ardInput[3]));
                    }
                    SetVibration(wantedVibration);
                    //Read the information and put it in a vector3
                    //Take the vector3 and apply it to the object this script is applied.
                    sp.BaseStream.Flush(); //Clear the serial information so we assure we get new information.
                }
                sp.ReadTimeout = 15;


            } catch (System.Exception) {
                throw;
            }

        }
	}
    void SetVibration(float vib) {
        if (vib != curVibration) {
            string vibString;
            vibString = vib.ToString();
            sp.Write("v");
            sp.Write(vibString);
        }
    } 
}

