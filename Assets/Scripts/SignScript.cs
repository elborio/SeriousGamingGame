using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SignScript : MonoBehaviour 
{
	public GameObject UI;
	void OnTriggerEnter(Collider c)
	{
		Debug.Log(c.tag);
		if(c.tag == "Player")
		{
			UI.SetActive(true);
		}
	}

	void OnTriggerExit(Collider c)
	{
		if(c.tag == "Player")
		{
			UI.SetActive(false);
		}
	}
}
