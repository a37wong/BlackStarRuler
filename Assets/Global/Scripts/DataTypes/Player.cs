using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player : MonoBehaviour
{
	public ArrayList solarSystemIds;
	public Hashtable resources; //good id to amount

	public Player()
	{
		this.solarSystemIds = new ArrayList();
	}
}
