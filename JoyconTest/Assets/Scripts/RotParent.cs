using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotParent : MonoBehaviour {
    public GameObject rotObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(rotObject.transform.rotation.x, rotObject.transform.rotation.y, rotObject.transform.rotation.z);
    }
}
