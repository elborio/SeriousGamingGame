﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

public class ItemVisual : MonoBehaviour {

	public Item item;
	public Text name;
	public Text description;


	Button b;

	void Start()
	{
		name.text = item.name;
		description.text = item.description;
		b = GetComponent<Button>();
		b.onClick.AddListener(TryEquip);
	}

	void TryEquip()
	{
		print ("Item Id: "+item.itemID+" is clicked");
	}
}
