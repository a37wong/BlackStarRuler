using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class manages generating the tiles that make up the planet board
 *  
 */
public class PlanetBoardGenerator : MonoBehaviour
{
	public int CameraZeroPointOffsetX = 0;
	public int CameraZeroPointOffsetY = 0;
	private Planet currPlanet;

	private int[,] terrainTileChoice;
	private int[,] buildingChoice;

	//Prefabs
	public GameObject[] terrainTiles;
	public GameObject[] buildingTiles;

	void initializeTiles()
	{
		terrainTileChoice = new int[currPlanet.width, currPlanet.height];
		buildingChoice = new int[currPlanet.width, currPlanet.height];

		for (int y = 0; y < currPlanet.height; y++)
		{
			for (int x = 0; x < currPlanet.width; x++)
			{
				//choose the stuff to draw on each tile, the terrain and building				
				terrainTileChoice[x,y] = currPlanet.terrain[x,y];

				if (currPlanet.buildings.ContainsKey(x + y * currPlanet.height))
				{
					buildingChoice[x, y] = (int)currPlanet.buildings[x + y * currPlanet.height];
				}
			}
		}
	}

	// Draw the actual planet board
	public void setupScene(int planetId)
	{
		currPlanet = PlanetDataStore.control.GetPlanet(planetId);
		initializeTiles();

		Quaternion rotation = new Quaternion();
		rotation.SetLookRotation(new Vector3(0f, 1f, 0f));

		for (int y = 0; y < currPlanet.height; y++)
		{
			for (int x = 0; x < currPlanet.width; x++)
			{
				GameObject terrainTileToDraw = terrainTiles[terrainTileChoice[x,y]];
				PlanetTile planetTile = (PlanetTile)terrainTileToDraw.GetComponent<MonoBehaviour>();
				planetTile.tileId = x + y * currPlanet.width;
				
				Instantiate(terrainTileToDraw, new Vector3(x + CameraZeroPointOffsetX, y + CameraZeroPointOffsetY, 0f), rotation);

				if (currPlanet.buildings.ContainsKey(x + y * currPlanet.height))
				{
					GameObject buildingToDraw = buildingTiles[buildingChoice[x, y]];					
					Instantiate(buildingToDraw, new Vector3(x + CameraZeroPointOffsetX, y + CameraZeroPointOffsetY, 0f), rotation);
				}
			}
		}
	}
}
