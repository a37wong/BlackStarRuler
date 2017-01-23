using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class manages generating the tiles that make up the planet board
 *  
 */
public class PlanetBoardGenerator : MonoBehaviour
{
	private Planet currPlanet;

	private int[,] terrainTileChoice;
	private int[,] buildingChoice;

	//Prefabs
	public GameObject[] terrainTiles;
	public GameObject[] buildingTiles;

	void initializeTiles()
	{
		terrainTileChoice = new int[currPlanet.width, currPlanet.height];

		for (int z = 0; z < currPlanet.height; z++)
		{
			for (int x = 0; x < currPlanet.width; x++)
			{
				//choose the stuff to draw on each tile, the terrain and building
				//todo: make a proper choice of what kind of tile
				terrainTileChoice[x,z] = 0;
			}
		}
	}

	// Draw the actual planet board
	public void setupScene(int planetId)
	{
		currPlanet = PlanetDataStore.control.GetPlanet(planetId);
		initializeTiles();

		for (int z = 0; z < currPlanet.height; z++)
		{
			for (int x = 0; x < currPlanet.width; x++)
			{
				//todo: draw based on the planet's actual tiles
				GameObject terrainTileToDraw = terrainTiles[terrainTileChoice[x,z]];
				Instantiate(terrainTileToDraw, new Vector3(x, 0f, z), Quaternion.identity);
			}
		}
	}
}
