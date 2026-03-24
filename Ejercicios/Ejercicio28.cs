using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var lista = new List<string>();
        string op;

        do
        {
            Console.WriteLine("\n1. Agregar");
            Console.WriteLine("2. Mostrar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Salir");
            Console.Write("Opción: ");

            op = Console.ReadLine();

            switch (op)
            {
                case "1":
                    Console.Write("Producto: ");
                    lista.Add(Console.ReadLine());
                    break;

                case "2":
                    foreach (var p in lista)
                        Console.WriteLine(p);
                    break;

                case "3":
                    Console.Write("Nombre a eliminar: ");
                    string nombre = Console.ReadLine();
                    lista.Remove(nombre); // elimina si existe
                    break;
            }

        } while (op != "4");
    }
}