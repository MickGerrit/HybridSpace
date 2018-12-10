using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnTrigger : MonoBehaviour {
    public string otherTag;
	// Use this for initialization
	void Start () {
        this.GetComponent<MeshRenderer>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other) {
        if (other.tag == otherTag) {
            Debug.Log("Water");
            if (this.GetComponent<MeshRenderer>().enabled == false) {
                this.GetComponent<MeshRenderer>().enabled = true;
            } else if (transform.localPosition.y >= -6f){
                transform.localPosition -= new Vector3(0f,0.1f,0f);
            }
        }
    }
}
