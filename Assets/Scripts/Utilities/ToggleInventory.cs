using UnityEngine;
using System.Collections;

public class ToggleInventory : MonoBehaviour 
{
	public GameObject panel;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
			if(panel.activeSelf)
			{
				panel.SetActive(false);
			}
			else
			{
				panel.SetActive(true);
			}
		}
	}

}
