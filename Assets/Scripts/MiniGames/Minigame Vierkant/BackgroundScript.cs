using UnityEngine;
using System;

public class BackgroundScript : MonoBehaviour {
    public GameObject[] texts;
    public GameObject[] answers;
    private System.Random rnd;
    private int[] sumsFirst = new int[9];
    private int[] sumsSecond = new int[9];
    private bool[] answeredCorrectly = new bool[9];
    private int[] answered = new int[9];
    public GameObject winner;
    // Use this for initialization
    void Start () {
        winner.GetComponent<SpriteRenderer>().enabled = false;
        rnd = new System.Random();
	    for(int i = 0; i < 9; i++)
        {
            sumsFirst[i] = rnd.Next(1, 10);
            sumsSecond[i] = rnd.Next(1, 10);
            texts[i].GetComponentInChildren<TextMesh>().text = sumsFirst[i] + " + " + sumsSecond[i];
            if (sumsFirst[i] + sumsSecond[i] > 9)
            {
                answers[i].GetComponentInChildren<TextMesh>().text = sumsFirst[i] + sumsSecond[i] + "";
                answered[i] = sumsFirst[i] + sumsSecond[i];
            }
            else
            {
                answers[i].GetComponentInChildren<TextMesh>().text = " " + (sumsFirst[i] + sumsSecond[i]) ;
                answered[i] = sumsFirst[i] + sumsSecond[i];
            }
        }
	}

    // Update is called once per frame
    public void CheckAnswer(GameObject answer) {
        if (inRange(answer))
        {
            for (int i = 0; i < 9; i++)
            {
                if (answer.transform.position.x == texts[i].transform.position.x && answer.transform.position.y == texts[i].transform.position.y)
                {
                    Debug.Log("Position same as " + i);
                    if (answered[Array.IndexOf(answers, answer)] == sumsFirst[i] + sumsSecond[i])
                    {
                        
                        answeredCorrectly[Array.IndexOf(answers, answer)] = true;
                    }
                    else
                    {
                        answeredCorrectly[Array.IndexOf(answers, answer)] = false;
                    }
                }
            }
        }
        else
        {
            Debug.Log("notInRange");
            answeredCorrectly[Array.IndexOf(answers, answer)] = false;
        }
        if (CheckAllRight())
        {
            Application.LoadLevel(2);
        }       
    }
    public bool inRange(GameObject answer)
    {
        if(answer.transform.position.x >= -3.0F && answer.transform.position.x <= 3.0F && answer.transform.position.y >= -3.0F && answer.transform.position.x <= 3.0F)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool CheckAllRight()
    {
        int total = 0;
        for (int i = 0; i < 9; i++)
        {
            if (answeredCorrectly[i])
            {
                total++;
            }
        }
        return total == 9;
    }
   
}
