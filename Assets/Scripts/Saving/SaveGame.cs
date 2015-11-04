using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveGame 
{
	public List<Item> inventoryItems;
	public List<Item> equippedItems;
	public List<Item> itemDatabaseItems;
	
	public SaveGame(ItemDatabase idb,Inventory inv)
	{
		this.inventoryItems = inv.inventoryItems;
		this.equippedItems = inv.equippedItems;
		this.itemDatabaseItems = idb.items;
	}

}
