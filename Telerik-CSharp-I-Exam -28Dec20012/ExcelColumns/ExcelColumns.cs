using System;
using System.Numerics;
using System.Text;

class ExcelColumns
{
    static void Main()
    {
        //Get the lenght of the column name
        int lettersNumber = int.Parse(Console.ReadLine());

        //Construct the name
        StringBuilder columnName = new StringBuilder(lettersNumber);
        for (int i = 0; i < lettersNumber; i++)
        {
            columnName.Append(Console.ReadLine());
        }

        //Calculate the index
        BigInteger columnIndex = CalculateColumnIndex(lettersNumber, columnName);

        //Print the result
        Console.WriteLine(columnIndex);
    }

    private static BigInteger CalculateColumnIndex(int lettersNumber, StringBuilder columnName)//Calculate the index using the name of the column
    {
        BigInteger columnIndex = 0;
        BigInteger pow = 1;
        int currentLetterIndex = 0;

        for (int i = lettersNumber - 1; i >= 0; i--)
        {
            currentLetterIndex = columnName[i] - 64;

            columnIndex += currentLetterIndex * pow;
            pow *= 26;
        }
        return columnIndex;
    }
}
