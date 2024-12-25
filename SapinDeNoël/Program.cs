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
            int[] floconsX = new int[largeurConsole / 4];
            int[] floconsY = new int[largeurConsole / 4];

            for (int i = 1; i < floconsX.Length; i++)
            {
                floconsX[i] = random.Next(0, largeurConsole);
                floconsY[i] = random.Next(0, hauteurConsole);
            }

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

            // générer et animer la neige
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
            
            // Boucle principale pour l'animation
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

//using System;
//using System.Threading;

//namespace MyApp
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.SetWindowSize(80, 30);
//            int largeurConsole = Console.WindowWidth;

//            Console.WriteLine("--- Joyeux NOËL todos ---\n");

//            Console.Write("Entrer la hauteur du sapin (entre 1 et 30) :  ");
//            int hauteur = int.Parse(Console.ReadLine());

//            if (hauteur < 1 || hauteur > 30)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\n\tLa hauteur du sapin doit être entre 1 et 30.\n");
//                Console.ResetColor();
//                return;
//            }

//            Random random = new Random();

//            // Fonction pour dessiner les feuilles avec boules aléatoires
//            void DessinerFeuilles(int hauteur)
//            {
//                for (int i = 1; i <= hauteur; i++)
//                {
//                    int largeurLigne = (i * 2) - 1;
//                    int espacesGauche = (largeurConsole - largeurLigne) / 2;

//                    // Espaces à gauche pour centrer les feuilles
//                    Console.SetCursorPosition(espacesGauche, Console.CursorTop);

//                    for (int j = 1; j <= largeurLigne; j++)
//                    {
//                        // Probabilité de 10% d'afficher une boule colorée
//                        if (random.Next(1, 11) == 1)
//                        {
//                            Console.ForegroundColor = (ConsoleColor)random.Next(9, 15); // Couleurs aléatoires
//                            Console.Write("O");
//                            Console.ResetColor();
//                        }
//                        else
//                        {
//                            Console.Write("*");
//                        }
//                    }
//                    Console.WriteLine();
//                }
//            }

//            // Fonction pour dessiner le tronc
//            void DessinerTronc(int hauteur)
//            {
//                int largeurMaxSapin = (hauteur * 2) - 1; // Largeur maximale des feuilles
//                int largeurTronc = 3; // Largeur fixe du tronc
//                int hauteurTronc = Math.Max(hauteur / 3, 1); // Au moins 1 ligne pour le tronc
//                int espacesGauche = (largeurConsole - largeurTronc) / 2;

//                for (int i = 0; i < hauteurTronc; i++)
//                {
//                    Console.SetCursorPosition(espacesGauche, Console.CursorTop);
//                    Console.WriteLine("|||");
//                }
//            }

//            // Fonction la neige
//            void GenererNeige()
//            {
//                int nombreFlocons = largeurConsole / 5;
//                for (int i = 0; i < nombreFlocons; i++)
//                {
//                    int x = random.Next(0, largeurConsole);
//                    int y = random.Next(0, Console.WindowHeight);
//                    Console.SetCursorPosition(x, y);
//                    Console.ForegroundColor = ConsoleColor.White;
//                    Console.Write("*");
//                }
//                Console.ResetColor();
//            }

//            // Animation principale
//            while (true)
//            {
//                Console.Clear();
//                GenererNeige();
//                DessinerFeuilles(hauteur);
//                DessinerTronc(hauteur);
//                Thread.Sleep(400); // Pause pour l'animation
//            }
//        }
//    }
//}




//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------


//using System;
//using System.ComponentModel.Design;
//using System.IO;
//using System.Security.Cryptography.X509Certificates;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace MyApp
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            // saisie de la hauteur du sapin 
//            Console.Write("Choisissez la taille de votre sapin entre 0 et 30 : ");
//            int hauteurSapin = int.Parse(Console.ReadLine());

//            // contrôle de saisie de la hauteur du sapin + ajouter le contrôle de saisie de caractères 
//            while (hauteurSapin < 0 || hauteurSapin > 30)
//            { Console.WriteLine("Merci de saisir une hauteur comprise entre 1 et 30"); }
//            Console.Clear();

//            int nombreFeuilles = 0;
//            string rangFeuilles;
//            int largeurMax = 120;
//            int posInitiale = largeurMax / 2;
//            Random boule = new Random();
//            int proba = boule.Next(1, 10);


//            int DessinerFeuilles(int hauteurSapin)
//            {
//                for (int i = 0; i < hauteurSapin; i++)
//                {
//                    Console.SetCursorPosition((posInitiale - i), i + 2);
//                    nombreFeuilles = (2 * i) + 1;
//                    rangFeuilles = new string('\u002A', nombreFeuilles);

