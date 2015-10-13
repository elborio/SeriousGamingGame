using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.tag == "Player")
        {
            Application.LoadLevel(4);
        }
    }
}
