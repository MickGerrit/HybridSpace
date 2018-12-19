using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

//This script is put on an ArduinoManager (the prefab) and this gameobject needs to be put in the scene
public class ArduinoInputHandler : MonoBehaviour {

    SerialPort sp = new SerialPort("COM6", 9600);

    [SerializeField]
    private string[] ardInput;

    public bool button0;
    public bool button1;
    public bool button2;
    public bool button3;

    public Vector3 gyroRot;

    // Use this for initialization
    void Start () {
        sp.Open();
	}
	
	// Update is called once per frame
	void Update () {

        if (sp.IsOpen) {
            try {
                
                ardInput = sp.ReadLine().Split('x', 'y', 'z', 'a', 'b', 'c', 'd');

                
                if (ardInput[0] != "" && ardInput[1] != "" && ardInput[2] != "" &&
                    ardInput[3] != "" && ardInput[4] != "" && ardInput[5] != "" && ardInput[6] != "") //Check if all values are recieved
{
                    if (ardInput[3] == "1") {
                        button0 = true;
                    } else button0 = false;
                    if (ardInput[4] == "1") {
                        button1 = true;
                    } else button1 = false;
                    if (ardInput[5] == "1") {
                        button2 = true;
                    } else button2 = false;
                    if (ardInput[6] == "1") {
                        button3 = true;
                    } else button3 = false;

                    gyroRot = new Vector3(float.Parse(ardInput[0]), float.Parse(ardInput[1]), float.Parse(ardInput[2]));

                    //Read the information and put it in a vector3
                    //Take the vector3 and apply it to the object this script is applied.
                    sp.BaseStream.Flush(); //Clear the serial information so we assure we get new information.
                }



            } catch (System.Exception) {
                throw;
            }

        }
	}
}

