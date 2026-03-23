using System;

class Program
{
    static void Main()
    {
        string text = "abc";
        Permutaciones(text, "");
    }

    static void Permutaciones(string input, string actual)
    {
        // Caso base
        if (input.Length == 0)
        {
            Console.WriteLine(actual);
            return;
        }

        for (int i = 0; i < input.Length; i++)
        {
            // toma un carácter
            char c = input[i];

            // quitar ese carácter del string
            string restante = input.Substring(0, i) + input.Substring(i + 1);

            // sigue construyendo
            Permutaciones(restante, actual + c);
        }
    }
}