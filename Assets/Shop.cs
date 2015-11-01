using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shop : MonoBehaviour 
{
	public int[] itemDatabaseIDs;
	public GameObject itemUIList;
	public GameObject shopVisual;
	ItemDatabase IDB;
	public List<Item> items;

	void Start()
	{
		items = new List<Item>();

		IDB = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
		FillShop();
		CreateVisuals();
	}
	void FillShop()
	{
		foreach(int i in itemDatabaseIDs)
		{
			print ("key: "+i);
			items.Add(IDB.GetPrefab(i));
		}
	}

	void CreateVisuals()
	{
		foreach(Item i in items)
		{
			GameObject itemVisual = Instantiate (shopVisual);
			ShopItem shopItemData = itemVisual.GetComponent<ShopItem>();
			shopItemData.item = i;
			shopItemData.itemCost = 50.0f;
			shopItemData.transform.SetParent(itemUIList.transform,false);
		}
	}

}
