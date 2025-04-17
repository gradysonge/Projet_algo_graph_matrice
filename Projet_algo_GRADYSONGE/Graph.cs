
using System.Collections.Generic;

namespace Projet_algo_GRADYSONGE
{
    
    /// Représente une arête entre deux sommets avec un coût.
  
    class Edge
    {
        public int From, To, Cost;

        public Edge(int f, int t, int c)
        {
            From = f;
            To = t;
            Cost = c;
        }
    }

   
    /// Représente un graphe non orienté et contient l'implémentation de l’algorithme de Prim.
  
    class Graph
    {
        public int V; // Nombre de sommets
        public List<Edge> Edges = new(); // Liste des arêtes

        public Graph(int v) => V = v;


        /// Ajoute une arête au graphe.
       
        public void AddEdge(int u, int v, int cost)
            => Edges.Add(new Edge(u, v, cost));

        /// Exécute l'algorithme de Prim pour trouver l'arbre couvrant minimal (ACM).
        
        public (List<Edge> tree, int totalCost) Prim(int start = 0)
        {
            var visited = new bool[V];
            var pq = new SortedSet<(int cost, int from, int to)>();

            // Ajouter les arêtes du sommet de départ
            void AddEdges(int u)
            {
                visited[u] = true;
                foreach (var e in Edges)
                    if ((e.From == u && !visited[e.To]) ||
                        (e.To == u && !visited[e.From]))
                        pq.Add((e.Cost, e.From, e.To));
            }

            var tree = new List<Edge>();
            int total = 0;
            AddEdges(start);

            // Tant qu’on n’a pas construit l’ACM
            while (pq.Count > 0 && tree.Count < V - 1)
            {
                var (c, f, t) = pq.Min;
                pq.Remove(pq.Min);
                int next = visited[f] ? t : f;
                if (visited[next]) continue;

                tree.Add(new Edge(f, t, c));
                total += c;
                AddEdges(next);
            }

            return (tree, total);
        }
    }
}
