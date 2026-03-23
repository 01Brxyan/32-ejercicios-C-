using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] numbers = { 10, 3, 5, 3, 10 };

        var result = GetRepeated(numbers);

        Console.WriteLine("Repetidos:");
        foreach (var num in result)
        {
            Console.WriteLine(num);
        }
    }

    static List<int> GetRepeated(int[] arr)
    {
        var seen = new HashSet<int>();
        var repeated = new HashSet<int>();

        foreach (var num in arr)
        {
            if (!seen.Add(num))
            {
                repeated.Add(num);
            }
        }

        return new List<int>(repeated);
    }
}