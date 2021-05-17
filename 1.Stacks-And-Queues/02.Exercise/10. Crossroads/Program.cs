using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Program
    {
        static void Main()
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int additionalSeconds = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int passedCarsCounter = 0;

            string input = Console.ReadLine();

            //until end

            while (input != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                //green command
                else 
                {
                    int currentGreenLightSeconds = greenLightSeconds;

                    while (cars.Count > 0 && currentGreenLightSeconds > 0)
                    {
                        string currentCar = cars.Dequeue();
                        int currentCarLength = currentCar.Length;

                        if (currentCarLength <= currentGreenLightSeconds)
                        {
                            passedCarsCounter++;
                            currentGreenLightSeconds -= currentCarLength;
                        }
                        else
                        {
                            currentCarLength -= currentGreenLightSeconds;

                            if (currentCarLength > additionalSeconds)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {currentCar[additionalSeconds + currentGreenLightSeconds]}.");
                                return;
                            }
                            else
                            {
                                passedCarsCounter++;
                            }

                            currentGreenLightSeconds = 0;
                        }
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCarsCounter} total cars passed the crossroads.");
        }
    }
}