using System;
using System.Numerics;
using System.Text;

class DurankulakNumbers
{
    static void Main()
    {
        string inputNumber = Console.ReadLine();

        //Fill an array with the letter representation of each number in [1,168]
        string[] allDigits = FillDigitsArray();

        //Convert the input number
        BigInteger resultNumber = ConvertToDecimal(inputNumber, allDigits);

        //Print result
        Console.WriteLine(resultNumber);
    }

    private static BigInteger ConvertToDecimal(string inputNumber, string[] allDigits) //Convert the number in decimal
    {
        BigInteger power = 168;
        StringBuilder currentNumber = new StringBuilder();
        char currentChar = ' ';

        int index = inputNumber.Length - 1;

        BigInteger result = 0;
        int value = 0;
        bool firstDigitPassed = false;

        while (true)
        {
            currentChar = inputNumber[index];

            if (index == 0 || inputNumber[index - 1] >= 65 && inputNumber[index - 1] <= 91)
            {
                currentNumber.Append(currentChar.ToString());
                index -= 1;
            }
            else
            {
                currentNumber.Append(inputNumber[index - 1].ToString() + currentChar.ToString());
                index -= 2;
            }

            for (int i = 0; i < 168; i++)
            {
                if (allDigits[i] == currentNumber.ToString())
                {
                    value = i;
                    break;
                }
            }

            if (firstDigitPassed == true)
            {
                result += power * value;
                power *= 168;
            }
            else
            {
                result += value;
            }

            firstDigitPassed = true;
            currentNumber.Clear();

            if (index < 0)
            {
                break;
            }
        }
        return result;
    }

    private static string[] FillDigitsArray() //Filling an array with all 168 combinations of letters that form each number in [0,168]
    {
        string[] allDigits = new string[168];
        int firstCharCode = 0;
        int secondCharCode = 95;

        for (int i = 0; i < 168; i++)
        {
            if (i % 26 == 0)
            {
                firstCharCode = 65;
                secondCharCode++;
            }

            if (i >= 0 && i <= 25)
            {
                allDigits[i] = ((char)firstCharCode).ToString();
                firstCharCode++;
            }

            if (i > 25)
            {
                allDigits[i] = ((char)secondCharCode).ToString() + ((char)firstCharCode).ToString();
                firstCharCode++;
            }
        }
        return allDigits;
    }
}
