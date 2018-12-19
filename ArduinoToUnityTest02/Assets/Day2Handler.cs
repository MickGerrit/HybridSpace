using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day2Handler : MonoBehaviour {

    public int meteoritesLanded;
    public int maxAmount;
    private bool stage1;
    public float vulcanoTimeAmt;
    private float vulcanoTimer;
    public GameObject vulcano;

	// Use this for initialization
	void Start () {
        stage1 = false;
        meteoritesLanded = 0;
        vulcano.GetComponent<Animator>().enabled = false ;
    }
	
	// Update is called once per frame
	void Update () {
		if (meteoritesLanded == maxAmount) {
            stage1 = true;
        }
        if (stage1) {
            vulcanoTimer += Time.deltaTime;
            if (vulcanoTimer > vulcanoTimeAmt) {
                vulcano.GetComponent<Animator>().enabled = true;
            }

        }
	}
    
}
