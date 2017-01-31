using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class holds all data for a particular play through
 * 
 * A separate class is used to initialize a GameState for a new game
 */
[Serializable]
public class GameState : MonoBehaviour
{
	public int resourcesPerLabourer = 5;

	public void endTurn()
	{
		//go through each player
		foreach (Player currPlayer in PlayerDataStore.control.players)
		{			
			ArrayList solarSystemIds = currPlayer.solarSystemIds;

			foreach(int solarSystemId in solarSystemIds)
			{
				SolarSystem currSystem = SolarSystemDataStore.control.getSolarSystem(solarSystemId);
								
				ArrayList planetIds = currSystem.planetIds;

				foreach(int planetId in planetIds)
				{
					Planet currPlanet = PlanetDataStore.control.getPlanet(planetId);

					IDictionaryEnumerator labourAssignmentEnumerator = currPlanet.labourAssignment.GetEnumerator();					

					while (labourAssignmentEnumerator.MoveNext())
					{
						DictionaryEntry labourAssignmentEntry = (DictionaryEntry)labourAssignmentEnumerator.Current;

						//add resources from each owned planet
						//todo: production based on the type of good produced
						int goodId = (int)labourAssignmentEntry.Key;
						int labourers = (int)labourAssignmentEntry.Value;
						int goodsProduced = labourers * resourcesPerLabourer;

						currPlayer.resources[goodId] = (int)currPlayer.resources[goodId] + goodsProduced;

						//food consumption and population growth on each owned planet
						//trade good consumption and money earned on each owned planet
						currPlanet.endTurn();
					}
				}
			}
		}
	}
}
