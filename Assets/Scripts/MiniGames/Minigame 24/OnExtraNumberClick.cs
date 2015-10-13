using UnityEngine;
using System.Collections;

public class OnExtraNumberClick: MonoBehaviour
{
    public TwentyFourGame TFG;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        Debug.Log("Clicked" + GetComponent<SpriteRenderer>().name);
        if (GetComponent<SpriteRenderer>().name.Equals("FirstExtra1"))
        {
            TFG.SelectFirstExtra();
        }
        else if (GetComponent<SpriteRenderer>().name.Equals("FirstExtra2"))
        {
            TFG.SelectFirstExtra();
        }
        else if (GetComponent<SpriteRenderer>().name.Equals("SecondExtra1"))
        {
            TFG.SelectSecondExtra();
        }
        else if (GetComponent<SpriteRenderer>().name.Equals("SecondExtra2"))
        {
            TFG.SelectSecondExtra();
        }


    }
}
