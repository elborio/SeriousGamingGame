using UnityEngine;
using System.Collections;

public class MovePlayerToSpawn : MonoBehaviour {

	void Start()
	{
		GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;
	}
}
