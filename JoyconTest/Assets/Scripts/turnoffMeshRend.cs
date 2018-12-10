using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnoffMeshRend : MonoBehaviour {

    private List<Joycon> joycons;
    public int jc_ind = 0;
    public GameObject ball;
    public Transform transformReset;
    public bool stayAtPos;
    // Use this for initialization
    void Start () {
        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind + 1) {
            Destroy(gameObject);
        }
        stayAtPos = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (joycons.Count > 0) {
            Joycon j = joycons[jc_ind];
            if (j.GetButtonDown(Joycon.Button.PLUS)) {
                stayAtPos = !stayAtPos;
            }
            if (!stayAtPos) {
                this.GetComponent<MeshRenderer>().enabled = true;
                ball.transform.position = transformReset.position;
                ball.GetComponent<Rigidbody>().isKinematic = true;
            }
            if (stayAtPos){
                this.GetComponent<MeshRenderer>().enabled = false;
                ball.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        }
}
