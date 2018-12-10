using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeChecker : MonoBehaviour {
    public GameObject cloud;
    public GameObject water;
    public float shakeAmount;
    public GameObject myLight;
    public Transform newCloudHeight;
    public float plantTimer;
    private float plantTiming;
    public GameObject plant;
    public bool noCloud;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (((this.GetComponent<JoyconV2>().gyro.x + this.GetComponent<JoyconV2>().gyro.y + 
            this.GetComponent<JoyconV2>().gyro.z) >= shakeAmount) && (myLight.GetComponent<WaterCloudInteraction>().cloudReady || noCloud)) {
            cloud.SetActive(true);
            if (water != null) water.SetActive(false);
            plantTiming = plantTimer;
        }
        if (cloud.active) {
            plantTiming -= Time.deltaTime;
            cloud.transform.position = Vector3.Lerp(cloud.transform.position, newCloudHeight.position, Time.deltaTime);
            cloud.transform.rotation = Quaternion.Lerp(cloud.transform.rotation, newCloudHeight.transform.rotation, Time.deltaTime);
            if (plantTiming <= 0 && plant != null) {
                plant.SetActive(true);
            }
        }
	}
}
