using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var grafo = new Grafo();

        // conexiones
        grafo.AgregarArista("A", "B", 4);
        grafo.AgregarArista("A", "C", 2);
        grafo.AgregarArista("C", "B", 1);
        grafo.AgregarArista("B", "D", 5);
        grafo.AgregarArista("C", "D", 8);
        grafo.AgregarArista("C", "E", 10);
        grafo.AgregarArista("D", "E", 2);
        grafo.AgregarArista("D", "F", 6);
        grafo.AgregarArista("E", "F", 3);

        Console.Write("Punto de inicio: ");
        string inicio = Console.ReadLine().ToUpper();

        Console.Write("Punto destino: ");
        string fin = Console.ReadLine().ToUpper();

        var resultado = grafo.Dijkstra(inicio, fin);

        if (resultado == null)
        {
            Console.WriteLine("No existe ruta.");
        }
        else
        {
            Console.WriteLine("\nRuta de menor consumo:");
            Console.WriteLine(string.Join(" -> ", resultado.Ruta));

            Console.WriteLine("Consumo total: " + resultado.Costo);
        }
    }
}

// resultado de Dijkstra
class Resultado
{
    public List<string> Ruta { get; set; }
    public int Costo { get; set; }
}

// grafo
class Grafo
{
    private Dictionary<string, List<(string destino, int costo)>> adj =
        new Dictionary<string, List<(string, int)>>();

    public void AgregarArista(string origen, string destino, int costo)
    {
        if (!adj.ContainsKey(origen))
            adj[origen] = new List<(string, int)>();

        adj[origen].Add((destino, costo));

        // asegurar que el nodo destino exista
        if (!adj.ContainsKey(destino))
            adj[destino] = new List<(string, int)>();
    }

    public Resultado Dijkstra(string inicio, string fin)
    {
        var dist = new Dictionary<string, int>();
        var prev = new Dictionary<string, string>();
        var visitados = new HashSet<string>();

        // inicializa las distancias
        foreach (var nodo in adj.Keys)
            dist[nodo] = int.MaxValue;

        dist[inicio] = 0;

        while (visitados.Count < adj.Count)
        {
            // nodo no visitado con menor distancia
            string actual = null;
            int min = int.MaxValue;

            foreach (var nodo in adj.Keys)
            {
                if (!visitados.Contains(nodo) && dist[nodo] < min)
                {
                    min = dist[nodo];
                    actual = nodo;
                }
            }

            if (actual == null)
                break;

            visitados.Add(actual);

            // actualiza vecinos
            foreach (var vecino in adj[actual])
            {
                int nuevaDist = dist[actual] + vecino.costo;

                if (nuevaDist < dist[vecino.destino])
                {
                    dist[vecino.destino] = nuevaDist;
                    prev[vecino.destino] = actual;
                }
            }
        }

        // si no hay ruta
        if (!dist.ContainsKey(fin) || dist[fin] == int.MaxValue)
            return null;

        // La recoonstruye 
        var ruta = new List<string>();
        string temp = fin;

        while (temp != null)
        {
            ruta.Insert(0, temp);
            prev.TryGetValue(temp, out temp);
        }

        return new Resultado
        {
            Ruta = ruta,
            Costo = dist[fin]
        };
    }
}