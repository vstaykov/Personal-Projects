using System;

class SevenlandNumbers
{
    static void Main()
    {
        //Get the input number
        string consoleInput;
        consoleInput = Console.ReadLine();

        int inputNumber;
        inputNumber = int.Parse(consoleInput);

        int resultNumber = 0;
        int hundreds, tens, ones;
        hundreds = 0;
        tens = 0;
        ones = 0;

        //Check every possible case and print the result
        if (inputNumber < 6)
        {
            resultNumber = inputNumber + 1;
            Console.WriteLine(resultNumber);
        }
        else if (inputNumber >= 6 && inputNumber < 100)
        {
            if (inputNumber % 10 >= 6 && inputNumber % 10 <= 9)
            {
                ones = 0;

                if (inputNumber / 10 >= 6 && inputNumber / 10 <= 9)
                {
                    tens = 10;
                }
                else
                {
                    tens = inputNumber / 10 + 1;
                }
            }
            else
            {
                ones = inputNumber + 1;
            }

            Console.WriteLine(tens * 10 + ones);
        }
        else if (inputNumber == 666)
        {
            resultNumber = 1000;
            Console.WriteLine(resultNumber);
        }
        else if (inputNumber > 99)
        {
            if (inputNumber % 10 >= 6 && inputNumber % 10 <= 9)
            {
                ones = 0;
                if ((inputNumber / 10) % 10 >= 6 && (inputNumber / 10) % 10 <= 9)
                {
                    tens = 10;
                }
                else
                {
                    tens = ((inputNumber / 10) % 10) + 1;
                    hundreds = inputNumber / 100 + 1;
                }
            }
            else
            {
                ones = (inputNumber) % 10 + 1;
                hundreds = inputNumber / 100;
                tens = ((inputNumber / 10) % 10);
            }
            hundreds = inputNumber / 100;
            Console.WriteLine(hundreds * 100 + tens * 10 + ones);
        }
    }
}
