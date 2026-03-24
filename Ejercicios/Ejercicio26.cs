using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var lista = new List<int>();
        var multiplos = new List<int>();

        // pedir 15 números
        for (int i = 0; i < 15; i++)
        {
            Console.Write("Número: ");
            lista.Add(int.Parse(Console.ReadLine()));
        }

        // filtrar múltiplos de 3
        foreach (var n in lista)
        {
            if (n % 3 == 0)
                multiplos.Add(n);
        }

        Console.WriteLine("\nLista original:");
        foreach (var n in lista)
            Console.WriteLine(n);

        Console.WriteLine("\nMúltiplos de 3:");
        foreach (var n in multiplos)
            Console.WriteLine(n);
    }
}