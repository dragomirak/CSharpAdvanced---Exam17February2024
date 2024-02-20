using System.Collections.Generic;
using System.Reflection;

namespace ClearSkies;

public class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        char[,] airspace = new char[size, size];

        int currentRow = -1;
        int currentCol = -1;

        int enemies = 0;
        int armor = 300;
        for (int row = 0; row < size; row++)
        {
            char[] lineInput = Console.ReadLine().ToCharArray();
            for (int col = 0; col < size; col++)
            {
                airspace[row, col] = lineInput[col];
                if (airspace[row, col] == 'J')
                {
                    currentRow = row;
                    currentCol = col;
                    airspace[currentRow, currentCol] = '-';
                }
                if (airspace[row, col] == 'E')
                {
                    enemies++;
                }
            }
        }

        bool isArmorEmpty = false;
        while (enemies > 0)
        {
            string command = Console.ReadLine();
            if (command == "up")
            {
                currentRow--;
            }
            else if (command == "down")
            {
                currentRow++;
            }
            else if (command == "left")
            {
                currentCol--;
            }
            else if (command == "right")
            {
                currentCol++;
            }

            if (airspace[currentRow, currentCol] == '-')
            {
                continue;
            }
            else if (airspace[currentRow, currentCol] == 'E')
            {
                if (enemies == 1)
                {
                    airspace[currentRow, currentCol] = 'J';
                    break;
                }
                else if (enemies > 1)
                {
                    armor -= 100;
                    if (armor == 0)
                    {
                        airspace[currentRow, currentCol] = 'J';
                        isArmorEmpty = true;
                        break;
                    }
                    else if (armor > 0)
                    {
                        airspace[currentRow, currentCol] = '-';
                        enemies--;
                    }
                }
            }
            else if (airspace[currentRow, currentCol] == 'R')
            {
                armor += 300 - armor;
                airspace[currentRow, currentCol] = '-';
            }
        }

        if (isArmorEmpty)
        {
            Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{currentRow}, {currentCol}]!");
        }
        else
        {
            Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
        }

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Console.Write(airspace[row, col]);
            }
            Console.WriteLine();
        }
    }
}