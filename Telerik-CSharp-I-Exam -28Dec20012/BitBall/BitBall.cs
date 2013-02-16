using System;

class BitBall
{
    static void Main()
    {
        //Input the members of the first team
        int[] topTeam = InputTeamMembers(8);

        //Input the members of the second team
        int[] bottomTeam = InputTeamMembers(8);

        //Setting on one field
        int[] afterFouls = SetTeamsOnOneField(topTeam, bottomTeam);

        int resultTop = 0;
        int resultBottom = 0;

        //Moving bits
        MoveBits(topTeam, ref resultTop, ref resultBottom, afterFouls);

        //Print the result
        Console.WriteLine("{0}:{1}", resultTop, resultBottom);
    }

    private static int[] InputTeamMembers(int numberOfMembers)//Input the team players
    {
        int[] team = new int[numberOfMembers];
        for (int i = 0; i < numberOfMembers; i++)
        {
            team[i] = int.Parse(Console.ReadLine());
        }
        return team;
    }

    private static int[] SetTeamsOnOneField(int[] topTeam, int[] bottomTeam) //Set the two teams on one field and calculate the fouls
    {
        int mask = 1;
        int bitValue = 0;
        int bitValueTop = 0;
        int[] afterFouls = new int[8];

        for (int i = 0; i < 8; i++)
        {
            afterFouls[i] = topTeam[i];
            for (int j = 0; j < 8; j++)
            {
                bitValue = (bottomTeam[i] & (mask << j)) >> j;

                if (bitValue == 1)
                {
                    bitValueTop = (topTeam[i] & (mask << j)) >> j;

                    if (bitValueTop == 0)
                    {
                        afterFouls[i] = afterFouls[i] | (1 << j);
                    }
                    else
                    {
                        afterFouls[i] = afterFouls[i] & (~(1 << j));
                    }
                }
            }
        }
        return afterFouls;
    }

    private static void MoveBits(int[] topTeam, ref int resultTop, ref int resultBottom, int[] afterFouls) //Move bits after fouls and calculate the result
    {

        int mask = 1;
        int bitValue = 0;

        for (int i = 0; i < 8; i++)
        {
            int bitValueTemp = 0;
            for (int j = 0; j < 8; j++)
            {
                bitValue = (afterFouls[i] & (mask << j)) >> j;
                bitValueTemp = (topTeam[i] & (mask << j)) >> j;
                int bitValueDown = 0;
                int bitValueUp = 0;

                if (bitValue == bitValueTemp && bitValue == 1 && i != 7)
                {

                    for (int m = i + 1; m < 8; m++)
                    {
                        bitValueDown = afterFouls[m] & (1 << j);


                        if (bitValueDown == 0)
                        {
                            if (m == 7)
                            {
                                resultTop++;
                            }
                            continue;

                        }
                        else
                        {
                            break;
                        }

                    }
                }
                else if (bitValue == 1 && i > 0 && bitValue != bitValueTemp)
                {
                    for (int k = i - 1; k >= 0; k--)
                    {
                        bitValueUp = afterFouls[k] & (1 << j);

                        if (bitValueUp == 0)
                        {
                            if (k == 0)
                            {
                                resultBottom++;
                            }
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else if (i == 0 && bitValue == 1 && bitValue != bitValueTemp)
                {
                    resultBottom++;
                }
                else if (i == 7 && bitValue == bitValueTemp && bitValue == 1)
                {
                    resultTop++;
                }
            }
        }
    }
}
