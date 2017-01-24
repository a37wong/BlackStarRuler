using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 * This class is for handling the scene creation and changes
 * 
 */
public class PlanetMapManager : MonoBehaviour
{
	public static PlanetMapManager control;

	private PlanetBoardGenerator boardGenerator;

	public PlanetMapManager()
	{		
	}

	// Use this for initialization
	void Awake()
	{
		if (null == control)
		{
			DontDestroyOnLoad(gameObject);
			control = this;

			boardGenerator = GetComponent<PlanetBoardGenerator>();
		}
		else if (control != this)
		{
			Destroy(gameObject);
		}
	}

	// todo: remove test function
	private void Start()
	{
		//init game as if this were the game state manager
		ResourceTypes.control.init();

		//make some planets as if it were a new game
		Planet testPlanet = new Planet();
		testPlanet.randomizePlanet(5, 5);
		PlanetDataStore.control.AddPlanet(1, testPlanet);

		//draw the scene as if the player clicked into planet with id 1
		PlanetMapStateTransition.control.planetId = 1;
		InitPlanetMap();
	}

	public void InitPlanetMap()
	{
		int planetId = PlanetMapStateTransition.control.planetId;
		boardGenerator.setupScene(planetId);
	}
}
