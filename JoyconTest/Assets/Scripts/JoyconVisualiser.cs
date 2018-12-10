using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconVisualiser : MonoBehaviour {

    private void Update() {
        if (transform.GetComponentInParent<JoyconV2>().j.GetButton(Joycon.Button.DPAD_UP)) {
            transform.localPosition -= new Vector3(0, 0.1f, 0);
        } 
        if (transform.GetComponentInParent<JoyconV2>().j.GetButton(Joycon.Button.DPAD_DOWN)) {
            transform.localPosition += new Vector3(0, 0.1f, 0);
        }
        
    }
}
