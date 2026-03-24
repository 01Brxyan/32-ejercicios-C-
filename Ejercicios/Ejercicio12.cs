using System;

class Program
{
    static void Main()
    {
        int contador = 0;

        for (int i = 1; i <= 100; i++)
        {
            // verifica si es par
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
                contador++; // cuenta los pares
            }
        }

        Console.WriteLine($"\nTotal de números pares: {contador}");
    }
}