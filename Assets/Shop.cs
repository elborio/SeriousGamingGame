using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shop : MonoBehaviour 
{
	public int[] itemDatabaseIDs;
	ItemDatabase IDB;
	public List<Item> items;

	void Start()
	{
		items = new List<Item>();

		IDB = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
		FillShop();
	}
	void FillShop()
	{
		foreach(int i in itemDatabaseIDs)
		{
			items.Add(IDB.GetPrefab(i));
		}
	}

}
