/**
 * A type of resource in the game like "wheat" or "iron ore"
 * 
 */
public class Resource {
	public enum ResourceType {
		Food,
		Metal,
		Special,
		Trade,
		Military
	};

	public int id;
	public string name;
	public ResourceType type;
	
	public Resource(int id, string name, ResourceType type)
	{
		this.id = id;
		this.name = name;
		this.type = type;
	}
}
