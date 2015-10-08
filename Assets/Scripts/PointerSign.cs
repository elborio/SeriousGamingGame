using UnityEngine;
using System.Collections;

public class PointerSign : SignScript
{
	public GameObject arrow,target;

	void Update()
	{
		//look at target game object (point at)
		arrow.transform.rotation = Quaternion.LookRotation(transform.position - target.transform.position);
	}

	void OnTriggerEnter(Collider c)
	{
		Debug.Log(c.tag);
		if(c.tag == "Player")
		{
			UI.SetActive(true);
			arrow.SetActive(true);
		}
	}
	
	void OnTriggerExit(Collider c)
	{
		if(c.tag == "Player")
		{
			Debug.Log("istherenot");
			UI.SetActive(false);
			arrow.SetActive(false);
		}
	}
}
