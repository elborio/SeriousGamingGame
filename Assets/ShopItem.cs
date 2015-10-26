using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour {

	public GameObject itemObject;
	Item item;

	public float itemCost;
	//public int itemId;

	public Text itemNameUI;
	public Text itemDescriptionUI;
	public Text itemCostUI;

	void Start()
	{
		item = itemObject.GetComponent<Item>();
		itemNameUI.text = item.name;
		itemDescriptionUI.text = item.description;
		itemCostUI.text = itemCost.ToString() + "G";
	}

	public void OnShopItemClicked()
	{
		Debug.Log(itemObject.name);
		//if player has enough money do this.
		Inventory inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		inv.AddItemToInventory(itemObject.GetComponent<Item>().itemID);
		Destroy(gameObject);
	}
}
