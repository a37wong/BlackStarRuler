using System;
using UnityEngine;

[Serializable]
public class Unit
{
	//basic stats
	public string name;
	public int health;
	public int attack;

	//dynamic stats
	public int experience;
	public int level;
}
