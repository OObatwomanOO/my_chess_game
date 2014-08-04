using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    abstract class Piece
    {
        // ATTRIBUTS
        public string Nom { get; set; }
        public Joueur Joueur { get; set; }
        public Case Position { get; set; }
        public bool PremierDeplacement { get; set; }

        // CONSTRUCTEUR
        public Piece(Joueur j, Case p)
        {
            Nom = "";
            Joueur = j;
            Position = p;
            PremierDeplacement = false;
        }

        // METHODES
        public abstract List<Case> DeplacementPossible();

        public virtual bool CapturePossible(Case c)
        {
            if (c.EstLibre())
            {
                return false; // i.e. il n'y a pas de pièce à capturer dans cette case : elle est libre
            }

            else
            {
                if (c.Piece.Joueur != this.Joueur)
                {
                    return true;
                }
                else
                {
                    return false; // i.e. vous ne pouvez pas capturer cette pièce : c'est un de vos pions
                }
            }
        }

        public virtual void Capture(Piece pi)
        {
            this.Joueur.PiecesCapturees.Add(pi);
            this.Position.Echiquier.PartieEchec.Pieces.Remove(pi);
            pi.Position.Piece = null;
        }

        public virtual void Deplacement(Case c)
        {
            this.Position.Piece = null;
            this.Position = c;
            this.Position.Piece = this;
        }

        public override string ToString()
        {
            string resultat = "";
            resultat += Nom + Joueur.Couleur[0];
            return resultat;
        }
    }
}
