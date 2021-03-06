﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class is used for any information you want to store for the planet scene to consume when transitioning to it
 */
public class PlanetMapStateTransition : MonoBehaviour {
	public static PlanetMapStateTransition control;

	//this controls what planet the PlanetMapManager is going to display when you transition to planet scene
	public int planetId;

	//this controls who is viewing the planet
	//which determines whether the person can do anything in this screen to modify the planet
	public int playerId;

	// Use this for initialization
	void Awake()
	{
		if (null == control)
		{
			DontDestroyOnLoad(gameObject);
			control = this;
		}
		else if (control != this)
		{
			Destroy(gameObject);
		}
	}
}
