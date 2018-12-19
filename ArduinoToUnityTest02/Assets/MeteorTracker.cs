using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorTracker : MonoBehaviour {
    public AudioSource impactSource;
    public GameObject sceneChecker;
    public GameObject flame;
    // Use this for initialization
    void Start () {
        impactSource = this.GetComponent<AudioSource>();
        if (this.GetComponent<MeshRenderer>() != null && this.GetComponent<SphereCollider>() != null) {
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<SphereCollider>().enabled = true;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Meteorite") {
            Debug.Log("Landed");
            GameObject.Destroy(other.gameObject);
            if (this.GetComponent<MeshRenderer>() != null && this.GetComponent<SphereCollider>() != null) {
                this.GetComponent<MeshRenderer>().enabled = true;
                this.GetComponent<SphereCollider>().enabled = false;
                impactSource.Play();
                impactSource.pitch = Random.Range(0.7f, 1.1f);
                flame.SetActive(false);
                sceneChecker.GetComponent<Day2Handler>().meteoritesLanded += 1;
            }
        }
    }
}
