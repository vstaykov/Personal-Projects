using System;

class TelerikLogo
{
    static void Main()
    {
        //Input the main size x - check task!
        int x = int.Parse(Console.ReadLine());

        //Calculate the other dimensions
        int y = x;
        int z = (x + 1) / 2;
        int width = 3 * x - 2;
        int height = width;

        int leftStartIndex, leftEndIndex, rightStartIndex, rightEndIndex;
        leftStartIndex = leftEndIndex = z;
        rightStartIndex = rightEndIndex = width + 1 - z;

        //Print the logo
        for (int rows = 1; rows <= height; rows++)
        {
            for (int cols = 1; cols <= width; cols++)
            {
                if (cols == leftStartIndex || cols == leftEndIndex || cols == rightStartIndex || cols == rightEndIndex)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }

                if (cols == width)
                {
                    Console.WriteLine();
                }
            }
            if (rows < x)
            {
                leftStartIndex--; rightStartIndex--;
                leftEndIndex++; rightEndIndex++;
            }
            else if (rows >= x && rows < x + y - 1)
            {
                leftEndIndex--;
                rightStartIndex++;
            }
            else
            {
                leftStartIndex--; rightStartIndex--;
                leftEndIndex++; rightEndIndex++;
            }
        }
    }
}
