using UnityEngine;
using System.Collections;

public class ShowCinematicDebugPanel : MonoBehaviour {

	public GameObject debugPanel;
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
			if(debugPanel.activeSelf)
			{
				debugPanel.SetActive(false);
			}
			else
			{
				debugPanel.SetActive(true);
			}
		}
	}
}
