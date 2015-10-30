using UnityEngine;
using System.Collections;
using MyEnumSpace;

[System.Serializable]
public class Item: IEquippable {

	public string name;
	public string description;
	//public float cost;
	public int itemID;
	public int itemDatabaseID; //basis prefab
	public ItemType itemType;

	public Color clothesColor;

	public Item(ItemType it)
	{
		this.itemType = it;
	}

	public Item(Item item)
	{
		this.name = item.name;
		this.description = item.description;
		this.itemType = item.itemType;
		this.itemDatabaseID = item.itemDatabaseID;
		this.clothesColor = item.clothesColor;
		this.itemID = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>().GetUniqueID (this);
	}

	public Item()
	{
		itemID = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>().GetUniqueID (this);
	}

	public void Equip(Item item)
	{

	}

	public void GiveItemName(string name)
	{
		this.name = name;
	}
}
