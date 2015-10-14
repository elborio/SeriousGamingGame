using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {
    public NavMeshAgent nma;
    public GameObject player;
	// Use this for initialization
	void Start () {
        nma.SetDestination(player.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        nma.SetDestination(player.transform.position);
        Debug.Log(nma.destination);
    }
}
