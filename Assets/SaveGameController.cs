using UnityEngine;
using System.Collections;
using System.IO;

public class SaveGameController : MonoBehaviour {
	SaveGame save;
	ItemDatabase itemDatabase;
	Inventory inventory;

	void Start()
	{
		itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		if(File.Exists(Application.persistentDataPath+"/saveGame.serious"))
		{
			print("SaveGame Exists");
			save = SaveLoad.Load();
			itemDatabase.items = save.itemDatabaseItems;
			inventory.inventoryItems = save.inventoryItems;
			inventory.equippedItems = save.equippedItems;
			//inventory.RefreshInventoryVisuals();
			//inventory.RefreshEquippedVisuals();
		}
	}

	void OnApplicationQuit()
	{

		save = new SaveGame(itemDatabase,inventory);
		SaveLoad.Save(save);
	}
}
