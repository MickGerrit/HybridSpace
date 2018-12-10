using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour {
    public string otherTag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == otherTag) {
            Destroy(this.gameObject);
        }
        if (other.name == "vulcan") {
            //load next scene
        }
    }
}
