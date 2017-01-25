using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {
	private float minXBound = Screen.width * .1f;
	private float maxXBound = Screen.width * .9f;
	private float minYBound = Screen.height * .9f;
	private float ScrollSpeed = 60f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.mousePosition.y >= Screen.height * 0.95 && this.gameObject.transform.position.y <= 30) {
			transform.Translate (Vector3.up * Time.deltaTime * ScrollSpeed, Space.World);
		} 
		else if (Input.mousePosition.y <= Screen.height * 0.05 && this.gameObject.transform.position.y >= -30) {
			transform.Translate (Vector3.down * Time.deltaTime * ScrollSpeed, Space.World);
		}
		if (Input.mousePosition.x <= Screen.width * 0.05 && this.gameObject.transform.position.x >= -50) {
			transform.Translate (Vector3.left * Time.deltaTime * ScrollSpeed, Space.World);
		}
		else if (Input.mousePosition.x >= Screen.width * 0.95 && this.gameObject.transform.position.x <= 50) {
			transform.Translate (Vector3.right * Time.deltaTime * ScrollSpeed, Space.World);
		}
	}
}
