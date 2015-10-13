using System;

public class Question
{
    public enum operators
    {
        PLUS, MINUS, TIMES, DIVIDED, EMPTY
    }
    private int first;
    private int second;
    private operators currentOp = operators.EMPTY;
    private Random rnd = new Random();
    public Question(int num1, int num2, operators opPara)
	{
        currentOp = opPara;
        first = num1;
        second = num2;
	}
    public Question(int min, int max)
    {
        
        first = rnd.Next(min, max);
        second = rnd.Next(min, max);
        if(first < second)
        {
            int safe = first;
            first = second;
            second = safe;
        }
      
        currentOp = (operators)rnd.Next(0, 2);
    }
    public bool isRight(int answer)
    {
        if(currentOp == operators.PLUS)
        {
            return answer == (first + second);
        }
        else if(currentOp == operators.DIVIDED)
        {
            return answer == first / second;
        }
        else if(currentOp == operators.TIMES)
        {
            return answer == first * second;
        }
        else if(currentOp == operators.MINUS)
        {
            return answer == first - second;
        }
        else
        {
            return false;   
        }
    }
    public String getQuestion()
    {
        if (currentOp == operators.PLUS)
        {
            return "Wat is " + first + " + " + second +  "?";
        }
        else if (currentOp == operators.DIVIDED)
        {
            return "Wat is " + first + " / " + second + "?";
        }
        else if (currentOp == operators.TIMES)
        {
            return "Wat is " + first + " * " + second + "?";
        }
        else if (currentOp == operators.MINUS)
        {
            return "Wat is " + first + " - " + second + "?";
        }
        else
        {
            return "";
        }
    }
}
