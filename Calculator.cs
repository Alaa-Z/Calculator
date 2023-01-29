﻿namespace CalculatorApp;

public static class Calculator
{
    public static double Calculate(double n1, double n2, string mathOperator)
    {
        double result = 0;

        switch (mathOperator)
        {
            case "+":
                result = n1 + n2;
                break;
            case "-":
                result = n1 - n2;
                break;
            case "÷":
                result = n1 / n2;
                break;
            case "×":
                result = n1 * n2;
                break;    
        }
        return result;
    }

}

