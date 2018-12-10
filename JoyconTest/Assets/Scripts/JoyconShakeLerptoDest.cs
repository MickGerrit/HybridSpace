using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconShakeLerptoDest : MonoBehaviour {
    public float shakeAmount;
    public GameObject GO;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (((this.GetComponent<JoyconV2>().gyro.x + this.GetComponent<JoyconV2>().gyro.y +
            this.GetComponent<JoyconV2>().gyro.z) >= shakeAmount)) {
            GO.GetComponent<Rigidbody>().isKinematic = false;
            GO.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, GO.transform.localPosition.z + 500));
        }

    }
}
