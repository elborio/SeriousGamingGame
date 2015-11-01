using UnityEngine;
using System.Collections;
using MyEnumSpace;

[System.Serializable]
public class Item
{

	public string name;
	public string description;
	//public float cost;
	public int itemID;
	public int itemDatabaseID; //basis prefab
	public ItemType itemType;

	public Color clothesColor;

	public Item(Item item) //Copy Constructor.
	{
		this.name = item.name;
		this.description = item.description;
		this.itemType = item.itemType;
		this.itemDatabaseID = item.itemDatabaseID;
		this.clothesColor = item.clothesColor;
		this.itemID = ItemDatabase.GetUniqueID (this);
	}

	public Item()
	{
		this.itemID = ItemDatabase.GetUniqueID (this);
	}

	public void GiveItemName(string name)
	{
		this.name = name;
	}
}
