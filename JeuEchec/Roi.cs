using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Roi : Piece
    {
        public Roi(Joueur c, Case p)
            : base(c, p)
        {
            Nom = "Roi";
        }

        public override List<Case> DeplacementPossible()
        {
            List<Case> PositionPossible = new List<Case>();

            if (Position.Colonne + 1 <= 7  && (Position.Echiquier.TCases[Position.Rangee, Position.Colonne + 1].EstLibre()
                || Position.Echiquier.TCases[Position.Rangee, Position.Colonne + 1].Piece.Joueur != this.Joueur) && !Echec(Position.Echiquier.TCases[Position.Rangee, Position.Colonne + 1]))
            { 
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee, Position.Colonne + 1]); 
            }

            if (Position.Rangee - 1 >= 0 && Position.Colonne + 1 <= 7 && (Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne + 1].EstLibre()
                || Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne + 1].Piece.Joueur != this.Joueur) && !Echec(Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne + 1]))
            { 
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne + 1]); 
            }

            if (Position.Rangee - 1 >= 0  &&( Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne].EstLibre()
                || Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne].Piece.Joueur != this.Joueur) && !Echec(Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne]))
            { 
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne]); 
            }

            if (Position.Rangee - 1 >= 0 && Position.Colonne - 1 >= 0  && (Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne - 1].EstLibre()
                || Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne - 1].Piece.Joueur != this.Joueur) && !Echec(Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne - 1]))
            { 
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee - 1, Position.Colonne - 1]); 
            }

            if (Position.Colonne - 1 >= 0  && (Position.Echiquier.TCases[Position.Rangee, Position.Colonne - 1].EstLibre()
                || Position.Echiquier.TCases[Position.Rangee, Position.Colonne - 1].Piece.Joueur != this.Joueur) && !Echec(Position.Echiquier.TCases[Position.Rangee, Position.Colonne - 1]))
            { 
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee, Position.Colonne - 1]); 
            }

            if (Position.Rangee + 1 <= 7 && Position.Colonne - 1 >= 0  &&( Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne - 1].EstLibre()
                || Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne - 1].Piece.Joueur != this.Joueur) && !Echec(Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne - 1]))
            { 
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne - 1]); 
            }

            if (Position.Rangee + 1 <= 7 &&( Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne].EstLibre()
                || Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne].Piece.Joueur != this.Joueur) && !Echec(Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne]))
            {
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne]); 
            }

            if (Position.Rangee + 1 <= 7 && Position.Colonne + 1 <= 7  &&( Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne + 1].EstLibre()
                || Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne + 1].Piece.Joueur != this.Joueur) && !Echec(Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne + 1]))
            { 
                PositionPossible.Add(Position.Echiquier.TCases[Position.Rangee + 1, Position.Colonne + 1]); 
            }

            return PositionPossible;
        }

        public override void Deplacement(Case c)
        {
            this.Position.Piece = null;  // on vide la case de départ de la Piece que l'on va déplacer
            this.Position = c;  // on modifie notre position, en ajoutant les coordonnées de la Case c, celle vers laquelle on va se déplacer
            this.Position.Piece = this;  // on ajoute à cet emplacement la pièce qu'on vient de déplacer
            PremierDeplacement = true;
        }

        public bool Echec(Case p)
        {
            bool echec = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!Position.Echiquier.TCases[i, j].EstLibre() && this.Joueur != Position.Echiquier.TCases[i, j].Piece.Joueur)
                    {
                        if (Position.Echiquier.TCases[i, j].Piece.DeplacementPossible().Contains(p))
                        {
                            echec = true; Console.WriteLine("Echec par: {0}", Position.Echiquier.TCases[i, j].Piece.Nom);
                        }
                    }
                }
            }
            return echec;
        }

        public bool Mat()
        {
            bool mat = false;
            return mat;
        }

        public void Roque(Case c)//c est un Tour
        {
            int cRangee = c.Rangee;
            int cColonne=c.Colonne;
            if (!PremierDeplacement && !Echec(Position) && this.Joueur == c.Piece.Joueur)
            {
                if (c.Nom == "Tour")
                {
                    if (!c.Piece.PremierDeplacement)
                    {
                        int ColonneTour = c.Colonne;
                        //Tour de gauche
                        if (c.Colonne < Position.Colonne)
                        {
                            while (c.Colonne < Position.Colonne)
                            {
                                if (Position.Echiquier.TCases[c.Rangee, c.Colonne + 1].EstLibre()) { c.Colonne++; }
                                else
                                { 
                                    throw new Exception("Il ne peut y avoir de pièce(s) entre le Roi et la Tour concernée."); 
                                }
                            }
                            c.Colonne = ColonneTour;
                            if (!Echec(Position.Echiquier.TCases[Position.Rangee, Position.Colonne - 1]) && !Echec(Position.Echiquier.TCases[Position.Rangee, Position.Colonne - 2]))
                            {
                                c.Piece = null;
                                c = Position.Echiquier.TCases[this.Position.Rangee, this.Position.Colonne - 1];
                                Deplacement(Position.Echiquier.TCases[this.Position.Rangee, this.Position.Colonne - 2]);
                            }
                            else { throw new Exception("Le roi ne peut pas se mettre en échec (même temporairement) lors de son déplacement."); 
                            }

                        }
                        //Tour de droite
                        else
                        {

                            while (c.Colonne > Position.Colonne)
                            {
                                if (Position.Echiquier.TCases[c.Rangee, c.Colonne - 1].EstLibre()) { c.Colonne--; }
                                else
                                { 
                                    throw new Exception("Il ne peut y avoir de pièce(s) entre le Roi et la Tour concernée.");
                                }
                            }
                            c.Colonne = ColonneTour;
                            if (!Echec(Position.Echiquier.TCases[Position.Rangee, Position.Colonne + 1]) && !Echec(Position.Echiquier.TCases[Position.Rangee, Position.Colonne + 2]))
                            {
                                c.Piece = null;
                                c = Position.Echiquier.TCases[this.Position.Rangee, this.Position.Colonne + 1];
                                Deplacement(Position.Echiquier.TCases[this.Position.Rangee, this.Position.Colonne + 2]);
                            }
                            else 
                            { 
                                throw new Exception("Le roi ne peut pas se mettre en échec (même temporairement) lors de son déplacement."); 
                            }

                        }

                    }
                    else 
                    {
                        throw new Exception("Ce n'est pas une Tour."); 
                    }
                }
                else 
                { 
                    throw new Exception("Ce n'est pas une Tour."); 
                }
            }
            else
            { 
                throw new Exception("Soit le roi a déjà bougé, sois il est en échec, sois la Tour et le Roi sont adversaires.");
            }

        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
