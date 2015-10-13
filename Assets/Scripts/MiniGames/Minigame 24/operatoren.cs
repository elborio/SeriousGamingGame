using UnityEngine;
using System.Collections;

public class operatoren : MonoBehaviour {
    public TwentyFourGame TFG;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        Debug.Log("Clicked");
        if (GetComponent<SpriteRenderer>().name.Equals("+"))
        { 
             TFG.selectOperator(TwentyFourGame.operators.PLUS);
        }
        else if (GetComponent<SpriteRenderer>().name.Equals("X"))
        {
            TFG.selectOperator(TwentyFourGame.operators.TIMES);
        }
        else if (GetComponent<SpriteRenderer>().name.Equals("-"))
        {
            TFG.selectOperator(TwentyFourGame.operators.MINUS);
        }
        else if (GetComponent<SpriteRenderer>().name.Equals("division"))
        {
            TFG.selectOperator(TwentyFourGame.operators.DIVIDED);
        }
    }
}
