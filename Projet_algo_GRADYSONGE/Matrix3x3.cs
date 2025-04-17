// =======================================================================
// Fichier : Matrix3x3.cs
// Auteur : Grady Songe
// Cours : IFM25932 - Algorithmes numériques
// Projet : Projet final - Calcul de matrice et Algorithme de Prim
// Description : Contient la classe Matrix3x3 pour gérer les matrices 3x3,
//               leur déterminant et leur inverse
// =======================================================================

namespace Projet_algo_GRADYSONGE
{
 
    /// Représente une matrice carrée 3x3 avec opérations de base.
  
    class Matrix3x3
    {
        public double[,] Data = new double[3, 3];

       
        /// Permet à l'utilisateur de saisir les 9 éléments de la matrice.
     
        public void ReadFromConsole()
        {
            Console.WriteLine("Saisissez les 9 éléments (ligne par ligne) :");
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"a[{i + 1},{j + 1}] = ");
                    Data[i, j] = Convert.ToDouble(Console.ReadLine());
                }
        }

   
        /// Affiche la matrice dans la console.
       
        public void Print(string title = "Matrice")
        {
            Console.WriteLine($"\n{title} :");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < 3; j++)
                    Console.Write($"{Data[i, j],8:F2} ");
                Console.WriteLine("|");
            }
        }

       
        /// Calcule le déterminant de la matrice 3x3.
      
        /// <returns>Le déterminant (double)</returns>
        public double Determinant()
        {
            double a = Data[0, 0], b = Data[0, 1], c = Data[0, 2];
            double d = Data[1, 0], e = Data[1, 1], f = Data[1, 2];
            double g = Data[2, 0], h = Data[2, 1], i = Data[2, 2];

            // Formule du déterminant d'une matrice 3x3
            return a * (e * i - f * h)
                 - b * (d * i - f * g)
                 + c * (d * h - e * g);
        }

        /// Calcule l'inverse de la matrice si elle est inversible.
  
        /// <returns>Nouvelle matrice inverse ou null si non inversible</returns>
        public Matrix3x3? Inverse()
        {
            double det = Determinant();
            if (Math.Abs(det) < 1e-8) return null;

            var inv = new Matrix3x3();

            // Calcul de la matrice inverse par la méthode des cofacteurs
            inv.Data[0, 0] = (Data[1, 1] * Data[2, 2] - Data[1, 2] * Data[2, 1]) / det;
            inv.Data[0, 1] = -(Data[0, 1] * Data[2, 2] - Data[0, 2] * Data[2, 1]) / det;
            inv.Data[0, 2] = (Data[0, 1] * Data[1, 2] - Data[0, 2] * Data[1, 1]) / det;

            inv.Data[1, 0] = -(Data[1, 0] * Data[2, 2] - Data[1, 2] * Data[2, 0]) / det;
            inv.Data[1, 1] = (Data[0, 0] * Data[2, 2] - Data[0, 2] * Data[2, 0]) / det;
            inv.Data[1, 2] = -(Data[0, 0] * Data[1, 2] - Data[0, 2] * Data[1, 0]) / det;

            inv.Data[2, 0] = (Data[1, 0] * Data[2, 1] - Data[1, 1] * Data[2, 0]) / det;
            inv.Data[2, 1] = -(Data[0, 0] * Data[2, 1] - Data[0, 1] * Data[2, 0]) / det;
            inv.Data[2, 2] = (Data[0, 0] * Data[1, 1] - Data[0, 1] * Data[1, 0]) / det;

            return inv;
        }
    }
}
