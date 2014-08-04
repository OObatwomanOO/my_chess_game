using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Fou : Piece
    {
        public Fou(Joueur j, Case p)
            : base(j, p)
        {
            Nom = "Fou";
        }

        public override List<Case> DeplacementPossible()
        {
            List<Case> casesPossibles = new List<Case>();

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (c == this.Position.Colonne) 
                    {
                        continue;
                    }
                    
                    int penteDiagonale = (r - this.Position.Rangee) / (c - this.Position.Colonne);

                    if (penteDiagonale == -1)
                    {
                        if (c - this.Position.Colonne < 0)
                        {
                            int i = this.Position.Rangee + 1;
                            int j = this.Position.Colonne - 1;

                            while (i <= r && j >= c)
                            {
                                if (this.Position.Echiquier.TCases[i, j].EstLibre())
                                {
                                    casesPossibles.Add(this.Position.Echiquier.TCases[i, j]);
                                    i++;
                                    j--;
                                }

                                else if (this.Position.Echiquier.TCases[i, j].Piece.Joueur != this.Joueur)
                                {
                                    casesPossibles.Add(this.Position.Echiquier.TCases[i, j]);
                                    break;
                                }

                                else if (this.Position.Echiquier.TCases[i, j].Piece.Joueur == this.Joueur)
                                {
                                    break;
                                }
                            }
                        }

                        else if (c - this.Position.Colonne > 0)
                        {
                            int i = this.Position.Rangee - 1;
                            int j = this.Position.Colonne + 1;

                            while (i >= r&& j <= c)
                            {
                                if (this.Position.Echiquier.TCases[i, j].EstLibre())
                                {
                                    casesPossibles.Add(this.Position.Echiquier.TCases[i, j]);
                                    i--;
                                    j++;
                                }

                                else if (this.Position.Echiquier.TCases[i, j].Piece.Joueur != this.Joueur)
                                {
                                    casesPossibles.Add(this.Position.Echiquier.TCases[i, j]);
                                    break;
                                }

                                else if (this.Position.Echiquier.TCases[i, j].Piece.Joueur == this.Joueur)
                                {
                                    break;
                                }
                            }
                        }
                    }

                    else if (penteDiagonale == 1)
                    {
                        if (c - this.Position.Colonne < 0)
                        {
                            int i = this.Position.Rangee - 1;
                            int j = this.Position.Colonne - 1;

                            while (i >= r && j >= c)
                            {
                                if (this.Position.Echiquier.TCases[i, j].EstLibre())
                                {
                                    casesPossibles.Add(this.Position.Echiquier.TCases[i, j]);
                                    i--;
                                    j--;
                                }

                                else if (this.Position.Echiquier.TCases[i, j].Piece.Joueur != this.Joueur)
                                {
                                    casesPossibles.Add(this.Position.Echiquier.TCases[i, j]);
                                    break;
                                }

                                else if (this.Position.Echiquier.TCases[i, j].Piece.Joueur == this.Joueur)
                                {
                                    break;
                                }
                            }
                        }

                        else if (c - this.Position.Colonne > 0)
                        {
                            int i = this.Position.Rangee + 1;
                            int j = this.Position.Colonne + 1;

                            while (i <= r&& j <= c)
                            {
                                if (this.Position.Echiquier.TCases[i, j].EstLibre())
                                {
                                    casesPossibles.Add(this.Position.Echiquier.TCases[i, j]);
                                    i++;
                                    j++;
                                }

                                else if (this.Position.Echiquier.TCases[i, j].Piece.Joueur != this.Joueur)
                                {
                                    casesPossibles.Add(this.Position.Echiquier.TCases[i, j]);
                                    break;
                                }

                                else if (this.Position.Echiquier.TCases[i, j].Piece.Joueur == this.Joueur)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }

/*
            // Mouvements diagonaux (code alternatif)
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

            // Haut && Gauche
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

            // Bas && Gauche
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
*/

            return casesPossibles;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