//                    Console.WriteLine(rangFeuilles);
//                }

//                Console.SetCursorPosition((posInitiale - 1), hauteurSapin + 2);
//                Console.WriteLine("|||");

//                return nombreFeuilles;
//            }

//            DessinerFeuilles(hauteurSapin);

//        }
//    }
//}




//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------





//char feuille = '*';
//char boule = '0';
//string tronc = "|||";
//char flocon = '¤';
//ConsoleColor[] colors = new ConsoleColor[5]
//{
//    ConsoleColor.Red,
//    ConsoleColor.Green,
//    ConsoleColor.DarkYellow,
//    ConsoleColor.White,
//    ConsoleColor.DarkRed
//};

//// Boucle menu
//while (true)
//{

//    // Taille du sapin, saisie 
//    Console.ForegroundColor = colors[0];
//    Console.WriteLine("(Veuillez mettre votre console en PLEINE ECRAN, pour éxperimenter la meilleure éxperience possible.)");
//    Console.ResetColor();

//    Console.Write("Choisiez la taille du sapin : ");
//    int tailleSapin;
//    bool successSapin = int.TryParse(Console.ReadLine(), out tailleSapin);
//    if (!successSapin || tailleSapin <= 1 || tailleSapin > 30)
//    {
//        Console.Clear();
//        Console.ForegroundColor = colors[4];
//        Console.WriteLine("Veuillez entrer une saisie correcte (entre 1 et 30)\n");
//        continue;

//    }
//    else
//    {
//        // Boucle sapin
//        while (true)
//        {
//            GenererNeige();
//            DessinerFeuilles(tailleSapin);
//            DessinerTronc(tailleSapin);
//            Thread.Sleep(400);
//            Console.Clear();

//            // SI l'appui sur une touche est disponible et que je presse "C" , je sors de ma boucle sapin
//            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.C)
//            {
//                break;
//            }

//        }



//    }

//}

//// Mes fonctions
//void DessinerTronc(int tailleSapin) // 
//{
//    int consoleWidth = Console.WindowWidth; // Je déclare la largeur de la console
//    int troncWidth = tronc.Length;
//    int centerPosition = (consoleWidth - troncWidth) / 2;

//    for (int i = 1; i <= tailleSapin / 3; i++) // Tant que index est inférieur ou égal au 1/3 a la saisie tailleSapin, j'incrémente
//    {
//        Console.ForegroundColor = colors[2];
//        Console.SetCursorPosition(centerPosition, Console.CursorTop);
//        Console.WriteLine(tronc); // J'affiche des troncs en boucle
//    }
//    Console.ResetColor();

//}

//void DessinerFeuilles(int tailleSapin)
//{
//    int consoleWidth = Console.WindowWidth;  // Je déclare un int de la largeur de la console
//    int consoleHeight = Console.WindowHeight;

//    Random random = new Random();


//    for (int i = 1; i <= tailleSapin; i++) // Tant que index est inférieur a la saisie tailleSapin, 
//    {
//        int brancheTaille = (i * 2 - 1);
//        int centerPositionWidth = (consoleWidth - brancheTaille) / 2;
//        int centerPositionHeight = (consoleHeight - tailleSapin) / 2;
//        Console.SetCursorPosition(centerPositionWidth, centerPositionHeight + i - 1);



//        for (int j = 0; j < (i * 2 - 1); j++) // Formule pour calculer suite de nombe impair (askip)
//        {

//            if (random.NextDouble() < 0.1)
//            {
//                Console.ForegroundColor = colors[0];
//                Console.Write(boule);
//            }
//            else
//            {
//                Console.ForegroundColor = colors[1];
//                Console.Write(feuille);
//            }
//        }
//        Console.WriteLine();
//    }
//    Console.ResetColor();
//}

//void GenererNeige()
//{
//    // Je déclare deux variables avec la méthode Window
//    int consoleWidth = Console.WindowWidth;
//    int consoleHeight = Console.WindowHeight;
//    Random random = new Random();

//    // Tant que la taille de ma console est inférieure a mon index
//    for (int i = 0; i < consoleHeight; i++)
//    {
//        // Alors je génere des positions randoms dans ma console
//        int positionX = random.Next(0, consoleWidth);
//        int positionY = random.Next(0, consoleHeight);

//        Console.SetCursorPosition(positionX, positionY);
//        Console.ForegroundColor = colors[3];
//        Console.Write(flocon);
//    }
//    Console.ResetColor();
//}


