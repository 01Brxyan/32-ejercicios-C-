using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var lista = new List<int>();
        var pares = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            Console.Write("Número: ");
            lista.Add(int.Parse(Console.ReadLine()));
        }

        foreach (var n in lista)
        {
            if (n % 2 == 0)
                pares.Add(n);
        }

        Console.WriteLine("Números pares:");
        foreach (var n in pares)
            Console.WriteLine(n);
    }
}