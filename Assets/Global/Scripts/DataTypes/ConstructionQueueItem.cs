using System;

[Serializable]
public class ConstructionQueueItem
{
	public int goodId; //either an item or a building
	public int progress; //how many hammers have been put into this item already

	public ConstructionQueueItem(int goodId, int progress)
	{
		this.goodId = goodId;
		this.progress = progress;
	}
}
