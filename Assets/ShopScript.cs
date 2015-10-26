using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopScript : MonoBehaviour 
{
	public GameObject UI;
	public GameObject shopViewPos;

	bool isViewing;

	Camera mainCam;

	void Start()
	{
		mainCam = Camera.main;
		UI.SetActive(false);
	}

	void FixedUpdate()
	{
		if(isViewing)
		{
			mainCam.transform.position = Vector3.Lerp(mainCam.transform.position,shopViewPos.transform.position,5 *Time.deltaTime);
			mainCam.transform.LookAt(UI.transform);
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "Player")
		{
			mainCam.GetComponent<CameraFollow>().enabled = false;
			UI.SetActive(true);
			isViewing = true;
		}
	}

	void OnTriggerExit(Collider c)
	{
		if(c.tag == "Player")
		{
			mainCam.GetComponent<CameraFollow>().enabled = true;
			UI.SetActive(false);
			isViewing = false;
		}
	}
}
