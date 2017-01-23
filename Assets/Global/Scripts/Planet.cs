using System;

/**
 * 
 * This class stores the data of a planet
 * Terrain
 * Resources available
 * Buildings that have been built
 * People living on the planet
 * Labour Assignment per resource production
 * Production progress and partial progress
 * 
 */
[Serializable]
public class Planet
{
	public int width;
	public int height;

	public Planet()
	{
		//todo: code a real constructor
		width = 5;
		height = 5;
	}
}
