using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Case
    {
        //ATTRIBUTS
        public int Colonne { get; set; }
        public int Rangee { get; set; }
        public string Nom { get; set; }
        public Piece Piece { get; set; }
        public Echiquier Echiquier { get; set; }

        //CONSTRUCTEUR
        public Case(int c, int r, string n, Piece p, Echiquier e) // initialisation
        {
            Colonne = c;
            Rangee = r;
            Nom = n;
            Piece = p;
            Echiquier = e;
        }

        public Case(int c, int r, Echiquier e) // valeur
        {
            Piece = null;

            Colonne = c;
            Rangee = r;

            Nom = "";
            string Alpha = "abcdefgh";

            string r2 = (8 - Rangee).ToString();
            string c2 = Alpha[Colonne].ToString();

            Nom = c2 + r2; // Nom = Alpha[Colonne].ToString() + (8 - Rangee).ToString();
            
            Echiquier = e; 
            /* 
             * l'échiquier est attribué à la case
             * dans le constructeur de l'échiquier
             * grâce au mot clé "this"
             */
        }

        //METHODE
        public bool EstLibre()
        {
            bool EstLibre = true;

            if (Piece == null)
            {
                EstLibre = true;
            }
            else if(Piece != null)
            {
                EstLibre = false;
            }

            return EstLibre;
        }

        public override string ToString()
        {
            string resultat = "";  // va être concaténé

            if (EstLibre())  // vérification
            {
                resultat += " ";  // pour représenter une case vide -> laisser un espace entre les guillemets !
            }
            else
            {
                resultat += Piece.ToString();  // pour représenter la pièce dans la case (si la case n'est pas vide)
            }

            return resultat;  // à la fin de la procédure, on renvoie le resultat de la boucle
        }
        
    }
}
