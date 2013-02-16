using System;
using System.Text;

class ANacci
{
    static void Main()
    {
        //Get the first element
        string firstLetter = Console.ReadLine();
        int firstNumber = 0;
        firstNumber = firstLetter[0] - 64;

        //Get the second element
        string secondLetter = Console.ReadLine();
        int secondNumber = 0;
        secondNumber = secondLetter[0] - 64;

        int linesNumber = int.Parse(Console.ReadLine());
        StringBuilder resultString = new StringBuilder();

        resultString.Append(firstLetter); resultString.Append(" "); resultString.Append(secondLetter);

        int nextElementNumber = 0;
        int sum = 0;

        //Building the A-nacci figure in one stringbuilder
        for (int i = 0; i < 2 * linesNumber - 1; i++)
        {
            sum = firstNumber + secondNumber;

            if (sum > 26)
            {
                nextElementNumber = sum % 26;
            }
            else
            {
                nextElementNumber = sum;
            }

            resultString.Append(" "); resultString.Append((char)(nextElementNumber + 64));
            firstNumber = secondNumber;
            secondNumber = nextElementNumber;
        }

        //Print the result
        PrintResult(linesNumber, resultString.ToString());
    }


    private static void PrintResult(int linesNumber, string resultString) //Print the result in the right form
    {
        string[] output = resultString.Split(' ');

        int counter = 0;
        int j = 1;

        for (int i = 1; i <= linesNumber; i++)
        {
            if (i == 1)
            {
                Console.WriteLine(output[0]);
            }
            else
            {
                Console.Write(output[j]);
                Console.Write(new string(' ', counter));
                Console.WriteLine(output[j + 1]);
                counter++;
                j += 2;
            }

        }
    }
}
