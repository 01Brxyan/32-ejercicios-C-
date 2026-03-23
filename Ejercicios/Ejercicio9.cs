using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Colecciones
        var preregistrados = new HashSet<Participante>();
        var registroManual = new HashSet<Participante>();
        var invitadosVip = new HashSet<Participante>();
        var listaNegra = new HashSet<Participante>();
        var asistentesReales = new HashSet<Participante>();
        var inscripciones = new HashSet<InscripcionTaller>();

        var duplicados = new List<string>();
        var rechazados = new List<string>();

        // Datos de prueba (incluye duplicados)
        AddWithLog(preregistrados, new Participante("123", "Ana Torres", "ana@gmail.com"), duplicados);
        AddWithLog(preregistrados, new Participante("123", "Ana T.", "anatorres@gmail.com"), duplicados);

        AddWithLog(registroManual, new Participante("999", "Luis Díaz", "LDiaz@correo.com"), duplicados);
        AddWithLog(registroManual, new Participante("888", "Luis D.", "ldiaz@correo.com "), duplicados);

        AddWithLog(invitadosVip, new Participante("555", "Carlos Ruiz", "carlos@correo.com", true), duplicados);

        AddWithLog(listaNegra, new Participante("123", "Ana Torres", "ana@gmail.com"), duplicados);

        AddWithLog(asistentesReales, new Participante("555", "Carlos Ruiz", "carlos@correo.com"), duplicados);
        AddWithLog(asistentesReales, new Participante("777", "Invitado Fake", "fake@correo.com"), duplicados);

        // Talleres
        var t1 = new Taller("Microservicios", new TimeOnly(9, 0), new TimeOnly(11, 0), 1);
        var t2 = new Taller("Docker", new TimeOnly(10, 0), new TimeOnly(12, 0), 1);

        // Autorizados = unión - lista negra
        var autorizados = new HashSet<Participante>(preregistrados);
        autorizados.UnionWith(registroManual);
        autorizados.UnionWith(invitadosVip);
        autorizados.ExceptWith(listaNegra);

        // No autorizados
        var noAutorizados = new HashSet<Participante>(asistentesReales);
        noAutorizados.ExceptWith(autorizados);

        // Ausentes
        var ausentes = new HashSet<Participante>(autorizados);
        ausentes.ExceptWith(asistentesReales);

        // Intentos de inscripción
        var p1 = preregistrados.First();
        var p2 = registroManual.First();

        TryInscribir(p1, t1, autorizados, inscripciones, rechazados);
        TryInscribir(p1, t2, autorizados, inscripciones, rechazados); // cruce

        TryInscribir(p2, t1, autorizados, inscripciones, rechazados);
        TryInscribir(new Participante("000", "No autorizado", "x@x.com"), t1, autorizados, inscripciones, rechazados);

        // Reporte
        Console.WriteLine("===== REPORTE FINAL =====");

        Console.WriteLine($"Preregistrados: {preregistrados.Count}");
        Console.WriteLine($"Registro manual: {registroManual.Count}");
        Console.WriteLine($"VIP: {invitadosVip.Count}");
        Console.WriteLine($"Lista negra: {listaNegra.Count}");
        Console.WriteLine($"Autorizados: {autorizados.Count}");
        Console.WriteLine($"Asistentes: {asistentesReales.Count}");

        Console.WriteLine("\nNo autorizados:");
        foreach (var p in noAutorizados)
            Console.WriteLine(p);

        Console.WriteLine("\nAusentes:");
        foreach (var p in ausentes)
            Console.WriteLine(p);

        Console.WriteLine("\nRechazados:");
        foreach (var r in rechazados)
            Console.WriteLine(r);

        Console.WriteLine("\nDuplicados detectados:");
        foreach (var d in duplicados)
            Console.WriteLine(d);
    }

    // Agrega y detecta duplicados
    static void AddWithLog(HashSet<Participante> set, Participante p, List<string> log)
    {
        if (!set.Add(p))
            log.Add($"Duplicado detectado: {p.Documento} | {p.EmailNormalizado}");
    }

    // Validación de inscripción
    static void TryInscribir(Participante p, Taller t, HashSet<Participante> autorizados,
        HashSet<InscripcionTaller> inscripciones, List<string> rechazados)
    {
        // no autorizado
        if (!autorizados.Contains(p))
        {
            rechazados.Add($"{p.Nombre} -> {t.Nombre} | No autorizado");
            return;
        }

        // capacidad
        int inscritos = inscripciones.Count(i => i.Taller.Equals(t));
        if (inscritos >= t.Capacidad)
        {
            rechazados.Add($"{p.Nombre} -> {t.Nombre} | Sin cupo");
            return;
        }

        // cruce horario
        var yaInscrito = inscripciones.Where(i => i.Participante.Equals(p));
        foreach (var ins in yaInscrito)
        {
            if (Cruza(ins.Taller, t))
            {
                rechazados.Add($"{p.Nombre} -> {t.Nombre} | Cruce horario");
                return;
            }
        }

        inscripciones.Add(new InscripcionTaller(p, t));
    }

    // verifica cruce de horario
    static bool Cruza(Taller a, Taller b)
    {
        return a.HoraInicio < b.HoraFin && b.HoraInicio < a.HoraFin;
    }
}

// PARTICIPANTE con igualdad personalizada
class Participante : IEquatable<Participante>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Documento { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public bool EsVip { get; set; }

    public string EmailNormalizado => Email.Trim().ToLower();

    public Participante(string doc, string nombre, string email, bool vip = false)
    {
        Documento = doc;
        Nombre = nombre;
        Email = email;
        EsVip = vip;
    }

    public bool Equals(Participante other)
    {
        if (other == null) return false;

        return Documento == other.Documento ||
               EmailNormalizado == other.EmailNormalizado;
    }

    public override bool Equals(object obj) => Equals(obj as Participante);

    public override int GetHashCode()
    {
        return (Documento + EmailNormalizado).GetHashCode();
    }

    public override string ToString()
    {
        return $"{Nombre} | DOC: {Documento} | EMAIL: {EmailNormalizado}";
    }
}

// TALLER
class Taller
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nombre { get; set; }
    public TimeOnly HoraInicio { get; set; }
    public TimeOnly HoraFin { get; set; }
    public int Capacidad { get; set; }

    public Taller(string nombre, TimeOnly inicio, TimeOnly fin, int cap)
    {
        Nombre = nombre;
        HoraInicio = inicio;
        HoraFin = fin;
        Capacidad = cap;
    }
}

// INSCRIPCIÓN
class InscripcionTaller
{
    public Participante Participante { get; set; }
    public Taller Taller { get; set; }

    public InscripcionTaller(Participante p, Taller t)
    {
        Participante = p;
        Taller = t;
    }
}