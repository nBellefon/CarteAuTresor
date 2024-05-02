using CarteAuTresor.Model;
using System;
using System.Linq;
using System.Text;

namespace CarteAuTresor
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Carte carte = Carte.LectureCarte(@"Cartes/tresor.txt");

                SimulerMouvements(carte);

                GenererFichierSortie(carte);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur est surevenue : "+ex.Message);
            }

        }

        //Méthode pour effectuer la simulation des déplacements des aventuriers
        public static void SimulerMouvements(Carte carte)
        {
            //On récupère le nombre de tour en fonction de l'aventurier qui a le plus de mouvements
            int tours = carte.Aventuriers.Max(x => x.Mouvements.Length);

            for(int i = 0; i < tours; i++)
            {
                //On parcourt les aventuriers qui ont encore des mouvements à réaliser
                foreach (Aventurier aventurier in carte.Aventuriers.Where(x => x.Mouvements.Length > i))
                {
                    char mouvement = aventurier.Mouvements[i];

                    if (mouvement == 'A')
                    {
                        aventurier.Avancer(carte);
                    }
                    else if (mouvement == 'G' || mouvement == 'D')
                    {
                        aventurier.ChangerOrientation(mouvement);
                    }
                }
            }
        }

        //Méthode pour écrire le fichier de sortie
        public static void GenererFichierSortie(Carte carte)
        {
            StringBuilder stringBuilder = new StringBuilder();

            //On appelle les méthodes toString de la carte et de chacun de ses éléments
            stringBuilder.AppendLine(carte.ToString());

            foreach(Point montagne in carte.Montagnes)
            {
                stringBuilder.AppendLine(montagne.ToString());
            }
            foreach (Tresor tresor in carte.Tresors)
            {
                stringBuilder.AppendLine(tresor.ToString());
            }
            foreach(Aventurier aventurier in carte.Aventuriers)
            {
                stringBuilder.AppendLine(aventurier.ToString());
            }

            //On écrit le résultat dans un fichier ou on l'affiche en console

            //File.WriteAllText(@"C:\Users\mericdebellefonn\Documents\Test\FileOutput.txt", stringBuilder.ToString());
            Console.WriteLine(stringBuilder.ToString());

        }



    }
}