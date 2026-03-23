using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var correos = new HashSet<string>();

        while (true)
        {
            Console.Write("Ingrese un correo (o 'salir'): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "salir")
                break;

            // normaliza (evita duplicados por espacios o mayúsculas)
            string email = input.Trim().ToLower();

            // intenta agregar
            if (correos.Add(email))
                Console.WriteLine("Correo agregado correctamente.");
            else
                Console.WriteLine("El correo ya estaba registrado.");
        }

        // muestra resultados
        Console.WriteLine("\nCorreos registrados:");
        foreach (var c in correos)
        {
            Console.WriteLine("- " + c);
        }
    }
}