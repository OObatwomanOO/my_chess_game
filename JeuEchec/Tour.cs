using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Tour : Piece
    {
        public Tour(Joueur c, Case p)
            : base(c, p)
        {
            Nom = "Tour";
        }

        public override List<Case> DeplacementPossible()
        {
            List<Case> PositionPossible = new List<Case>();

            int x = this.Position.Rangee;
            int y = this.Position.Colonne;

            // Mouvements verticaux (vers le haut)
            while (x > 0)
            {
                x--;
                if (Position.Echiquier.TCases[x, y].EstLibre())
                {
                    PositionPossible.Add(Position.Echiquier.TCases[x, y]);
                    continue;
                }
                else if (Position.Echiquier.TCases[x, y].Piece.Joueur != this.Joueur)
                {
                    PositionPossible.Add(Position.Echiquier.TCases[x, y]);
                }
                break;
            }
            x = this.Position.Rangee;

            // Mouvements verticaux (vers le bas)
            while (x < 7)
            {
                x++;
                if (Position.Echiquier.TCases[x, y].EstLibre())
                {
                    PositionPossible.Add(Position.Echiquier.TCases[x, y]);
                    continue;
                }
                else if (Position.Echiquier.TCases[x, y].Piece.Joueur != this.Joueur)
                {
                    PositionPossible.Add(Position.Echiquier.TCases[x, y]);
                }
                break;
            }
            x = this.Position.Rangee;

            // Mouvement horizontal (vers la droite)
            while (y < 7)
            {
                y++;
                if (Position.Echiquier.TCases[x, y].EstLibre())
                {
                    PositionPossible.Add(Position.Echiquier.TCases[x, y]);
                    continue;
                }
                else if (Position.Echiquier.TCases[x, y].Piece.Joueur != this.Joueur)
                {
                    PositionPossible.Add(Position.Echiquier.TCases[x, y]);
                }
                break;
            }
            y = this.Position.Colonne;

            // Mouvement horizontal (vers la gauche)
            while (y > 0)
            {
                y--;
                if (Position.Echiquier.TCases[x, y].EstLibre())
                {
                    PositionPossible.Add(Position.Echiquier.TCases[x, y]);
                    continue;
                }
                else if (Position.Echiquier.TCases[x, y].Piece.Joueur != this.Joueur)
                {
                    PositionPossible.Add(Position.Echiquier.TCases[x, y]);
                }
                break;
            }
            y = this.Position.Colonne;

            return PositionPossible;
        }
        
        public override void Deplacement(Case c)
        {
            this.Position.Piece = null;
            this.Position = c;
            this.Position.Piece = this;
            PremierDeplacement = true;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
