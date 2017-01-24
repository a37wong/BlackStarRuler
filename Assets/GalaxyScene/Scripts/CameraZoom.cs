using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
	private const float MAX_ZOOMED_OUT_SIZE = 30f;
	private const float MAX_ZOOMED_IN_SIZE = 15f;

	// Use this for initialization
	void Start () {
		//start camera off with most zoomed out state
		Camera.main.orthographicSize = MAX_ZOOMED_OUT_SIZE;
	}
	
	// Update is called once per frame
	void Update () {
		float mouseWheelAxisValue = Input.GetAxis ("Mouse ScrollWheel");
		float cameraZoomAdjustment = 0;

		if (mouseWheelAxisValue > 0f) {
			cameraZoomAdjustment = -1f;
		} 
		else if (mouseWheelAxisValue < 0f) {
			cameraZoomAdjustment = 1f;
		}

		if (Camera.main.orthographicSize + cameraZoomAdjustment > MAX_ZOOMED_OUT_SIZE) {
			Camera.main.fieldOfView = MAX_ZOOMED_OUT_SIZE;
		} 
		else if (Camera.main.orthographicSize + cameraZoomAdjustment < MAX_ZOOMED_IN_SIZE) {
			Camera.main.fieldOfView = MAX_ZOOMED_IN_SIZE;
		} else {
			Camera.main.orthographicSize += cameraZoomAdjustment;
		}			
	}
}
