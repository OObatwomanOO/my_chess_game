using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Program
    {
        static void Main(string[] args)
        {
            PartieEchec p1 = new PartieEchec();

            bool b = true;
            while (b == true)
            {
                b = p1.Jouer();
            }
            Console.WriteLine("\nBravo joueur {0}, vous avez gagné!", p1.JoueurCourant.Couleur);

            Console.ReadLine();
        }
    }
}
