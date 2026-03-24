using System;

class Program
{
    static void Main()
    {
        string opcion;

        do
        {
            Console.WriteLine("\n1. Saludar");
            Console.WriteLine("2. Mostrar fecha");
            Console.WriteLine("3. Cuadrado");
            Console.WriteLine("4. Salir");
            Console.Write("Opción: ");

            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Hola!");
                    break;

                case "2":
                    Console.WriteLine("Fecha: 2026-01-01");
                    break;

                case "3":
                    Console.Write("Número: ");
                    int n = int.Parse(Console.ReadLine());
                    Console.WriteLine("Cuadrado: " + (n * n));
                    break;
            }

        } while (opcion != "4");
    }
}