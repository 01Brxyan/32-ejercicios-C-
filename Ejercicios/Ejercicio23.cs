using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var lista = new List<int>();

        for (int i = 0; i < 12; i++)
        {
            Console.Write("Número: ");
            lista.Add(int.Parse(Console.ReadLine()));
        }

        var set = new HashSet<int>(lista);

        Console.WriteLine("Todos:");
        foreach (var n in lista)
            Console.WriteLine(n);

        Console.WriteLine("Únicos: " + set.Count);
    }
}