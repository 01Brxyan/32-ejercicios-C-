using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var codigos = new HashSet<string>();

        for (int i = 0; i < 10; i++)
        {
            Console.Write("Código: ");
            string c = Console.ReadLine();

            // intenta agregar
            if (codigos.Add(c))
                Console.WriteLine("Registrado.");
            else
                Console.WriteLine("Ya existe.");
        }
    }
}