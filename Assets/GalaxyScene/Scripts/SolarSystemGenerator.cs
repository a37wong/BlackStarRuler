using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemGenerator : MonoBehaviour {
	private static int numOfPlayers = 8;
	private int numOfSolarSystems = numOfPlayers * 3;
	private ArrayList listOfSolarSystem = new ArrayList();
	// Use this for initialization

	void Start () {		
		for (int i = 0; i < numOfSolarSystems; i++) {
			GameObject newSolarSystem = (GameObject) Instantiate(Resources.Load ("SolarSystem"));
			Vector3 randomPosition = new Vector3( 	Random.Range (-50f, 50f), 
													Random.Range(-25f, 25f), 
													0f );
			newSolarSystem.transform.position = randomPosition;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
