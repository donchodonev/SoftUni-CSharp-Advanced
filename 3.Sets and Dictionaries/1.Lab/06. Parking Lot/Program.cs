using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> licensePlates = new HashSet<string>();

            while (inputArgs.Length != 1)
            {
                string direction = inputArgs[0];
                string licensePlate = inputArgs[1];

                if (direction == "IN")
                {
                    licensePlates.Add(licensePlate);
                }
                else
                {
                    if (licensePlates.Contains(licensePlate))
                    {
                        licensePlates.Remove(licensePlate);
                    }
                }

                inputArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (licensePlates.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var carLicensePlate in licensePlates)
                {
                    Console.WriteLine(carLicensePlate);
                }
            }
        }
    }
}
