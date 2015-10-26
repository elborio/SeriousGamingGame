using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TravelScript : MonoBehaviour 
{
	public GameObject[] travelLocations;

	public float camMoveSpeed;
	public float camHeight;

	public Canvas mainUI;

	int currentLocation = 1;
	public bool isEngaged = false;
	bool playerCanEngage = false; //Check if player is near.
	bool isResettingEngage = false;
	Vector3 lastCameraPosition;
	Quaternion lastCameraRotation;

	//int locationAmount; //variable to keep track of how many islands (travel locations) there are. (Obsolete? use travellocations.lentgh?)
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.E) && playerCanEngage && !isEngaged)
		{
			lastCameraPosition = Camera.main.transform.position;
			lastCameraRotation= Camera.main.transform.rotation;
			//TODO:disable all scripts on player so you can move and camera isnt conflicted. KINDA WORKS ALREADY NOW
			DisableAllCameraScripts();
			//for now it just uses last known cameraposition toset camera back after player is done using.
			isEngaged = true;
		}
		else if(Input.GetKeyDown(KeyCode.E) && isEngaged)
		{
			isResettingEngage = true;
		}

		if(isEngaged && !isResettingEngage) //Everything that is done while engaged with the travel system. ------------------------IMPORTANT!!!!
		{
			//move camera to hang above currentlocation transform

			Camera.main.transform.rotation = Quaternion.LookRotation(Vector3.down);
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position,travelLocations[currentLocation-1].transform.position + new Vector3(0,camHeight,0),Time.deltaTime * camMoveSpeed);

			if(Input.GetKeyDown(KeyCode.A))
			{
				if(currentLocation > 1)
				{
					currentLocation--;
				}
			}
			if(Input.GetKeyDown(KeyCode.D))
			{
				if(currentLocation <= travelLocations.Length-1)
				{
					currentLocation++;
				}
			}
			if(Input.GetKeyDown(KeyCode.Return))
			{
				LoadLevelForLocationIndex(currentLocation);
			}
		}
	
		if(isResettingEngage)
		{
			ResetEngage(); //function that makes sure the cam is availeble again after exiting.
		}
	}

	void ResetEngage()
	{ 
		//smoothly transition back to last camera position then when camera is close to that point again stop being engaged to the travel system.
		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,lastCameraPosition,Time.deltaTime * camMoveSpeed);
		Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation,lastCameraRotation,Time.deltaTime * camMoveSpeed);
		float distanceBetweenCamAndLastKnownPos = Vector3.Distance(Camera.main.transform.position,lastCameraPosition);
		if(distanceBetweenCamAndLastKnownPos <1)
		{
			isEngaged = false;
			isResettingEngage = false;
			EnableAllCameraScripts();
		}
	}

	void DisableAllCameraScripts()
	{
		Camera.main.GetComponent<CameraFollow>().enabled = false;
	}
	void EnableAllCameraScripts()
	{
		Camera.main.GetComponent<CameraFollow>().enabled = true;
	}

	void LoadLevelForLocationIndex(int locationMarkerIndex)
	{
		int sceneIndex = travelLocations[locationMarkerIndex-1].GetComponent<TravelLocationScript>().sceneIndex;
		if(sceneIndex!=-1)
		{
			EnableAllCameraScripts();
			Application.LoadLevel(sceneIndex);
		}
		else
		{
			Debug.Log("Selected Island Not Available");
			mainUI.GetComponent<UIController>().ShowPopupMessage("Selected Island Not Available");
		}
	}

	//This trigger checks if the player is engaging the travel.
	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "Player")
		{
			playerCanEngage = true;
			mainUI.gameObject.SetActive(true);
			mainUI.GetComponent<UIController>().ShowPopupMessage("Press E to Select an Island, then use Enter to Travel and A and D to cycle between islands.");
		}
	}

	void OnTriggerExit(Collider c)
	{
		if(c.tag == "Player")
		{
			playerCanEngage = false;
		}
	}

}
