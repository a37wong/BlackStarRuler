using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTypes : MonoBehaviour
{
	public static BuildingTypes control;

	public Building[] buildingTypes;
	
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

	//todo: pull the list from some kind of ini file
	public void init()
	{
		//this is currently hard coded for testing purposes
		Building farm = new Building("Farm", 120);

		buildingTypes = new Building[] { farm };
	}
}
