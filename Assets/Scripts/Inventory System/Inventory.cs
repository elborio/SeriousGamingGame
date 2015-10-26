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
		Item temp = itemDatabase.items[0].GetComponent<Item>();
		//temp.GiveItemName("Henk");
		inventoryItems.Add(temp);

		//equippedItems.Add(inventoryItems[0]);

		SetEquippedItemEffects();
		CreateInventoryVisuals();
	}

	public void AddItemToInventory(Item it)
	{
		inventoryItems.Add(it);
	}
	public void AddItemToInventory(int itemID)
	{
		inventoryItems.Add(itemDatabase.items[itemID].GetComponent<Item>());
		AddLatestItemVisual();
	}


	public void SetEquippedItemEffects()
	{
		foreach(Item i in equippedItems)
		{

			if(i.itemType == MyEnumSpace.ItemType.shirt && i.clothesColor!=Color.black)
			{
				shirt.GetComponent<SkinnedMeshRenderer>().material.color = i.clothesColor;
				//print ("done do");
			}
		}
	}

	public void CreateInventoryVisuals()
	{
		foreach(Item i in inventoryItems)
		{
			GameObject temp = Instantiate(itemVisualHolder) as GameObject;
			ItemUI iui = temp.GetComponent<ItemUI>();
			iui.name.text = i.name;

			temp.transform.SetParent(inventoryCanvas.transform,false);
		}
	}

	public void AddLatestItemVisual()
	{
		Item i = inventoryItems[inventoryItems.Count-1];
		GameObject temp = Instantiate(itemVisualHolder) as GameObject;
		ItemUI iui = temp.GetComponent<ItemUI>();
		iui.name.text = i.name;
		iui.description.text = i.description;
		
		temp.transform.SetParent(inventoryCanvas.transform,false);
	}

	public void CreateEquipmentVisual()
	{
		foreach(Item i in equippedItems)
		{
			GameObject temp = Instantiate(itemVisualHolder) as GameObject;
			ItemUI iui = temp.GetComponent<ItemUI>();
			iui.name.text = i.name;
			
			temp.transform.SetParent(equipmentCanvas.transform,false);
		}
	}

	public void EquipItem(int itemId)
	{
		//inventoryItems[0].gameObject.name;
	}
}
