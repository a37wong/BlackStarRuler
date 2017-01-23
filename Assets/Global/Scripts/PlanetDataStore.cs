using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDataStore : MonoBehaviour
{
	public static PlanetDataStore control;

	private Hashtable planets;

	// Use this for initialization
	void Awake()
	{
		if (null == control)
		{
			DontDestroyOnLoad(gameObject);
			control = this;

			planets = new Hashtable();

			//todo: remove test data
			planets.Add(1, new Planet());
		}
		else if (control != this)
		{
			Destroy(gameObject);
		}
	}

	public void AddPlanet(int id, Planet planet)
	{
		planets.Add(id, planet);
	}

	public Planet GetPlanet(int id)
	{
		return (Planet)planets[id];
	}
}
