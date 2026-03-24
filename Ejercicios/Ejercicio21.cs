using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var palabras = new HashSet<string>();

        for (int i = 0; i < 8; i++)
        {
            Console.Write("Palabra: ");
            palabras.Add(Console.ReadLine());
        }

        Console.WriteLine("Únicas: " + palabras.Count);

        foreach (var p in palabras)
            Console.WriteLine(p);
    }
}