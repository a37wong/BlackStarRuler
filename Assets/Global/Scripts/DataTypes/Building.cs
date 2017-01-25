using System.Collections;
using System;
using UnityEngine;

[Serializable]
public class Building
{
	public string name;
	public int productionCost;

	public Building(string name, int productionCost)
	{
		this.name = name;
		this.productionCost = productionCost;
	}
}
