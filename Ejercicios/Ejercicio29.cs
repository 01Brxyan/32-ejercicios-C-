using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var lista = new List<string>();
        var vistos = new HashSet<string>();
        var duplicados = new HashSet<string>();

        for (int i = 0; i < 10; i++)
        {
            Console.Write("Nombre: ");
            string n = Console.ReadLine();

            lista.Add(n);

            // detectar duplicado
            if (!vistos.Add(n))
                duplicados.Add(n);
        }

        Console.WriteLine("\nDuplicados:");
        foreach (var d in duplicados)
            Console.WriteLine(d);
    }
}