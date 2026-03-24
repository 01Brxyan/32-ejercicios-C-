using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var lista = new List<int>();

        for (int i = 0; i < 8; i++)
        {
            Console.Write("Número: ");
            lista.Add(int.Parse(Console.ReadLine()));
        }

        int mayor = lista[0];
        int menor = lista[0];
        int suma = 0;

        foreach (var n in lista)
        {
            if (n > mayor) mayor = n;
            if (n < menor) menor = n;
            suma += n;
        }

        double promedio = (double)suma / lista.Count;

        Console.WriteLine("Mayor: " + mayor);
        Console.WriteLine("Menor: " + menor);
        Console.WriteLine("Promedio: " + promedio);
    }
}