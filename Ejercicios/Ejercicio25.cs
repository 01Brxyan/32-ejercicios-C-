using System;
using System.Collections;

class Program
{
    static void Main()
    {
        var datos = new ArrayList();

        datos.Add("Brayan");
        datos.Add(18);
        datos.Add(1.65);
        datos.Add(true);

        foreach (var d in datos)
        {
            Console.WriteLine(d + " - Tipo: " + d.GetType());
        }
    }
}