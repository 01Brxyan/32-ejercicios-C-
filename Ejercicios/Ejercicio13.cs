using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese un número: ");
        int numero = int.Parse(Console.ReadLine());

        for (int i = 1; i <= 10; i++)
        {
            // muestra la multiplicación
            Console.WriteLine(numero + " x " + i + " = " + (numero * i));
        }
    }
}