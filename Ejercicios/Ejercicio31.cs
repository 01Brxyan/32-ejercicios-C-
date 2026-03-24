using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var lista1 = new List<int>();
        var lista2 = new List<int>();

        Console.WriteLine("Lista 1:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Número: ");
            lista1.Add(int.Parse(Console.ReadLine()));
        }

        Console.WriteLine("\nLista 2:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Número: ");
            lista2.Add(int.Parse(Console.ReadLine()));
        }

        Console.WriteLine("\nLista 1:");
        foreach (var n in lista1)
            Console.WriteLine(n);

        Console.WriteLine("\nLista 2:");
        foreach (var n in lista2)
            Console.WriteLine(n);

        // valores únicos
        var set = new HashSet<int>(lista1);
        set.UnionWith(lista2);

        Console.WriteLine("\nÚnicos:");
        foreach (var n in set)
            Console.WriteLine(n);

        // repetidos
        var repetidos = new HashSet<int>(lista1);
        repetidos.IntersectWith(lista2);

        Console.WriteLine("\nCantidad repetidos: " + repetidos.Count);
    }
}