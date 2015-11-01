using UnityEngine;
using System.Collections;

public class WorldItem : MonoBehaviour {

	public Item item;
	
	void Start()
	{
		ItemDatabase IDB = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
		ItemDatabase.GetUniqueID(item);//moet dit wel static zijn ???(A)

		IDB.RegisterItem(item); //TODO: move this to be done everytime unique id is requested in idb?
	}
	
	void OnMouseDown()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItemToInventory(item.itemID);
	}
}
