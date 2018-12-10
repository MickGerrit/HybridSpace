using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsRot : MonoBehaviour {

    public Vector3 rotDest;
    private Vector3 rotStart;
    private bool drifting;
	// Use this for initialization
	void Start () {
        rotStart = transform.eulerAngles;
        drifting = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (drifting) {
            transform.Rotate(rotDest, 3 * Time.deltaTime);
        }
        else if (!drifting) {
            transform.Rotate(rotDest, -3 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q)) {
            drifting = false;
        }
	}
}
