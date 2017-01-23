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
		InitPlanetMap();
	}

	public void InitPlanetMap()
	{
		boardGenerator.setupScene(1);
	}
}
