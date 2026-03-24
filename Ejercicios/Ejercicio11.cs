using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var estudiantes = new HashSet<Estudiante>();

        while (true)
        {
            Console.WriteLine("\n===== MENÚ =====");
            Console.WriteLine("1. Registrar estudiante");
            Console.WriteLine("2. Mostrar estudiantes");
            Console.WriteLine("3. Buscar por código");
            Console.WriteLine("4. Salir");
            Console.Write("Opción: ");

            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("Ingrese código: ");
                string codigo = Console.ReadLine();

                Console.Write("Ingrese nombre: ");
                string nombre = Console.ReadLine();

                var estudiante = new Estudiante(codigo, nombre);

                // intenta agregar
                if (estudiantes.Add(estudiante))
                    Console.WriteLine("Estudiante agregado correctamente.");
                else
                    Console.WriteLine("El estudiante ya está registrado.");
            }
            else if (opcion == "2")
            {
                Console.WriteLine("\nEstudiantes registrados:");

                foreach (var e in estudiantes)
                {
                    Console.WriteLine($"- Código: {e.Codigo} | Nombre: {e.Nombre}");
                }
            }
            else if (opcion == "3")
            {
                Console.Write("Ingrese código a buscar: ");
                string codigo = Console.ReadLine().Trim().ToUpper();

                var encontrado = estudiantes.FirstOrDefault(e => e.Codigo == codigo);

                if (encontrado != null)
                    Console.WriteLine($"Encontrado: {encontrado.Codigo} - {encontrado.Nombre}");
                else
                    Console.WriteLine("No se encontró el estudiante.");
            }
            else if (opcion == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
    }
}

// clase con igualdad
class Estudiante
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }

    public Estudiante(string codigo, string nombre)
    {
        // normaliza
        Codigo = codigo.Trim().ToUpper();
        Nombre = nombre;
    }

    // igualdad
    public override bool Equals(object obj)
    {
        var other = obj as Estudiante;
        if (other == null) return false;

        return Codigo == other.Codigo;
    }

    // hash
    public override int GetHashCode()
    {
        return Codigo.GetHashCode();
    }
}