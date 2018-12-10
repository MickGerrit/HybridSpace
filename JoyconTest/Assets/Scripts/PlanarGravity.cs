using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlanarGravity : MonoBehaviour {
    private Transform planetTarget;
    [SerializeField]
    private float forceAmount = 1000f;
    [SerializeField]
    private float gravityRadius = 10f;

    public Color gizmosColor;

    public string objectName;

    public Vector3 addForce;

    Vector3 targetDirection;
    
	// Use this for initialization
	void Start () {
        Physics.gravity = Vector3.zero;
        planetTarget = GameObject.Find(objectName).transform;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, planetTarget.position);

        targetDirection = planetTarget.position - transform.position;
        targetDirection = targetDirection.normalized;
        
        

        if (distance < gravityRadius) {
            GetComponent<Rigidbody>().AddForce(targetDirection * forceAmount * Time.deltaTime);
        }
	}

    private void OnDrawGizmos() {
        Gizmos.color = gizmosColor;
        Gizmos.DrawWireSphere(planetTarget.position, gravityRadius);
    }
}
