using System;
using System.IO;

namespace _2
{
    class Program
    {
        private static int[] programArray;
        static void Main(string[] args)
        {
            var inputArray = File.ReadAllText("input.txt");
            // programArray = new int[] { 1,1,1,4,99,5,6,0,99 };
            int currentPosition = 0;
            int output = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    currentPosition = 0;
                    programArray = Array.ConvertAll(inputArray.Split(","), int.Parse);
                    restoreProgram(i, j);
                    output = RunProgram(currentPosition);
                    if ( output==19690720 ) 
                    {
                        Console.WriteLine($"Answer: {i*100+j}");
                        break;
                    }
                }
            }
        }

        private static int RunProgram(int currentPosition)
        {
            while (currentPosition < programArray.Length)
            {
                if (programArray[currentPosition] == 1)
                {
                    performAddition(currentPosition);
                }
                else if (programArray[currentPosition] == 2)
                {
                    performMultiplication(currentPosition);
                }
                else if (programArray[currentPosition] == 99)
                {
                    break;
                }
                currentPosition += 4;
            }

            return programArray[0];
        }

        private static void OutPutArray()
        {
            foreach (var item in programArray)
            {
                Console.Write($"{item.ToString()},");
            }

        }

        private static void performAddition(int currentPosition)
        {
            programArray[programArray[currentPosition + 3]] = programArray[programArray[currentPosition + 1]] + programArray[programArray[currentPosition + 2]];
        }
        private static void performMultiplication(int currentPosition)
        {
            programArray[programArray[currentPosition + 3]] = programArray[programArray[currentPosition + 1]] * programArray[programArray[currentPosition + 2]];
        }
        private static void restoreProgram(int a, int b)
        {
            programArray[1] = a;
            programArray[2] = b;
        }

    }
}
