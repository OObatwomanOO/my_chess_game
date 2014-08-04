using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Joueur
    {
        // ATTRIBUTS
        public PartieEchec PartieEchec { get; set; }
        public string Couleur { get; set; }
        public List<Piece> PiecesCapturees { get; set; }

        // CONSTRUCTEUR
        public Joueur(PartieEchec pe, string c, List<Piece> lpic)
        {
            PartieEchec = pe;
            Couleur = c;
            PiecesCapturees = lpic;
        }

        public Joueur(PartieEchec pe, string c)
        {
            PartieEchec = pe;            
            Couleur = c;
            PiecesCapturees = new List<Piece>();
        }

        // METHODES
        public override string ToString ()
        {
            string resultat = "";
            resultat += "Couleur : " + Couleur + "\n";
            resultat += "Liste des pièces capturées: \n";
            foreach (Piece pi in PiecesCapturees)
            {
                resultat += pi.ToString() + "\n";
            }
            return resultat;
        }
    }
}
