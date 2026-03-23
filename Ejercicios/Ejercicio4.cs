using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Ingresa un texto: ");
        string input = Console.ReadLine();

        var result = CountChars(input);

        foreach (var item in result)
        {
            Console.WriteLine($"{{ Car = '{item.Car}', Veces = {item.Veces} }}");
        }
    }

    static List<Result> CountChars(string text)
    {
        var dict = new Dictionary<char, int>();

        // quitar tildes
        string normalized = text.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();

        foreach (char c in normalized)
        {
            var unicode = Char.GetUnicodeCategory(c);
            if (unicode != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c);
            }
        }

        string clean = sb.ToString().ToLower();

        foreach (char c in clean)
        {
            if (char.IsLetterOrDigit(c))
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict[c] = 1;
            }
        }

        return dict
            .OrderBy(x => x.Key)
            .Select(x => new Result { Car = x.Key, Veces = x.Value })
            .ToList();
    }
}

class Result
{
    public char Car { get; set; }
    public int Veces { get; set; }
}