using UnityEngine;
using System;

public class DragAndDrop : MonoBehaviour {

    // Use this for initialization
    private Vector3 screenPoint;
    public BackgroundScript bgs;
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
    }
    void OnMouseDrag()
    {
           transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        if (bgs.inRange(this.gameObject))
        {
            if (Math.Abs(Math.Abs(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z)).x) - 2.5D) < 0.5
                || Math.Abs(Math.Abs(Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z)).y) - 2.5D) < 0.5
                || Math.Abs(Math.Abs(Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z)).y)) < 0.5 ||
                Math.Abs(Math.Abs(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z)).x)) < 0.5)
            {
                if (transform.position.x < -1)
                {
                    transform.position = new Vector3(-2.5F, transform.position.y, -2.1F);
                }
                else if (transform.position.x > 1)
                {
                    transform.position = new Vector3(2.5F, transform.position.y, -2.1F);
                }
                else
                {
                    transform.position = new Vector3(0.0F, transform.position.y, -2.1F);
                }
                if (transform.position.y < -1)
                {
                    transform.position = new Vector3(transform.position.x, -2.5F, -2.1F);
                }
                else if (transform.position.y > 1)
                {
                    transform.position = new Vector3(transform.position.x, 2.5F, -2.1F);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, 0.0F, -2.1F);
                }
            }
        }
        
    }
    void OnMouseUp()
    {
        bgs.CheckAnswer(this.gameObject);
    }
    // transform.position.y = Input.mousePosition.y;


}

