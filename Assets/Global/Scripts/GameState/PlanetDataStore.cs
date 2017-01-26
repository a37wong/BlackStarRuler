using System.Collections;
using System;
using UnityEngine;

[Serializable]
public class PlanetDataStore : MonoBehaviour
{
	public static PlanetDataStore control;

	private Hashtable planets;

	public PlanetDataStore()
	{
		planets = new Hashtable();
	}

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

	public void AddPlanet(int id, Planet planet)
	{
		planets.Add(id, planet);
	}

	public Planet GetPlanet(int id)
	{
		return (Planet)planets[id];
	}
}
