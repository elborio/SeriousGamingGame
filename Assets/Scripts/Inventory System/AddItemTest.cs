using UnityEngine;
using System.Collections;

public class AddItemTest : MonoBehaviour {

	Inventory inv;

	void Start()
	{
		inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}

	void OnMouseDown()
	{
		inv.AddItemToInventory(new Item(MyEnumSpace.ItemType.pants));
	}
}
