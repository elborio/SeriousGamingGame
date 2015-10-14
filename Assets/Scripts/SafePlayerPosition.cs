using UnityEngine;
using System.Collections;

public class SafePlayerPosition : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
        if (IsSet())
        {
            player.transform.position = GetPlayerPosition();
        }
	}
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
        PlayerPrefs.SetFloat("isset", 1.0F);
    }
    public Vector3 GetPlayerPosition()
    {
        return new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("Playerz"));
    }
    public bool IsSet()
    {
        return PlayerPrefs.GetFloat("isset") == 1.0F;
    }
}
