using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine(EsAnagrama("amor", "roma")); // true
        Console.WriteLine(EsAnagrama("rota", "otra")); // true
        Console.WriteLine(EsAnagrama("otra", "otra")); // false
    }

    static bool EsAnagrama(string a, string b)
    {
        // quitar espacios y pasar a minúscula
        string str1 = new string(a.Where(c => c != ' ').ToArray()).ToLower();
        string str2 = new string(b.Where(c => c != ' ').ToArray()).ToLower();

        // si son iguales, no es anagrama
        if (str1 == str2)
            return false;

        // si longitud distinta, no puede ser
        if (str1.Length != str2.Length)
            return false;

        // ordena caracteres
        var sorted1 = str1.OrderBy(c => c);
        var sorted2 = str2.OrderBy(c => c);

        // compara
        return sorted1.SequenceEqual(sorted2);
    }
}