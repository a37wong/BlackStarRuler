using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class stores all the resource types (like "wheat" or "copper ore") in the game
 * and makes it accessible for other classes to use.
 * 
 * It also initializes the list of resources and should be used for the main game state
 * controller to instantiate all the resources at the beginning.
 */
public class ResourceTypes : MonoBehaviour
{
	public static ResourceTypes control;

	//todo: use an init file for special values?
	public const int MONEY_GOOD_ID = 100;
	public const int PRODUCTION_GOOD_ID = 200;

	public Resource[] resourceTypes;
	public Resource[] foodResources;
	public Resource[] metalResources;
	public Resource[] specialResources;

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
		Resource wheat = new Resource(0, "Wheat", Resource.ResourceType.Food);
		Resource iron = new Resource(1, "Iron", Resource.ResourceType.Metal);
		Resource uranium = new Resource(2, "Uranium", Resource.ResourceType.Special);
		Resource tools = new Resource(3, "Tools", Resource.ResourceType.Trade);
		Resource bulkhead = new Resource(4, "Bulkheads", Resource.ResourceType.Military);

		resourceTypes = new Resource[] { wheat, iron, uranium, tools, bulkhead };
		foodResources = new Resource[] { wheat };
		metalResources = new Resource[] { iron };
		specialResources = new Resource[] { uranium };
	}	
}
