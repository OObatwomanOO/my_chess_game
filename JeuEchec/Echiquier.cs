using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Echiquier
    {
        //ATTRIBUT
        public Case[,] TCases { get; set; }
        public PartieEchec PartieEchec { get; set; }
        public ConsoleColor Color { get; set; }

        //CONSTRUCTEUR
        public Echiquier(PartieEchec pe)
        {
            TCases = new Case[8,8];
            
            for (int Rangee = 0; Rangee <8; Rangee++) 
            {
                for (int Colonne = 0; Colonne <8; Colonne++)
                {
                    TCases[Rangee, Colonne] = new Case(Colonne, Rangee, this); // this = la case a comme échiquier cet échiquier
                                    }
            }
            PartieEchec = pe;
        }

        //METHODE
        public void Afficher()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            string resultat = "";     
            resultat += "\n\t   a\t   b\t   c\t   d\t   e\t   f\t   g\t   h";
            resultat += ("\n\t _______ _______ _______ _______ _______ _______ _______ _______");  // pas de Console.WriteLine dans ToString()
            for (int i = 0; i < 8; i++)  //Rangée
            {
                resultat += "\n\t|       |       |       |       |       |       |       |       |";
                resultat += "\n\t|       |       |       |       |       |       |       |       |\n";
                resultat += "     " + (8 - i).ToString() + "\t";
                for (int j = 0; j < 8; j++)  //Colonne
                {
                    resultat += "| " + TCases[i, j].ToString() + "\t";  // concatène dans "resultat" les valeurs du tableau de cases nommé TCases 

                }
                resultat += "|  " + (8 - i).ToString();
                resultat += "\n\t|       |       |       |       |       |       |       |       |";
                resultat += "\n\t|_______|_______|_______|_______|_______|_______|_______|_______|";
            }
            resultat += "\n\t   a\t   b\t   c\t   d\t   e\t   f\t   g\t   h";
            return resultat;
        }


    }
}