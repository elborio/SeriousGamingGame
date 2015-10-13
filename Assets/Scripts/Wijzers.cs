using UnityEngine;
using System;

public class Wijzers : MonoBehaviour {
    public kleineWijzer kleine;
    public GameObject grote;
    private int hoursInput;
    private int minutesInput;
    private int hoursQuestion;
    private int minutesQuestion;

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
        kleine.rotate();
    }
}
