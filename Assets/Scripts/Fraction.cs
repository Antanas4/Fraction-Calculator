using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fraction
{
    private int resultNumerator;
    private int resultDenominator;
    private string operation;
    private bool isNewCalculation;
    public Fraction(int a, int b, string c)
    {
        resultNumerator = a;
        resultDenominator = b;
        operation = c;
    }
    public void Calculate(int numerator, int denominator, string operation)
    {
        int gcd = 0;
        if (resultNumerator == 0 && resultDenominator == 0)
        {
            resultNumerator = numerator;
            resultDenominator = denominator;
        }
        else
        {
            if (MathError(numerator, denominator) == false)
            {
                switch (operation)
                {
                    case "+":
                        if (resultDenominator == denominator)
                        {
                            resultNumerator += numerator;
                        }
                        else
                        {
                            resultNumerator *= denominator;
                            numerator *= resultDenominator;
                            resultDenominator *= denominator;
                            resultNumerator += numerator;
                        }
                        break;
                    case "-":
                        if (resultDenominator == denominator)
                        {
                            resultNumerator -= denominator;
                        }
                        else
                        {
                            resultNumerator *= denominator;
                            numerator *= resultDenominator;
                            resultDenominator *= denominator;
                            resultNumerator -= numerator;
                        }
                        break;
                    case "*":
                        resultNumerator *= numerator;
                        resultDenominator *= denominator;
                        break;
                    case "/":
                        resultNumerator *= denominator;
                        resultDenominator *= numerator;
                        break;
                    case "=":
                        resultNumerator = numerator;
                        resultDenominator = denominator;
                        break;
                }
                gcd = CalculateGCD(resultNumerator, resultDenominator);
                resultNumerator /= gcd;
                resultDenominator /= gcd;
            }
            else
            {
                resultNumerator = 0;
                resultDenominator = 0;
            }
        }
        Debug.Log($"resultNumerator: {resultNumerator}");
        Debug.Log($"resultDenominator: {resultDenominator}");
    }
    public int CalculateGCD(int a, int b)
    {
        int temp;
        while (b != 0)
        {
            temp = b;
            b = a % b;
            a = temp;
        }
        if (a < 0)
        {
            return a * -1;
        }
        else
        {
            return a;
        }
    }
    public bool MathError(int tempNum, int tempDenum)
    {
        if (tempDenum == 0 || tempNum == 0)
        {
            return true;
        }
        return false;
    }
    public int GetNumerator()
    {
        return resultNumerator;
    }
    public int GetDenominator()
    {
        return resultDenominator;
    }
}

