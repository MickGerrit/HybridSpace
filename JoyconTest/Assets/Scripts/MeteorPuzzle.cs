using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPuzzle : MonoBehaviour {

    public GameObject cloud;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "planet") {
            cloud.GetComponent<turnoffMeshRend>().stayAtPos = true;
        }
        if (other.tag == "vulcano") {
            this.GetComponent<MeshCollider>().enabled = false;
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
