using UnityEngine;
using System.Collections;
using MyEnumSpace;

[System.Serializable]
public class Item : MonoBehaviour, IEquippable {

	public string name;
	public string description;
	//public float cost;
	public int itemID;
	public ItemType itemType;

	public Color clothesColor;

	void Start()
	{
		name = gameObject.name;
	}

	public Item(ItemType it)
	{
		this.itemType = it;
	}

	public void Equip(Item item)
	{

	}

	public void GiveItemName(string name)
	{
		this.name = name;
	}
}
