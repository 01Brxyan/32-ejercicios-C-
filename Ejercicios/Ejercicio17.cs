using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var nombres = new List<string>();

        for (int i = 0; i < 5; i++)
        {
            Console.Write("Nombre: ");
            nombres.Add(Console.ReadLine().ToLower());
        }

        Console.Write("Buscar nombre: ");
        string buscar = Console.ReadLine().ToLower();

        if (nombres.Contains(buscar))
            Console.WriteLine("Existe en la lista.");
        else
            Console.WriteLine("No existe.");
    }
}