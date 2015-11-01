using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour 
{
	public List<Item> items;
	public List<Item> itemPresets; //Unique ID, returns the item connected. (Could have done search but might get slow with high itme amounts.

	public static int itemUniqueIDInc = 0;

	void Awake()
	{
		items = new List<Item>();
		itemUniqueIDInc = 0;
		print("item Unique Id Start: "+itemUniqueIDInc);
	}

	public static int GetUniqueID(Item i)
	{
		i.itemID = itemUniqueIDInc;
		itemUniqueIDInc++;
		print ("Get unique ID called: "+itemUniqueIDInc);
		return itemUniqueIDInc -1;
	}

	public Item GetPrefab(int i)
	{
		Item newItem = new Item(itemPresets[i]);
		items.Add(newItem);
		return newItem;
	}

	public void RegisterItem(Item item)
	{
		items.Add(item);
	}
}
