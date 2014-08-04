using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Dame : Piece
    {
        public Dame(Joueur j, Case p)
            : base(j, p)
        {
            Nom = "Dame";           
        }

        public override List<Case> DeplacementPossible()
        
        {
            /*
             * Créer la liste de cases qu'on va renvoyer
             */
            List<Case> CasesPossible = new List<Case>();
            int x = this.Position.Rangee;
            int y = this.Position.Colonne;

            /*
             * Mouvements horizontaux
             */
            while (y < 7) // vers la droite
            {
                y++;
                if (Position.Echiquier.TCases[x, y].EstLibre())
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                    continue;
                }
                else if (Position.Echiquier.TCases[x, y].Piece.Joueur != this.Joueur)
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                }
                break;
            }
            y = this.Position.Colonne;
            while (y > 0) // vers la gauche
            {
                y--;
                if (Position.Echiquier.TCases[x, y].EstLibre())
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                    continue;
                }
                else if (Position.Echiquier.TCases[x, y].Piece.Joueur != this.Joueur)
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                }
                break;
            }
            y = this.Position.Colonne;

            /*
             * Mouvements verticaux
             */
            while (x > 0) // vers le haut
            {
                x--;
                if (Position.Echiquier.TCases[x, y].EstLibre())
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                    continue;
                }
                else if (Position.Echiquier.TCases[x, y].Piece.Joueur != this.Joueur)
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                }
                break;
            }
            x = this.Position.Rangee;
            while (x < 7) // vers le bas
            {
                x++;
                if (Position.Echiquier.TCases[x, y].EstLibre())
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                    continue;
                }
                else if (Position.Echiquier.TCases[x, y].Piece.Joueur != this.Joueur)
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                }
                break;
            }
            x = this.Position.Rangee;

            /*
             * Mouvements diagonaux
             */
            // Haut + Droite
            while (x > 0 && y < 7)
            {
                x--;
                y++;
                if (Position.Echiquier.TCases[x, y].EstLibre())
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                    continue;
                }
                else if (Position.Echiquier.TCases[x, y].Piece.Joueur != this.Joueur)
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                }
                break;
            }
            x = this.Position.Rangee;
            y = this.Position.Colonne;

            // Bas + Droite
            while (x < 7 && y < 7)
            {
                x++;
                y++;
                if (Position.Echiquier.TCases[x, y].EstLibre())
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                    continue;
                }
                else if (Position.Echiquier.TCases[x, y].Piece.Joueur != this.Joueur)
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                }
                break;
            }
            x = this.Position.Rangee;
            y = this.Position.Colonne;

            // Haut + Gauche
            while (x > 0 && y > 0)
            {
                x--;
                y--;
                if (Position.Echiquier.TCases[x, y].EstLibre())
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                    continue;
                }
                else if (Position.Echiquier.TCases[x, y].Piece.Joueur != this.Joueur)
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                }
                break;
            }
            x = this.Position.Rangee;
            y = this.Position.Colonne;

            // Bas + Gauche
            while (x < 7 && y > 0)
            {
                x++;
                y--;
                if (Position.Echiquier.TCases[x, y].EstLibre())
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                    continue;
                }
                else if (Position.Echiquier.TCases[x, y].Piece.Joueur != this.Joueur)
                {
                    CasesPossible.Add(Position.Echiquier.TCases[x, y]);
                }
                break;
            }
            x = this.Position.Rangee;
            y = this.Position.Colonne;

            return CasesPossible;
        }
            
        public override string ToString()
        {
            return base.ToString();
        }
    }
}