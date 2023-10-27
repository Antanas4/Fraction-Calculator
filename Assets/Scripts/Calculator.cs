using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Numerics;

public class Calculator : MonoBehaviour
{
    public TextMeshProUGUI numeratorInputField;
    public TextMeshProUGUI denominatorInputField;
    public TextMeshProUGUI resultField;
    private int numerator;
    private int denominator;
    private string operation;
    private bool activeNumeratorField;
    private bool activeDenominatorField;
    private Fraction fraction;
    public Calculator()
    {
        numerator = 0;
        denominator = 0;
        operation = "=";
        activeNumeratorField = false;
        activeDenominatorField = false;
        fraction = new Fraction(numerator, denominator, operation);
    }
    //Function to activate numerator or denominator field for input
    public void ToggleActiveField(string value)
    {
        if (value == "n")
        {
            activeNumeratorField = !activeNumeratorField;
            activeDenominatorField = false;
        }
        else if (value == "d")
        {
            activeDenominatorField = !activeDenominatorField;
            activeNumeratorField = false;
        }
    }
    //Function to get input and store the values
    public void NumberInput(string value)
    {
        if (activeNumeratorField && !activeDenominatorField)
        {
            numeratorInputField.text = numeratorInputField.text + value;
            numerator = int.Parse(numeratorInputField.text);
        }
        else if (activeDenominatorField && !activeNumeratorField)
        {
            denominatorInputField.text = denominatorInputField.text + value;
            denominator = int.Parse(denominatorInputField.text);
        }
    }
    //Function to perform the operation and calculate the ongoing result
    public void OperationInput(string value)
    {
        Debug.Log($"numerator: {numerator}");
        Debug.Log($"denominator: {denominator}");

        fraction.Calculate(numerator, denominator, operation);
        operation = value;
        if (value == "=")
        {
            if (fraction.GetDenominator() == 0)
            {
                resultField.text = "SyntaxError";
            }
            else
            {
                resultField.text = "result: " + fraction.GetNumerator().ToString() + "/" + fraction.GetDenominator().ToString();
            }
        }
        else
        {
            if (fraction.GetNumerator() == 0 && fraction.GetDenominator() == 0)
            {
                resultField.text = "SyntaxError";
            }
            else
            {
                if (value != "/")
                {
                    resultField.text = fraction.GetNumerator().ToString() + "/" + fraction.GetDenominator().ToString() + value;
                }
                else
                {
                    resultField.text = fraction.GetNumerator().ToString() + "/" + fraction.GetDenominator().ToString() + "\u00F7";
                }

            }

        }
        NullValues();
    }
    //Function to clear the current numerator/denominator field
    public void ClearClick()
    {
        if (activeNumeratorField && !activeDenominatorField)
        {
            numeratorInputField.text = null;
        }
        else if (activeDenominatorField && !activeNumeratorField)
        {
            denominatorInputField.text = null;
        }
    }
    //function to null the values
    private void NullValues()
    {
        numerator = 0;
        denominator = 0;
        numeratorInputField.text = null;
        denominatorInputField.text = null;
        activeNumeratorField = false;
        activeDenominatorField = false;
    }
}
