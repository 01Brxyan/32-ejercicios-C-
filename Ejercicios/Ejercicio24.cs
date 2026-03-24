using System;
using System.Collections;

class Program
{
    static void Main()
    {
        var productos = new ArrayList();

        for (int i = 0; i < 5; i++)
        {
            Console.Write("Producto: ");
            productos.Add(Console.ReadLine());
        }

        Console.WriteLine("Inventario:");
        foreach (var p in productos)
            Console.WriteLine(p);
    }
}