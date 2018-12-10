using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCloudInteraction : MonoBehaviour {

    private List<Joycon> joycons;
    public int jc_ind = 0;
    private Light lightSource;
    public GameObject planet;
    private bool scalePlanet;
    public float scaleHeight;
    private Vector3 oldScale;
    private Vector3 newScale;
    public GameObject water;
    public bool cloudReady;
    // Use this for initialization
    void Start () {
        lightSource = this.GetComponent<Light>();
        lightSource.enabled = false;
        scalePlanet = false;
        cloudReady = false;
        oldScale = new Vector3(planet.transform.localScale.x,
        planet.transform.localScale.y, planet.transform.localScale.z);
        newScale = new Vector3(planet.transform.localScale.x + scaleHeight,
        planet.transform.localScale.y + scaleHeight, planet.transform.localScale.z + scaleHeight);

        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind + 1) {
            Destroy(gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (joycons.Count > 0) {
            Joycon j = joycons[jc_ind];
            if (j.GetButtonDown(Joycon.Button.HOME)) {
                lightSource.enabled = !lightSource.enabled;
                scalePlanet = !scalePlanet;

            }
        }

        //Light on
        if (scalePlanet && planet != null) {
            planet.transform.localScale = Vector3.Lerp(planet.transform.localScale, newScale, Time.deltaTime * 1 );
            water.transform.localScale = Vector3.Lerp(water.transform.localScale, oldScale, Time.deltaTime * 3);
            cloudReady = true;
        }
        if (!scalePlanet && planet != null) {
            planet.transform.localScale = Vector3.Lerp(planet.transform.localScale, oldScale, Time.deltaTime * 3);
            water.transform.localScale = Vector3.Lerp(water.transform.localScale, newScale, Time.deltaTime * 1);
            cloudReady = false;


        }
    }
}
