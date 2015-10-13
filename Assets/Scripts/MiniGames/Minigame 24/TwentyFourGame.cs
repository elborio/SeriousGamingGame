using UnityEngine;
using System;

public class TwentyFourGame : MonoBehaviour {
    public Sprite[] sprites;
    public SpriteRenderer[] renderers;
    public SpriteRenderer[] extraNumbers;
    public System.Random rnd = new System.Random();
    private int[] Numbers = new int[4];
    private int numberSelected;
    private Boolean numberSelectedBool;
    private int firstExtra = 0;
    private int secondExtra = 0;
    private int total;
    private bool[] NumbersUsed = new bool[6];
    public enum operators
    {
      PLUS, MINUS, TIMES, DIVIDED, EMPTY
    } 
    public operators currentOp;

    // Use this for initialization
    void Start () {
        int i = 0;
        foreach (SpriteRenderer r in renderers) {
            int nr1 = rnd.Next(1, 10);
            r.sprite = sprites[nr1 - 1];
            Numbers[i] = nr1;
            i++;
            Debug.Log(nr1);
        }
        for(int j = 0; j < 6; j++)
        {
            NumbersUsed[j] = true;
        }
        
    }
    void Update()
    {
        for(int i = 0; i < 4; i++)
        {
            if (!NumbersUsed[i])
            {
                renderers[i].enabled = false;
            }
        }
        if (!NumbersUsed[4])
        {
            extraNumbers[0].enabled = false;
            extraNumbers[1].enabled = false;
        }
        if (!NumbersUsed[5])
        {
            extraNumbers[2].enabled = false;
            extraNumbers[3].enabled = false;
        }
        if (checkTotal())
        {
            Debug.Log("You Win!");
        }
    }
    public void selectOperator(operators s)
    {
          currentOp = s;      
    }
    public void spriteClick(SpriteRenderer r)
    {
        if (!numberSelectedBool)
        {
            numberSelectedBool = true;
            numberSelected = Numbers[Array.IndexOf(renderers, r)];
            NumbersUsed[Array.IndexOf(renderers, r)] = false;
        }
        else
        {
            if (currentOp != operators.EMPTY)
            {
                if (firstExtra == 0)
                {
                    if (currentOp == operators.PLUS)
                    {
                        firstExtra = numberSelected + Numbers[Array.IndexOf(renderers, r)];
                    }
                    if (currentOp == operators.TIMES)
                    {
                        firstExtra = numberSelected * Numbers[Array.IndexOf(renderers, r)];
                    }
                    if (currentOp == operators.DIVIDED)
                    {
                        firstExtra = numberSelected / Numbers[Array.IndexOf(renderers, r)];
                    }
                    if (currentOp == operators.MINUS)
                    {
                        firstExtra = numberSelected - Numbers[Array.IndexOf(renderers, r)];

                    }
                    addFirstExtra();
                }
                else if (secondExtra == 0)
                {
                    if (currentOp == operators.PLUS)
                    {
                        secondExtra = numberSelected + Numbers[Array.IndexOf(renderers, r)];
                    }
                    if (currentOp == operators.TIMES)
                    {
                        secondExtra = numberSelected * Numbers[Array.IndexOf(renderers, r)];
                    }
                    if (currentOp == operators.DIVIDED)
                    {
                        secondExtra = numberSelected / Numbers[Array.IndexOf(renderers, r)];
                    }
                    if (currentOp == operators.MINUS)
                    {
                        secondExtra = numberSelected - Numbers[Array.IndexOf(renderers, r)];
                    }
                    addSecondExtra();
                }
                else
                {
                    if (currentOp == operators.PLUS)
                    {
                        total = numberSelected + Numbers[Array.IndexOf(renderers, r)];
                        NumbersUsed[Array.IndexOf(renderers, r)] = false;
                    }
                    if (currentOp == operators.TIMES)
                    {
                        total = numberSelected * Numbers[Array.IndexOf(renderers, r)];
                        NumbersUsed[Array.IndexOf(renderers, r)] = false;
                    }
                    if (currentOp == operators.DIVIDED)
                    {
                        total = numberSelected / Numbers[Array.IndexOf(renderers, r)];
                        NumbersUsed[Array.IndexOf(renderers, r)] = false;
                    }
                    if (currentOp == operators.MINUS)
                    {
                        total = numberSelected - Numbers[Array.IndexOf(renderers, r)];
                        NumbersUsed[Array.IndexOf(renderers, r)] = false;
                    }
                }
                Debug.Log("Total = " + total);
                currentOp = operators.EMPTY;
                numberSelectedBool = false;
                numberSelected = -1;
                NumbersUsed[Array.IndexOf(renderers, r)] = false;
                if (checkTotal())
                {
                    Application.LoadLevel(2);
                }
            }
        }
        
    }
    void addFirstExtra()
    {
        int firstNumber = firstExtra / 10;
        int secondNumber = firstExtra - 10 * firstNumber;
        if(firstNumber > 0)
        {
            extraNumbers[0].sprite = sprites[firstNumber - 1];
        }
        extraNumbers[1].sprite = sprites[secondNumber - 1];
    }
    void addSecondExtra()
    {

        int firstNumber = secondExtra / 10;
        int secondNumber = secondExtra - 10 * firstNumber;
        if (firstNumber > 0)
        {
            extraNumbers[2].sprite = sprites[firstNumber - 1];
        }
        extraNumbers[3].sprite = sprites[secondNumber - 1];
    }
    public void SelectFirstExtra()
    {
        if (firstExtra != 0)
        {
            if (!numberSelectedBool)
            {
                numberSelected = firstExtra;
                numberSelectedBool = true;
                NumbersUsed[4] = false;
            }
            else if (currentOp != operators.EMPTY)
            { 
                if (secondExtra == 0)
                {
                    if (currentOp == operators.PLUS)
                    {
                        secondExtra = numberSelected + firstExtra;
                    }
                    if (currentOp == operators.TIMES)
                    {
                        secondExtra = numberSelected * firstExtra;
                    }
                    if (currentOp == operators.DIVIDED)
                    {
                        secondExtra = numberSelected / firstExtra;
                    }
                    if (currentOp == operators.MINUS)
                    {
                        secondExtra = numberSelected - firstExtra;
                    }
                    addSecondExtra();
                }
                else
                {
                    if (currentOp == operators.PLUS)
                    {
                        total = numberSelected + firstExtra;
                    }
                    if (currentOp == operators.TIMES)
                    {
                        total = numberSelected * firstExtra;
                    }
                    if (currentOp == operators.DIVIDED)
                    {
                        total = numberSelected / firstExtra;
                    }
                    if (currentOp == operators.MINUS)
                    {
                        total = numberSelected - firstExtra;
                    }
                }
                currentOp = operators.EMPTY;
                numberSelectedBool = false;
                numberSelected = -1;
                NumbersUsed[4] = false;
            }

            if (checkTotal())
            {
                Application.LoadLevel(2);
            }
        }
       
    }
    public void SelectSecondExtra()
    {
        if (secondExtra != 0)
        {
            if (!numberSelectedBool)
            {
                numberSelected = secondExtra;
                numberSelectedBool = true;
                NumbersUsed[5] = false;
            }
            else
            {

                if (currentOp != operators.EMPTY)
                {
                    if (currentOp == operators.PLUS)
                    {
                        total = numberSelected + secondExtra;
                    }
                    if (currentOp == operators.TIMES)
                    {
                        total = numberSelected * secondExtra;
                    }
                    if (currentOp == operators.DIVIDED)
                    {
                        total = numberSelected / secondExtra;
                    }
                    if (currentOp == operators.MINUS)
                    {
                        total = numberSelected - secondExtra;
                    }
                }
                currentOp = operators.EMPTY;
                numberSelectedBool = false;
                numberSelected = -1;
                NumbersUsed[5] = false;
                if (checkTotal())
                {
                    Application.LoadLevel(2);
                }
            }
        }
    }
    public bool checkTotal()
    {
        return total == 24;
    }

}
