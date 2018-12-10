using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOEmitter : MonoBehaviour {
    private List<Joycon> joycons;
    public int jc_ind = 0;
    public GameObject GO;
    public float xForce;
    public float yForce;
    public float zForce;
    public float timeIbt;
    private float originalTimeIbt;
    public bool noButton;
	// Use this for initialization
	void Start () {
        originalTimeIbt = timeIbt;
        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind + 1) {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (joycons.Count > 0) {
            Joycon j = joycons[jc_ind];
            if (j.GetButton(Joycon.Button.PLUS) || noButton) {
                Debug.Log("wATERFAL");
                timeIbt -= Time.deltaTime;
                if (timeIbt <= 0){
                    GameObject newGO;
                    Vector3 spawn;
                    spawn = new Vector3(Random.Range(-1f,1f)+transform.position.x, Random.Range(-1f, 1f)*0.1f + transform.position.y, Random.Range(-1f, 1f) + transform.position.z);
                    newGO = Instantiate(GO);
                    newGO.SetActive(true);
                    newGO.transform.position = spawn;
                    newGO.transform.rotation = this.transform.rotation;
                    timeIbt = originalTimeIbt;
                }

            }
        }


        
	}
}
