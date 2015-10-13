using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour
{

    public float moveSpeed = 20.0f;
    public bool invert;
    private float hozTurn = 0.0f;
    private float verTurn = 0.0f;

    void Update()
    {
        int invertVal = 1;
        if (invert)
        {
            invertVal = -1;
        }
        hozTurn = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verTurn = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime * invertVal;
        transform.Rotate(verTurn, hozTurn, 0);
    }
}
