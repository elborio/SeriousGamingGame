using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{

	public List<Item> inventoryItems;
	public List<Item> equippedItems;

	public GameObject shirt;

	//gameobject that hold the visual inventoryItems.
	public GameObject inventoryCanvas;
	public GameObject equipmentCanvas;
	public GameObject itemVisualHolder;


	ItemDatabase itemDatabase;

	void Start()
	{
		itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();

		equippedItems = new List<Item>();
		inventoryItems = new List<Item>();

		SetEquippedItemEffects();
		RefreshInventoryVisuals();
	}

	public void AddItemToInventory(Item it)
	{
		inventoryItems.Add(it);
		CreateNewInventoryVisual(it);
	}

	public void AddItemToInventory(int itemID)
	{
		Item i = itemDatabase.items[itemID];
		inventoryItems.Add(i);
		CreateNewInventoryVisual(i);
	}


	public void SetEquippedItemEffects()
	{
		foreach(Item i in equippedItems)
		{
			//do this for each shirt that is equipped.
			if(i.itemType == MyEnumSpace.ItemType.shirt && i.clothesColor!=Color.black)
			{
				shirt.GetComponent<SkinnedMeshRenderer>().material.color = i.clothesColor;
				//print ("done do");
			}
		}
	}

	public void RefreshInventoryVisuals()
	{
		//TODO:add new objects for all (should delete children first and just be called InitializeInventoryVisuals)
		foreach(Item i in inventoryItems)
		{
			GameObject temp = Instantiate(itemVisualHolder) as GameObject;
			ItemVisual iui = temp.GetComponent<ItemVisual>();
			iui.item = i;

			temp.transform.SetParent(inventoryCanvas.transform,false);
		}
	}

	public void AddLatestItemVisual() //dunno what this did.
	{
		Item i = inventoryItems[inventoryItems.Count-1];
		GameObject temp = Instantiate(itemVisualHolder) as GameObject;
		ItemVisual iui = temp.GetComponent<ItemVisual>();
		iui.item = i;
		
		temp.transform.SetParent(inventoryCanvas.transform,false);
	}

	public void RefreshEquippedVisuals()
	{
		foreach(Item i in equippedItems)
		{
			GameObject temp = Instantiate(itemVisualHolder) as GameObject;
			ItemVisual iui = temp.GetComponent<ItemVisual>();
			iui.item = i;
			
			temp.transform.SetParent(equipmentCanvas.transform,false);
		}
	}

	public void CreateNewInventoryVisual(Item i)
	{
		GameObject temp = Instantiate(itemVisualHolder) as GameObject;
		ItemVisual iui = temp.GetComponent<ItemVisual>();
		iui.item = i;
		temp.transform.SetParent(inventoryCanvas.transform,false);
	}

	public void EquipItem(int itemID)
	{
		equippedItems.Add(inventoryItems[itemID]);

	}

	public void DequipItem(int itemID)
	{
		equippedItems.Remove(equippedItems[itemID]);
	}
}
