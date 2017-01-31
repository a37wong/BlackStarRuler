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
	public const int POPULATION_GROWTH_PROGRESS_MAX = 200;

	//values that are static to a planet
	public int width;
	public int height;
	public Resource[] resourcesAvailable;
	public int[,] terrain;

	//values that change as the game progresses
	public string name;
	public int playerId; //player who currently owns this planet
	public int population;
	public ConstructionQueueItem currProduction;
	public int currProductionTileId;
	public Hashtable labourAssignment; //good id to number of people
	public Hashtable productionProgress; //good id to progress
	public Hashtable buildings; //completed buildings on planet by tile id
	public int populationGrowthProgress;

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
		playerId = -1; //no owner
		population = 0;
		currProduction = new ConstructionQueueItem(-1, 0);
		currProductionTileId = -1;
		labourAssignment = new Hashtable();
		productionProgress = new Hashtable();
		buildings = new Hashtable();
	}

	public void endTurn()
	{
		Player ownerPlayer = (Player)PlayerDataStore.control.players[this.playerId];

		//population growth
		Resource[] foodTypes = ResourceTypes.control.foodResources;
		int foodEaten = 0;

		for (int i = 0; i < foodTypes.Length; i++)
		{
			int currFoodGoodId = foodTypes[i].id;
			int maxFoodToEat = Math.Max((int)ownerPlayer.resources[currFoodGoodId], this.population);

			foodEaten = foodEaten + maxFoodToEat;
			ownerPlayer.resources[currFoodGoodId] = (int)ownerPlayer.resources[currFoodGoodId] - maxFoodToEat;
		}

		if (foodEaten < this.population)
		{
			//insufficient food eaten, starvation is occurring
			int foodShortfall = this.population - foodEaten;
			this.populationGrowthProgress = this.populationGrowthProgress - foodShortfall;
		}
		else
		{
			populationGrowthProgress = populationGrowthProgress + foodEaten;
		}

		if (populationGrowthProgress > POPULATION_GROWTH_PROGRESS_MAX)
		{
			this.population = this.population + 1;
			this.populationGrowthProgress = this.populationGrowthProgress - POPULATION_GROWTH_PROGRESS_MAX;
			//todo: game event to alert player that population grew
		}

		//todo: money from consuming trade goods
	}
}
