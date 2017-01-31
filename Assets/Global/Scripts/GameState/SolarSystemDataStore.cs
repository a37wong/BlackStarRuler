using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemDataStore : MonoBehaviour
{
	public static SolarSystemDataStore control;

	private Hashtable solarSystems = new Hashtable();

	public SolarSystemDataStore()
	{
		solarSystems = new Hashtable();
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

	public SolarSystem getSolarSystem(int id)
	{
		return (SolarSystem)solarSystems[id];
	}
}
