using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTile : MonoBehaviour
{
	public int tileId;

	public PlanetTile(int id)
	{
		tileId = id;
	}

	void OnMouseUp()
	{
		PlanetMapManager.control.planetTileSelect_onClick(tileId);
	}
}
