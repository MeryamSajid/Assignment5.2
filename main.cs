using System;

class Program
{
    static void Main()
    {
        int[] temperatures = new int[5];
        bool Valid = false;
        bool Ascending = true;
        bool Descending = true;

        Console.WriteLine("Enter five daily temperatures within range of -30 to 130 Fahrenheit:");

        for (int i = 0; i < temperatures.Length; i++)
        {
            do
            {
                Console.Write($"Temperature {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out temperatures[i]) && temperatures[i] >= -30 && temperatures[i] <= 130)
                {
                    Valid = true;

                    if (i > 0)
                    {
                        if (temperatures[i] <= temperatures[i - 1])
                        {
                            Ascending = false;
                        }

                        if (temperatures[i] >= temperatures[i - 1])
                        {
                            Descending = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Temperature " + temperatures[i] + " is invalid. Please enter a valid temperature between -30 and 130");
                }
            } while (!Valid);

            Valid = false;
        }

        if (Ascending)
        {
            Console.WriteLine("Getting Warmer");
        }
        else if (Descending)
        {
            Console.WriteLine("Getting Cooler");
        }
        else
        {
            Console.WriteLine("It's a mixed bag");
        }

        Console.Write("5-day Temperature [" + temperatures[0] + ", " + temperatures[1] + ", " + temperatures[2] + ", " + temperatures[3] + ", " + temperatures[4] + "]" );
        

        double averageTemperature = CalculateAverageTemperature(temperatures);
        Console.WriteLine($"\nAverage Temperature is {averageTemperature:F1} degrees");
    }

    static double CalculateAverageTemperature(int[] temperatures)
    {
        double sum = 0;
        foreach (int temp in temperatures)
        {
            sum += temp;
        }
        return sum / temperatures.Length;
    }
}