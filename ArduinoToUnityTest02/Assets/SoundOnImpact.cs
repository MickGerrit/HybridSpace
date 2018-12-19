using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnImpact : MonoBehaviour {
    public AudioSource impactSource;
	// Use this for initialization
	void Start () {
        impactSource = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Planet") {
            impactSource.Play();
            impactSource.pitch = Random.Range(0.7f, 1.1f);
        }
    }
}
