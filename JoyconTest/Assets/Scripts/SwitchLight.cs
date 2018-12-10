using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour {
    private Light lightSource;
    private List<Joycon> joycons;
    public int jc_ind = 0;
    // Use this for initialization
    void Start () {
        lightSource = this.GetComponent<Light>();
        lightSource.enabled = false;
        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind + 1) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        if (joycons.Count > 0) {
            Joycon j = joycons[jc_ind];
            if (j.GetButtonDown(Joycon.Button.HOME)) {
                lightSource.enabled = !lightSource.enabled;
            }
        }
    }
}
