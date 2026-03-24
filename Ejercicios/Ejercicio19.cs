Eusing System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var notas = new List<double>();

        while (true)
        {
            Console.Write("Nota (-1 para salir): ");
            double n = double.Parse(Console.ReadLine());

            if (n == -1)
                break;

            notas.Add(n);
        }

        double suma = 0;
        int buenas = 0;

        foreach (var n in notas)
        {
            suma += n;
            if (n >= 3.0) buenas++;
        }

        double promedio = suma / notas.Count;

        Console.WriteLine("Notas:");
        foreach (var n in notas)
            Console.WriteLine(n);

        Console.WriteLine("Promedio: " + promedio);
        Console.WriteLine("Notas >= 3.0: " + buenas);
    }
}