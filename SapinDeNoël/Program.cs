using System;
using System.Threading;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 40);
            int largeurConsole = Console.WindowWidth;
            int hauteurConsole = Console.WindowHeight;

            Console.WriteLine("--- Joyeux NOËL todos ---\n");

            Console.Write("Entrer la hauteur du sapin (entre 1 et 30) :  ");
            int hauteur = int.Parse(Console.ReadLine());
            if (hauteur < 1 || hauteur > 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tLa hauteur du sapin doit être entre 1 et 30.\n");
                Console.ResetColor();
                return;
            }

            Random random = new Random();
            

            // dessiner les feuilles
            void DessinerFeuilles(int hauteur)
            {
                int largeurMaxSapin = (hauteur * 2) - 1;

                for (int i = 1; i <= hauteur; i++)
                {
                    int largeurLigne = (i * 2) - 1;
                    int espacesGauche = (largeurMaxSapin - largeurLigne) / 2;

                    Console.SetCursorPosition((largeurConsole - largeurMaxSapin) / 2 + espacesGauche, hauteurConsole / 2 - hauteur + i);

                    for (int j = 0; j < largeurLigne; j++)
                    {
                        // Ajouter des boules aléatoires (10% de chance)
                        if (random.Next(0, 10) < 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("°");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("*");
                        }
                    }
                }
                Console.ResetColor();
            }

            // Fonction pour le tronc
            void DessinerTronc(int hauteur)
            {
                int largeurMaxSapin = (hauteur * 2) - 1;
                int largeurTronc = 3;
                int hauteurTronc = hauteur / 3;
                int espacesGauche = (largeurMaxSapin - largeurTronc) / 2;

                for (int i = 0; i < hauteurTronc; i++)
                {
                    Console.SetCursorPosition((largeurConsole - largeurMaxSapin) / 2 + espacesGauche, hauteurConsole / 2 + i);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("|||");
                }
                Console.ResetColor();
            }

            int[] floconsX = new int[largeurConsole / 4];
            int[] floconsY = new int[largeurConsole / 4];

            for (int i = 1; i < floconsX.Length; i++)
            {
                floconsX[i] = random.Next(0, largeurConsole);
                floconsY[i] = random.Next(0, hauteurConsole);
            }

            // gcréer et animer la neige
            void GenererNeige()
            {
                for (int i = 0; i < floconsX.Length; i++)
                {
                    // Effacer l'ancien flocon
                    Console.SetCursorPosition(floconsX[i], floconsY[i]);
                    Console.Write(" ");

                    // Déplacer le flocon
                    floconsY[i]++;
                    if (floconsY[i] >= hauteurConsole)
                    {
                        floconsY[i] = 0;
                        floconsX[i] = random.Next(0, largeurConsole);
                    }

                    // Afficher le nouveau flocon
                    Console.SetCursorPosition(floconsX[i], floconsY[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("¤");
                }
                Console.ResetColor();
            }
            
            // Boucle  pour l'animation
            while (true)
            {
                GenererNeige();
                DessinerFeuilles(hauteur);
                DessinerTronc(hauteur);
                Thread.Sleep(300);
                
            }
            
        }
    }
}



//-------------------------------------------------
//------presque bon-----------------------------





