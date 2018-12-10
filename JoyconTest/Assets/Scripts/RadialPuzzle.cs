using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialPuzzle : MonoBehaviour {
    private List<Joycon> joycons;
    public int jc_ind = 0;
    public Vector3 rotationAim;
    [Range(0f, 320f)]
    public float low_freq;
    [Range(0f, 320f)]
    public float high_freq;
    [Range(0f, 10f)]
    public float amp;
    [Range(0f, 200f)]
    public int time = 0;
    public float eulerAngX;
    public float eulerAngX360;
    public float eulerAngY;
    public float eulerAngZ;
    public float tenthY;
    private Vector3 rotation;

    private float updateLowFreq;
    private float newLowFreq;

    public float rumbleLength;
    private float rumbleSteps;

    // Use this for initialization
    void Start () {
        rumbleLength = 0.2f;
        updateLowFreq = low_freq;

        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind + 1) {
            Destroy(gameObject);
        }
        tenthY = 0;
    }
	
	// Update is called once per frame
	void Update () {
        RotationStep();
        if (joycons.Count > 0) {
            Joycon j = joycons[jc_ind];
            CheckRot(eulerAngY, j);
            TestRumble(j);
            if ((eulerAngX >= 0 && eulerAngX <= 360)) {
                amp = 0.6f;
                high_freq = 185f;

                StepRumble(j);
            }
        }
    }

    void RotationStep() {
        rotation = transform.rotation.eulerAngles;
        eulerAngX = rotation.x;
        eulerAngX360 = rotation.x - 270;
        if (rotation.x < 270) {
            eulerAngX360 -= eulerAngX360*2 + 90;
        }
        eulerAngX360 *= 2;

        eulerAngY = rotation.y;
        eulerAngZ = rotation.z;
    }

    void CheckRot(float a, Joycon j) {
        if (Mathf.RoundToInt(a / 10) < tenthY) {
            tenthY = Mathf.RoundToInt(a / 10);
            rumbleSteps += 1;
        } else if (Mathf.RoundToInt(a / 10) > tenthY) {
            tenthY = Mathf.RoundToInt(a / 10);
            rumbleSteps += 1;
        } else if (Mathf.RoundToInt(a / 10) == tenthY) {
            Debug.Log(rumbleSteps);
        }
    }

    private void StepRumble(Joycon j) {
        if (rumbleSteps > 0) {
            float waitForRumble = 0;
            if (rumbleLength > 0) {
                rumbleLength -= Time.deltaTime;
                j.SetRumble(low_freq, high_freq, amp, time);
            } else while (rumbleLength <= 0) {
                waitForRumble += Time.deltaTime * 0.1f;
                j.SetRumble(0, 0, 0, 0);
                if (waitForRumble >= 100f) {
                        Debug.Log(waitForRumble);
                        rumbleLength = 0.05f;
                    rumbleSteps = 0;
                }

            }
        }
    }

    //test rumble with x and space
    private void TestRumble(Joycon j) {
        if (Input.GetKey(KeyCode.Space)) {
            j.SetRumble(low_freq, high_freq, amp, time);
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            j.SetRumble(0, 0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            j.SetRumble(low_freq, high_freq, amp, 0);
        } else if (Input.GetKeyDown(KeyCode.Z)) {
            j.SetRumble(0, 0, 0, 0);
        }
    }
}
