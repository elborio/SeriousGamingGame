using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	public Dictionary<int,Item> inventoryItems;
	public Dictionary<int,Item> equippedItems;

	public GameObject shirt;

	//gameobject that hold the visual inventoryItems.
	public GameObject inventoryCanvas;
	public GameObject equipmentCanvas;
	public GameObject itemVisualHolder;


	ItemDatabase itemDatabase;

	void Start()
	{
		itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();

		equippedItems = new Dictionary<int,Item>();
		inventoryItems = new Dictionary<int,Item>();

		SetEquippedItemEffects();
		RefreshInventoryVisuals();
	}

	public void AddItemToInventory(Item it)
	{
		inventoryItems.Add(it.itemID,it);
		itemDatabase.items.Add (it);
	}

	public void AddItemToInventory(int itemID)
	{
		Item i = itemDatabase.items[itemID];
		inventoryItems.Add(i.itemID, i);
		AddLatestItemVisual();
	}


	public void SetEquippedItemEffects()
	{
		foreach(Item i in equippedItems.Values)
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
		foreach(Item i in inventoryItems.Values)
		{
			GameObject temp = Instantiate(itemVisualHolder) as GameObject;
			ItemVisual iui = temp.GetComponent<ItemVisual>();
			iui.name.text = i.name;

			temp.transform.SetParent(inventoryCanvas.transform,false);
		}
	}

	public void AddLatestItemVisual()
	{
		Item i = inventoryItems[inventoryItems.Count-1];
		GameObject temp = Instantiate(itemVisualHolder) as GameObject;
		ItemVisual iui = temp.GetComponent<ItemVisual>();
		iui.name.text = i.name;
		iui.description.text = i.description;
		
		temp.transform.SetParent(inventoryCanvas.transform,false);
	}

	public void RefreshEquippedVisuals()
	{
		foreach(Item i in equippedItems.Values)
		{
			GameObject temp = Instantiate(itemVisualHolder) as GameObject;
			ItemVisual iui = temp.GetComponent<ItemVisual>();
			iui.name.text = i.name;
			
			temp.transform.SetParent(equipmentCanvas.transform,false);
		}
	}

	public void EquipItem(int itemID)
	{
		equippedItems.Add(itemID,inventoryItems[itemID]);
		RefreshEquippedVisuals();
	}

	public void DequipItem(int itemID)
	{
		equippedItems.Remove(itemID);
		RefreshEquippedVisuals();
	}
}
