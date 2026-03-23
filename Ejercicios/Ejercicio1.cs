using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var table = new List<string>()
        {
            "Juan P",
            "Brayan C",
            "Felipe C",
            "Andres F",
            "Andrea V"
        };

        while (true)
        {
            Console.Write("\nBusca o escribe salir: ");
            var input = Console.ReadLine();

            if (input.ToLower() == "salir")
                break;

            FilterTable(table, input);
        }
    }

    static void FilterTable(List<string> rows, string text)
    {
        Console.WriteLine("\nResultados:");

        foreach (var row in rows)
        {
            if (row.ToLower().Contains(text.ToLower()))
            {
                Console.WriteLine(row);
            }
        }
    }
}