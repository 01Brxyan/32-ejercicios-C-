using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var edades = new List<int>();

        while (true)
        {
            Console.Write("Edad (-1 para salir): ");
            int e = int.Parse(Console.ReadLine());

            if (e == -1)
                break;

            edades.Add(e);
        }

        int suma = 0, mayores = 0, menores = 0;

        foreach (var e in edades)
        {
            suma += e;

            if (e >= 18) mayores++;
            else menores++;
        }

        double promedio = (double)suma / edades.Count;

        Console.WriteLine("Cantidad: " + edades.Count);
        Console.WriteLine("Promedio: " + promedio);
        Console.WriteLine("Mayores de edad: " + mayores);
        Console.WriteLine("Menores de edad: " + menores);
    }
}