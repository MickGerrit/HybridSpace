using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterColCheck : MonoBehaviour {
    [SerializeField]
    private int maxColAmount;
    private int colAmount;
    public GameObject tree;
    public float timer;
	// Use this for initialization
	void Start () {
        colAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (colAmount >= maxColAmount) {
            
            tree.SetActive(true);
            this.GetComponent<MeshRenderer>().enabled = false;
            timer -= Time.deltaTime;
        }
        if (timer <= 0) {
            GameObject.Find("GameManager").GetComponent<GameManager>().LoadScene(1);
        }
        
	}

    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "water" && colAmount < maxColAmount) {
            colAmount += 1;
            transform.localScale += new Vector3(maxColAmount, maxColAmount, maxColAmount) /100;
        }
    }
}
