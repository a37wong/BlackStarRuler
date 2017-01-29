using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player : MonoBehaviour
{
	ArrayList SolarSystemIds;

	public Player()
	{
		this.SolarSystemIds = new ArrayList();
	}
}
