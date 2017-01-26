using System;
using UnityEngine;

[Serializable]
public class FighterSquadron : Unit
{
	public FighterSquadron()
	{
		this.name = "Fighter Squadron";
		this.health = 10;
		this.attack = 3;

		this.experience = 0;
		this.level = 0;
	}
}
