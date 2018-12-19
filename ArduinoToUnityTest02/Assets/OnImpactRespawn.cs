using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImpactRespawn : MonoBehaviour {
    public GameObject vulcanSpawner;
    public GameObject canvas2;
	// Use this for initialization
	void Start () {
        vulcanSpawner = GameObject.Find("VulcanStoneSpawner");
        canvas2 = GameObject.Find("Canvas2");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag != "vulcano") {
            vulcanSpawner.GetComponent<SpawnFromTransforms>().spawnNow = true;
            GameObject.Destroy(this.gameObject);
        } else if (col.gameObject.tag == "vulcano"){
            canvas2.transform.GetChild(0).gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }


        

    }
}
