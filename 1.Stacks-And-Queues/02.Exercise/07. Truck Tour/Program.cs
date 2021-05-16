using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class PetrolPump
    {
        public PetrolPump(long petrol, long distance)
        {
            Petrol = petrol;
            Distance = distance;
        }

        public long Petrol { get; set; }
        public long Distance { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Queue<PetrolPump> petrolPumps = new Queue<PetrolPump>();

            for (long i = 0; i < n; i++)
            {
                long[] inputArgs = Console.ReadLine().Split().Select(long.Parse).ToArray();
                petrolPumps.Enqueue(new PetrolPump(inputArgs[0], inputArgs[1]));
            }


            for (int i = 0; i < n; i++)
            {
                bool isFullCircle = true;
                long currentPetrol = 0;

                for (int v = 0; v < petrolPumps.Count; v++)
                {
                    PetrolPump currPump = new PetrolPump(petrolPumps.Peek().Petrol, petrolPumps.Dequeue().Distance);
                    petrolPumps.Enqueue(currPump);

                    currentPetrol += currPump.Petrol;

                    if (currentPetrol >= currPump.Distance)
                    {
                        currentPetrol -= currPump.Distance;
                    }
                    else
                    {
                        isFullCircle = false;
                    }
                }

                if (isFullCircle)
                {
                    Console.WriteLine(i);
                    break;
                }

                petrolPumps.Enqueue(petrolPumps.Dequeue());
            }
        }
    }
}
