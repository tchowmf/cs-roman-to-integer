// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Diagnostics.SymbolStore;

class Program
{
    public static int symbolToInt(string s)
    {
        Dictionary<char, int> romanValues = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        int result = 0;
        for(int i = 0; i < s.Length; i++)
        {
            char currentChar = char.ToUpper(s[i]);
            char nextChar = (i < s.Length - 1) ? char.ToUpper(s[i]) : '\0';

            if(i < s.Length - 1 && romanValues.ContainsKey(currentChar) && romanValues.ContainsKey(nextChar) && romanValues[currentChar] < romanValues[nextChar])
            {
                result -= romanValues[currentChar];
            }
            else
            {
                result += romanValues[currentChar];
            }
        }
        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Romam Number: ");
        string romanNumber = Console.ReadLine();
        int intValue = symbolToInt(romanNumber);
        Console.WriteLine($"The int value of {romanNumber} is: {intValue}");
    }
}
