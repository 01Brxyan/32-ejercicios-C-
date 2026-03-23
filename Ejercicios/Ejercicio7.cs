using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine(SimbEquilibrados("[1+x+3*(y-5)]")); // -1
        Console.WriteLine(SimbEquilibrados("[1+x)"));         // 4
        Console.WriteLine(SimbEquilibrados("}1+x"));          // 0
    }

    static int SimbEquilibrados(string text)
    {
        var stack = new Stack<(char simbolo, int index)>();

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];

            // si abre y guarda
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push((c, i));
            }
            // si cierra
            else if (c == ')' || c == ']' || c == '}')
            {
                // cierra sin apertura
                if (stack.Count == 0)
                    return i;

                var top = stack.Pop();

                // no coincide
                if (!EsPar(top.simbolo, c))
                    return i;
            }
        }

        // quedaron abiertos sin cerrar
        if (stack.Count > 0)
            return stack.Peek().index;

        // todo bien
        return -1;
    }

    static bool EsPar(char open, char close)
    {
        return (open == '(' && close == ')') ||
               (open == '[' && close == ']') ||
               (open == '{' && close == '}');
    }
}