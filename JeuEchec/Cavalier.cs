using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Cavalier : Piece
    {
        public Cavalier (Joueur c, Case p )
            :  base (c, p)
        {
            Nom = "Cav";
        }

        public override List<Case> DeplacementPossible()
        {

            List<Case> PositionPossible = new List<Case>();

            if (Position.Rangee + 2 <= 7 && Position.Colonne + 1 <= 7 && (Position.Echiquier.TCases[Position.Rangee + 2, Position.Colonne + 1].EstLibre()
                || (!Position.Echiquier.TCases[Position.Rangee + 2, Position.Colonne + 1].EstLibre() && Position.Echiquier.TCases[Position.Rangee + 2, Position.Colonne + 1].Piece.Joueur != this.Joueur)))
            {
            PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee + 2, Position.Colonne + 1]);
            }
            if (Position.Rangee + 2 <= 7 && Position.Colonne - 1 >= 0 && (Position.Echiquier.TCases[Position.Rangee + 2, Position.Colonne - 1].EstLibre()
                 || (!Position.Echiquier.TCases[Position.Rangee + 2, Position.Colonne - 1].EstLibre() && Position.Echiquier.TCases[Position.Rangee + 2, Position.Colonne - 1].Piece.Joueur != this.Joueur)))
            {
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee + 2, Position.Colonne - 1]);
            }
            if (Position.Rangee - 2 >= 0 && Position.Colonne + 1 <= 7 && (Position.Echiquier.TCases[Position.Rangee - 2, Position.Colonne + 1].EstLibre()
                || (!Position.Echiquier.TCases[Position.Rangee - 2, Position.Colonne + 1].EstLibre() && Position.Echiquier.TCases[Position.Rangee - 2, Position.Colonne + 1].Piece.Joueur != this.Joueur)))
            {
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee - 2, Position.Colonne + 1]);
            }
            if (Position.Rangee - 2 >= 0 && Position.Colonne - 1 >=0 && (Position.Echiquier.TCases[Position.Rangee - 2, Position.Colonne - 1].EstLibre()
                || (!Position.Echiquier.TCases[Position.Rangee - 2, Position.Colonne - 1].EstLibre() && Position.Echiquier.TCases[Position.Rangee - 2, Position.Colonne - 1].Piece.Joueur != this.Joueur)))
            {
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee - 2, Position.Colonne - 1]);
            }
            if (Position.Rangee + 1 <= 7 && Position.Colonne + 2 <= 7 && (Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne + 2].EstLibre()
                || (!Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne + 2].EstLibre() && Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne + 2].Piece.Joueur != this.Joueur)))
            {
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne + 2]);
            }
            if (Position.Rangee + 1 <= 7 && Position.Colonne - 2 >= 0 && (Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne - 2].EstLibre()
                || (!Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne - 2].EstLibre() && Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne - 2].Piece.Joueur != this.Joueur)))
            {
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne - 2]);
            }
            if (Position.Rangee  - 1 >= 0 && Position.Colonne + 2 <= 7 && (Position.Echiquier.TCases[Position.Rangee  - 1, Position.Colonne + 2].EstLibre()
                || (!Position.Echiquier.TCases[Position.Rangee  - 1, Position.Colonne + 2].EstLibre() && Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne + 2].Piece.Joueur != this.Joueur)))
            {
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne + 2]);
            }
            if (Position.Rangee - 1 >= 0 && Position.Colonne - 2 >= 0 && (Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne - 2].EstLibre()
                || (!Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne - 2].EstLibre() && Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne - 2].Piece.Joueur != this.Joueur)))
            {
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne - 2]);
            }           

            return PositionPossible;
        }
        

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
