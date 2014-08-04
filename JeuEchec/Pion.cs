using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Pion : Piece
    {
        public Pion(Joueur c, Case p)
            : base(c, p)
        {
            Nom = "Pion";
        }

       
        public override List<Case> DeplacementPossible()
        {
            List<Case> PositionPossible = new List<Case>();
            
            //diagonale Blanc
            if (Joueur.Couleur == "Blanc" && Position.Rangee - 1 >= 0 && Position.Colonne + 1 <= 7 && !Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne + 1].EstLibre()
                && Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne + 1].Piece.Joueur != this.Joueur)
                { PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne + 1]); }

                else if (Joueur.Couleur == "Blanc" && Position.Rangee - 1 >= 0 && Position.Colonne - 1 >= 0 && !Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne-1].EstLibre()
                && Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne - 1].Piece.Joueur != this.Joueur)
                { PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne - 1]); }

            //diagonale Noir
            if (Joueur.Couleur == "Noir" && Position.Rangee + 1 <= 7 && Position.Colonne + 1 <= 7  && !Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne + 1].EstLibre()
                && Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne + 1].Piece.Joueur != this.Joueur)
            { PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne + 1]); }

            else if (Joueur.Couleur == "Noir" && Position.Rangee + 1 <= 7 && Position.Colonne - 1 >= 0 && !Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne - 1].EstLibre()
                && Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne - 1].Piece.Joueur != this.Joueur)
            { PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne - 1]); }

            //pion Blanc
            if (Joueur.Couleur == "Blanc" && Position.Rangee - 1 >= 0 && Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne].EstLibre())
            {               
                if (!PremierDeplacement)
                {
                    PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne]);

                    if (Position.Echiquier.TCases[Position.Rangee - 2, Position.Colonne].EstLibre())
                    {
                        PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee - 2, Position.Colonne]);
                    }
                }
                else { PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne]); }
            }

            //pion Noir
            else if (Position.Rangee + 1 <= 7 && Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne].EstLibre())
            {
               

                if (!PremierDeplacement)
                {
                    PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne]);
                    if (Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne].EstLibre()) { PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee + 2, Position.Colonne]); }
                }
                else { PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne]); }

            }

            return PositionPossible;
        }

        public override bool CapturePossible(Case c)
        {
            if (this.Joueur.Couleur == "Blanc" && c.Rangee == Position.Rangee-1 && c.Colonne== Position.Colonne-1||c.Rangee == Position.Rangee-1 && c.Colonne== Position.Colonne+1)
            {
                if (c.EstLibre())
                {
                   // Console.WriteLine("Il n'y a pas de pièce à capturer dans cette case : elle est libre.");
                    return false;
                }

                else
                {


                    if (c.Piece.Joueur != this.Joueur)
                    {
                        return true;
                    }
                    else
                    {
                        //Console.WriteLine("Vous ne pouvez pas capturer cette pièce : c'est un de vos pions !");
                        return false;
                    }
                }
            }
            else if (this.Joueur.Couleur == "Noir" && c.Rangee == Position.Rangee + 1 && c.Colonne == Position.Colonne - 1 || c.Rangee == Position.Rangee + 1 && c.Colonne == Position.Colonne + 1)
            {

                if (c.EstLibre())
                {
                    //Console.WriteLine("Il n'y a pas de pièce à capturer dans cette case : elle est libre.");
                    return false;
                }

                else
                {
                    if (c.Piece.Joueur != this.Joueur)
                    {
                        return true;
                    }
                    else
                    {
                        //Console.WriteLine("Vous ne pouvez pas capturer cette pièce : c'est un de vos pions !");
                        return false;
                    }
                }
            }
            else 
            {
               // Console.WriteLine("Le pion ne peut capturer une pièce adverse que sur sa diagonale.");
                return false;
            }                       
        }

        public override void Deplacement(Case c)
        {
            this.Position.Piece = null;
            this.Position = c;
            this.Position.Piece = this;
            PremierDeplacement = true;
        }

        public void Promotion(Piece c)
        {
            if(Joueur.Couleur == "Blanc" && Position.Rangee == 0)
            {
                c.Position=this.Position;
                this.Position.Piece = c;               
            }
            else if(Joueur.Couleur == "Noir" && Position.Rangee == 7)
            {
                c.Position = this.Position;
                this.Position.Piece = c;
            }
        
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
