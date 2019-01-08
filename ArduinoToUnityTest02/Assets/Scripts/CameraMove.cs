using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    
    public float mouseSensitivity;
    public float zoomSensitivity;

    public float mouseX;
    public float mouseY;

    public bool debugMode = false;

    public Vector3 addToPosition;
    public Vector3 destPosition;

    public float smoothing;

    private void Start() {
        destPosition = transform.position;
    }
    // Update is called once per frame
    void Update () {
        Cursor.lockState = CursorLockMode.Locked;
        if (!debugMode) {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
            addToPosition = new Vector3(mouseX, mouseY, Input.mouseScrollDelta.y * zoomSensitivity);
        } else if (debugMode) {
            mouseX = Input.GetAxis("Horizontal");
            mouseY = Input.GetAxis("Vertical");
            addToPosition = new Vector3(mouseX, mouseY, GetZoomInt() * zoomSensitivity);
        }
        destPosition += addToPosition * Time.deltaTime * mouseSensitivity;
        transform.position = Vector3.Lerp(transform.position, destPosition, Time.deltaTime * smoothing);
	}

    int GetZoomInt() {
        if (Input.GetButton("B Button")) {
            return 1;
        } else if (Input.GetButton("A Button")) {
            return -1;
        } else return 0;
    }
}
