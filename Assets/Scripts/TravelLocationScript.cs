using UnityEngine;
using System.Collections;

public class TravelLocationScript : MonoBehaviour 
{

	public int sceneIndex; // scene to load when selected. TODO: Put scene index of island to open here!. (check build settings to see which one it is)

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawCube(transform.position,new Vector3(1,1,1));
	}
}
