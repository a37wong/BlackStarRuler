using System.Collections;
using System;
using Random = UnityEngine.Random;

/**
 * 
 * This class stores the data of a planet
 * Terrain
 * Resources available
 * Buildings that have been built
 * People living on the planet
 * Labour Assignment per resource production
 * Production progress and partial progress
 * 
 */
[Serializable]
public class Planet
{
	//values that are static to a planet
	public int width;
	public int height;
	public Resource[] resourcesAvailable;
	public int[,] terrain;

	//values that change as the game progresses
	public string name;
	public int playerId; //player who currently owns this planet
	public int population;
	public Hashtable labourAssignment; //good id to number of people
	public Hashtable productionProgress; //good id to production hammers put in already

	/**
	 * This is used to initialize a planet to some values
	 */
	//todo: introduce more planet types
	public void randomizePlanet(int width, int height)
	{
		this.width = width;
		this.height = height;

		//there's always three types of raw resources on a planet
		//one food, one metal, one special
		Resource food = ResourceTypes.control.foodResources[Random.Range(0, ResourceTypes.control.foodResources.Length)];
		Resource metal = ResourceTypes.control.metalResources[Random.Range(0, ResourceTypes.control.metalResources.Length)];
		Resource special = ResourceTypes.control.specialResources[Random.Range(0, ResourceTypes.control.specialResources.Length)];

		this.resourcesAvailable = new Resource[] { food, metal, special };

		//set the terrain tiles		
		this.terrain = new int[width, height];
		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				//todo: have some real terrain generation, bonuses etc
				//todo: how to know the proper terrain id range?
				terrain[x, y] = Random.Range(0, 2);
			}
		}

		//reset the dynamic parameters of a planet
		name = "";
		playerId = 0; //no owner
		population = 0;
		labourAssignment = new Hashtable();
		productionProgress = new Hashtable();
	}
}
