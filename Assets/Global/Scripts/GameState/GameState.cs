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
	public void endTurn()
	{
		//go through each player
		foreach (Player player in PlayerDataStore.control.players)
		{
			//add resources from each owned planet
			//food consumption and population growth on each owned planet
			//trade good consumption and money earned on each owned planet
		}
	}
}
