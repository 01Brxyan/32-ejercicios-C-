using System;

class Program
{
    static void Main()
    {
        int suma = 0;

        while (true)
        {
            Console.Write("Ingrese un número (0 para salir): ");
            int num = int.Parse(Console.ReadLine());

            if (num == 0)
                break;

            suma += num; // acumula
        }

        Console.WriteLine("Suma total: " + suma);
    }
}