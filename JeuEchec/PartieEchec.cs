using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JeuEchec
{
    class PartieEchec
    {
        // ATTRIBUTS
        public Echiquier Echiquier { get; set; }
        public Joueur[] Joueurs { get; set; }
        public Joueur JoueurCourant { get; set; }
        public List<Piece> Pieces { get; set; }

        // CONSTRUCTEUR
        public PartieEchec()
        {
            Echiquier = new Echiquier(this);

            Joueurs = new Joueur[2] { new Joueur(this, "Blanc"), new Joueur(this, "Noir") };

            JoueurCourant = Joueurs[1]; // le joueur blanc commence, mais on inverse le joueur en début de partie, donc on choisit le joueur noir

            Pieces = new List<Piece>();
            
            /*
             * générer la liste des pièces blanches
             * et les placer au bon endroit sur l'échiquier
             */
            Joueur b = Joueurs[0];
            // générer les pions
            for (int i = 0; i < 8; i++)
            {
                Pion pion = new Pion(b, Echiquier.TCases[6, i]); // créer le pion (l'attribuer à un joueur et à une case)
                Pieces.Add(pion); // l'ajouter à la liste des pièces présentes sur l'échiquier
                Echiquier.TCases[6, i].Piece = pion; // attribuer à la case adéquate la pièce qu'on vient de créer
            }
            // générer les tours, les cavaliers et les fous
            for (int i = 0; i < 8; i++)
            {
                if (i == 0 || i == 7)
                {
                    Tour t = new Tour(b, Echiquier.TCases[7, i]);
                    Pieces.Add(t);
                    Echiquier.TCases[7, i].Piece = t;
                }
                if (i == 1 || i == 6)
                {
                    Cavalier c = new Cavalier(b, Echiquier.TCases[7, i]);
                    Pieces.Add(c);
                    Echiquier.TCases[7, i].Piece = c;
                }
                if (i == 2 || i == 5)
                {
                    Fou f = new Fou(b, Echiquier.TCases[7, i]);
                    Pieces.Add(f);
                    Echiquier.TCases[7, i].Piece = f;
                }
            }
            // générer la Dame et le Roi
            Dame db = new Dame(b, Echiquier.TCases[7, 3]);
            Pieces.Add(db);
            Echiquier.TCases[7, 3].Piece = db;
            Roi rb = new Roi(b, Echiquier.TCases[7, 4]);
            Pieces.Add(rb);
            Echiquier.TCases[7, 4].Piece = rb;
            
            /*
             * générer la liste des pièces noires
             * et les placer au bon endroit sur l'échiquier
             */
            
            Joueur n = Joueurs[1];
            // générer les pions
            for (int i = 0; i < 8; i++)
            {
                Pion pion = new Pion(n, Echiquier.TCases[1, i]);
                Pieces.Add(pion);
                Echiquier.TCases[1, i].Piece = pion;
            }
            // générer les tours, les cavaliers et les fous
            for (int i = 0; i < 8; i++)
            {
                if (i == 0 || i == 7)
                {
                    Tour t = new Tour(n, Echiquier.TCases[0, i]);
                    Pieces.Add(t);
                    Echiquier.TCases[0, i].Piece = t;
                }
                if (i == 1 || i == 6)
                {
                    Cavalier c = new Cavalier(n, Echiquier.TCases[0, i]);
                    Pieces.Add(c);
                    Echiquier.TCases[0, i].Piece = c;
                }
                if (i == 2 || i == 5)
                {
                    Fou f = new Fou(n, Echiquier.TCases[0, i]);
                    Pieces.Add(f);
                    Echiquier.TCases[0, i].Piece = f;
                }

            }
            // générer la Dame et le Roi
            Dame dn = new Dame(n, Echiquier.TCases[0, 3]);
            Pieces.Add(dn);
            Echiquier.TCases[0, 3].Piece = dn;
            Roi rn = new Roi(n, Echiquier.TCases[0, 4]);
            Pieces.Add(rn);
            Echiquier.TCases[0, 4].Piece = rn;
        }

        // METHODES
        /*
         * Passer d'un joueur à l'autre 
         */
        public void ChangerJoueur()
        {
            if (JoueurCourant == Joueurs[0])
            {
                JoueurCourant = Joueurs[1];
            }
            else if (JoueurCourant == Joueurs[1])
            {
                JoueurCourant = Joueurs[0];
            }
            else
            {
                throw new Exception("Joueur ne peut être que Blanc ou Noir.");
            }
        }

        /*
         * Choix de la pièce à jouer.
         * Vérifier ce que le joueur saisit au clavier : 
         *   - deux caractères (ni plus, ni moins)
         *   - le premier doit contenir une lettre parmi abcdefgh
         *   - le deuxième un chiffre entre 1 et 8 (compris)
         */
        public string VerificationNomCase()
        {
            bool b;
            string jeu;
            do
            {
                b = true;
                jeu = Console.ReadLine();
                string alphabet = "abcdefgh";
                string numeros = "12345678";

                if (jeu.Length != 2) // saisie de deux caractères
                {
                    Console.Write("\nLe nom d'une case est constitué d'une lettre (de 'a' à 'h') \net d'un chiffre (de 1 à 8), exemple : 'd3'\n\nEntrez une nouvelle case : ");
                    b = false;
                }
                else if (!alphabet.Contains(jeu[0])) // le premier doit être une lettre parmi abcdefgh
                {
                    Console.Write("\nLe nom d'une case est constitué d'une lettre (de 'a' à 'h') \net d'un chiffre (de 1 à 8), exemple : 'd3'\n\nEntrez une nouvelle case : ");
                    b = false;
                }
                else if (!numeros.Contains(jeu[1])) // le deuxième doit être un chiffre entre 1 et 8 (compris)
                {
                    Console.Write("\nLe nom d'une case est constitué d'une lettre (de 'a' à 'h') \net d'un chiffre (de 1 à 8), exemple : 'd3'\n\nEntrez une nouvelle case : ");
                    b = false;
                }
            }
            while (b == false);
            return jeu;
        }

        /*
         * Vérification de la pièce à jouer. 
         * Vérifier que la case est bien occupée par une pièce, 
         * que celle-ci est de sa propre couleur
         * puis renvoyer cette pièce dans Jouer()
         */
        public Piece SelectionPieceJouee()
        {
            bool b;
            Case caseDepart = null; // là où on va stocker la case où se trouve la pièce
            do
            {
                b = true;
                string nomCaseChoisie = VerificationNomCase(); // choisit et vérifie le nom de la case
                for (int i = 0; i < 8; i++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        if (Echiquier.TCases[i, k].Nom == nomCaseChoisie) // trouve la case
                        {
                            if (Echiquier.TCases[i, k].EstLibre()) // vérifie si la case est vide
                            {
                                Console.Write("\nLa case est vide! Entrez une nouvelle case : ");
                                b = false; continue;
                            }
                            else if (Echiquier.TCases[i, k].Piece.Joueur != JoueurCourant)
                            // vérifie si la pièce est de la bonne couleur
                            {
                                Console.Write("\nJouez avec vos propres pions! Entrez une nouvelle case : ");
                                b = false; continue;
                            }
                            List<Case> ldp = Echiquier.TCases[i, k].Piece.DeplacementPossible();
                            if (ldp.Count == 0) // vérifie si la pièce peut jouer (i.e. a des déplacements possibles)
                            {
                                Console.Write("\nCette pièce n'a nulle part où aller! Entrez une nouvelle case : ");
                                b = false; continue;
                            }
                            // TO DO : rajouter le cas de la pièce clouée, qui ne peut se déplacer car mettrait le roi en échec
                            caseDepart = Echiquier.TCases[i, k];
                        }
                    }
                }
            }
            while (b == false);
            Piece pieceDepart = caseDepart.Piece; // récupérer la pièce qui se trouve sur cette case
            return pieceDepart;
        }

        /*
         * Choix de la case vers laquelle se déplacer. 
         * Localiser la case, 
         * vérifier que la case fait partie de la liste DeplacementPossible() de la piece choisie (passée en paramètre),
         * puis renvoyer la case dans Jouer()
         */
        public Case SelectionCaseArrivee(Piece PieceJouee)
        {
            bool b;
            Case caseArrivee = null; // là où on va stocker la case où se trouve la pièce
            List<Case> ldp = PieceJouee.DeplacementPossible();
            do
            {
                b = true;
                string nomCaseArrivee = VerificationNomCase();
                for (int i = 0; i < 8; i++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        if (Echiquier.TCases[i, k].Nom == nomCaseArrivee)
                        {
                            if (PieceJouee.Nom == "Roi" && PieceJouee.PremierDeplacement == false)
                            {
                                if (Echiquier.TCases[i, k].Piece.Nom == "Tour"
                                    && Echiquier.TCases[i, k].Piece.PremierDeplacement == false
                                    && PieceJouee.Joueur == Echiquier.TCases[i, k].Piece.Joueur)
                                {
                                    caseArrivee = Echiquier.TCases[i, k];
                                }
                            }
                            if (!ldp.Contains(Echiquier.TCases[i, k]))
                            {
                                Console.Write("\nVous ne pouvez pas mettre votre piece ici! Entrez une nouvelle case : ");
                                b = false;
                            }
                            else
                            {
                                caseArrivee = Echiquier.TCases[i, k];
                            }
                        }
                    }
                }
            }
            while (b == false);
            return caseArrivee;
        }

        /*
         * Méthode de jeu principale, 
         * regroupant toutes les autres méthodes
         * 
         * Contient un booléen qui permet de sortir de la boucle de jeu quand un roi est capturé.
         */
        public bool Jouer()
        {
            bool FinPartieEchec = true;
            Console.Clear();
            ChangerJoueur();

            Console.WriteLine("\n\n                            **   JEU D'ECHEC   **");          
            Console.WriteLine("\n\nDéroulement du jeu : ");
            Console.WriteLine("\n - Saisissez la case où se trouve la pièce que vous voulez déplacer (ex. 'c2')");
            Console.WriteLine("\n - Appuyez sur 'Enter'");
            Console.WriteLine("\n - Saisissez la case vers laquelle vous voulez déplacer votre pièce (ex. 'c3')");
            Console.WriteLine("\n - Appuyez sur 'Enter'");
            Console.WriteLine("\n - Votre tour est terminé, c'est alors au joueur suivant de commencer.\n\n");
            
            Echiquier.Afficher();
            Console.WriteLine("\n\nJoueur {0}, c'est à vous.", JoueurCourant.Couleur);

            // Pour choisir une pièce, le joueur saisit le nom de la case où elle se trouve au clavier (exemple: a2)
            Console.Write("\nPièce que vous voulez jouer : ");
            Piece pieceChoisie = SelectionPieceJouee();

            /*
             * Pour déplacer sa pièce, le joueur saisit au clavier de nom de la case vers laquelle il souhaite la déplacer
             * et l'on récupére la case (avec, éventuellement, le nom de la pièce capturée, à avoir celle qui s'y trouvait déjà)
             */
            if (pieceChoisie.Nom == "Roi") // traiter le roi à part pour le Roque
            {
                Console.Write("\nSi vous souhaitez faire un Roque, sélectionnez la Tour avec laquelle vous voulez faire ce Roque.");
                Case caseArrivee = SelectionCaseArrivee(pieceChoisie); // récupérer la case
                Piece pieceArrivee = caseArrivee.Piece; // récupérer la pièce sur cette case
                Roi roi = (Roi)pieceChoisie;
                // cas du Roque
                if (caseArrivee.Piece.Nom == "Tour"
                    && caseArrivee.Piece.PremierDeplacement == false
                    && roi.Joueur == caseArrivee.Piece.Joueur)
                {
                    roi.Roque(caseArrivee);
                }
                else // autres déplacements
                {
                    if (roi.CapturePossible(caseArrivee))
                    {
                        roi.Capture(caseArrivee.Piece);
                    }
                    roi.Deplacement(caseArrivee);
                }
            }
            
            else // mouvement pour toutes les pièces
            {
                Console.Write("\nEntrez le nom de la case vers laquelle vous voulez déplacer votre pièce : ");
                Case caseArrivee = SelectionCaseArrivee(pieceChoisie); // récupérer la case
                Piece pieceArrivee = caseArrivee.Piece; // récupérer la pièce sur cette case
                if (pieceChoisie.CapturePossible(caseArrivee))
                {
                    if (caseArrivee.Piece.Nom == "Roi")
                    {
                        FinPartieEchec = false;
                        return FinPartieEchec;
                    }
                    pieceChoisie.Capture(caseArrivee.Piece);
                }
                pieceChoisie.Deplacement(caseArrivee);
            }
            return FinPartieEchec;
        }
    }
}