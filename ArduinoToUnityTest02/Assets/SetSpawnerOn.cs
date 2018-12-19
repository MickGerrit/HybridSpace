using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawnerOn : MonoBehaviour {
    public GameObject spawner;
    public GameObject landingSign;
    public bool spawn;
	// Use this for initialization
	void Start () {
        spawner.SetActive(false);
        landingSign.SetActive(false);
        spawn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawn == true) {
            spawner.SetActive(true);
            landingSign.SetActive(true);
        }
	}
}
