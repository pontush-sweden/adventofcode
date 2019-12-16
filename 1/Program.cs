using System;
using System.IO;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get modules
            var modules = File.ReadAllLines("input.txt");

            int requiredFuel = 0;
            foreach (var module in modules)
            {
                requiredFuel += GetRequiredFuelRecursive(int.Parse(module));
            }
            Console.WriteLine(requiredFuel.ToString());
        }

        private static int GetRequiredFuel(int mass)
        {
            return mass / 3 - 2;
        }

        private static int GetRequiredFuelRecursive(int mass)
        {
            int theFuel = GetRequiredFuel(mass);
            if (theFuel <= 0)
            {
                return 0;
            }
            else
            {
                return theFuel += GetRequiredFuelRecursive(theFuel);
            }
        }
    }
}
