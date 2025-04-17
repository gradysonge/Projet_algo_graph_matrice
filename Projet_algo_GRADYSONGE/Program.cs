
using System;
using System.Collections.Generic;

namespace Projet_algo_GRADYSONGE
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1) Calcul matriciel");
                Console.WriteLine("2) Algorithme de Prim");
                Console.WriteLine("3) Quitter");
                Console.Write("Votre choix : ");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        MatriceWorkflow(); break;
                    case "2":
                        PrimWorkflow(); break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Choix invalide."); break;
                }
            }
        }

        static void MatriceWorkflow()
        {
            var m = new Matrix3x3();
            m.ReadFromConsole();
            m.Print();
            double det = m.Determinant();
            Console.WriteLine($"\nDéterminant = {det:F4}");

            var inv = m.Inverse();
            if (inv is null)
                Console.WriteLine("La matrice n'est PAS inversible.");
            else
                inv.Print("Inverse");
        }

        static void PrimWorkflow()
        {
            // Graphe d'exemple 5 sommets A‑E
            var g = new Graph(5);
            g.AddEdge(0, 1, 9); g.AddEdge(0, 2, 5); g.AddEdge(0, 3, 2);
            g.AddEdge(1, 3, 6); g.AddEdge(1, 4, 4); g.AddEdge(2, 4, 5);
            g.AddEdge(2, 3, 4); g.AddEdge(3, 4, 5);

            var (tree, cost) = g.Prim();
            Console.WriteLine("\nArêtes de l’ACM (Prim) :");
            foreach (var e in tree)
                Console.WriteLine($"({(char)('A' + e.From)} – {(char)('A' + e.To)})  coût = {e.Cost}");
            Console.WriteLine($"Coût total = {cost}");
        }
    }
}
