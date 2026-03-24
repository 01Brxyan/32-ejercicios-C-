using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var correos = new HashSet<string>();

        while (true)
        {
            Console.Write("Correo (salir): ");
            string c = Console.ReadLine();

            if (c.ToLower() == "salir")
                break;

            if (correos.Add(c))
                Console.WriteLine("Agregado.");
            else
                Console.WriteLine("Ya existe.");
        }
    }
}