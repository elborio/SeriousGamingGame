using UnityEngine;
using System.Collections;

public class OnSpriteClick : MonoBehaviour {
    public TwentyFourGame TFG;
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        Debug.Log("Clicked" + GetComponent<SpriteRenderer>().name);
        TFG.spriteClick(GetComponent<SpriteRenderer>());
       
    }
}
