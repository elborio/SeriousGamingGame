using UnityEngine;
using System.Collections;

public class BillboardWorldspaceUI : MonoBehaviour {

	Camera mainCam;

	void Start () 
	{
		mainCam = Camera.main;
	}
	
	void Update()
	{
		transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position);
	}
}
