using System;

class Program
{
    static void Main()
    {
        int pos = 0, neg = 0, ceros = 0;

        for (int i = 0; i < 10; i++)
        {
            Console.Write("Número: ");
            int n = int.Parse(Console.ReadLine());

            if (n > 0) pos++;
            else if (n < 0) neg++;
            else ceros++;
        }

        Console.WriteLine($"Positivos: {pos}");
        Console.WriteLine($"Negativos: {neg}");
        Console.WriteLine($"Ceros: {ceros}");
    }
}