using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRotate : MonoBehaviour {
    private List<Joycon> joycons;
    public int button;
    public int jc_ind = 0;
    private Quaternion orientation;
    [SerializeField]
    private Vector3 orientationXYZ;
    [SerializeField]
    private float oldRot;
    public float orientationX;
    public float OrientationZ;
    void Start () {
        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind + 1) {
            Destroy(gameObject);
        }
        orientationXYZ = transform.localRotation.eulerAngles;
        orientationX = orientationXYZ.x;
        OrientationZ = orientationXYZ.z;
    }

    // Update is called once per frame
    void Update() {
        if (joycons.Count > 0) {
            Joycon j = joycons[jc_ind];
            orientation = j.GetVector();
            orientation = Quaternion.Inverse(new Quaternion(orientation.x, orientation.z, orientation.y, orientation.w));
            orientationXYZ = orientation.eulerAngles;
            orientationXYZ = new Vector3(0, orientationXYZ.y, 0);
            if ((j.GetButton(Joycon.Button.DPAD_LEFT) && button == 0)||
                (j.GetButton(Joycon.Button.DPAD_UP) && button == 1)||
                (j.GetButton(Joycon.Button.DPAD_RIGHT) && button == 2)) {
                gameObject.transform.localRotation = Quaternion.Euler(orientationXYZ);
            }
            if ((j.GetButtonUp(Joycon.Button.DPAD_LEFT) && button == 0) ||
                (j.GetButtonUp(Joycon.Button.DPAD_UP) && button == 1) ||
                (j.GetButtonUp(Joycon.Button.DPAD_RIGHT) && button == 2)) {
            }
            
        }
    }
}
