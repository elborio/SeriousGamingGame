using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour 
{
	public List<Item> items;
	public List<Item> itemPresets;

	public int itemUniqueIDInc = 0;

	public int GetUniqueID(Item i)
	{
		i.itemID = itemUniqueIDInc;
		itemUniqueIDInc++;
		print (itemUniqueIDInc);
		return itemUniqueIDInc -1;
	}

	public Item GetPrefab(int i)
	{
		Item newItem = new Item(itemPresets[i]);
		items.Add(newItem);
		return newItem;
	}
}
