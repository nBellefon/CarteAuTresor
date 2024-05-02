using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Model
{
    public class Carte
    {
        public int Longueur { get; set; }
        public int Hauteur { get; set; }

        public List<Point> Montagnes { get; set; } 
        public List<Tresor> Tresors { get; set; }
        public List<Aventurier> Aventuriers { get; set; }   

        public Carte(int longueur, int hauteur)
        {

            Longueur = longueur;
            Hauteur = hauteur;
            Montagnes = new List<Point>();
            Tresors = new List<Tresor>();
            Aventuriers = new List<Aventurier>();
        }


        public Carte()
        { 
            Montagnes = new List<Point>();
            Tresors = new List<Tresor>();
            Aventuriers = new List<Aventurier>();
        }

        //Méthode pour lire le fichier texte et remplir les objets
        public static Carte LectureCarte(string fichier)
        {
            Carte carte = new Carte();

            //Ouverture du fichier texte
            using (StreamReader reader = new StreamReader(fichier))
            {
                string ligne = reader.ReadLine();

                while(ligne != null)
                {
                    //On utilise un séparateur pour récupérer uniquement les données
                    string[] elements = ligne.Split(" - ");

                    //En fonction de la premiere lettre, on crée l'objet correspondant et on l'ajoute à la carte
                    if (elements[0] == "C")
                    {
                        carte.Longueur = int.Parse(elements[1]);
                        carte.Hauteur = int.Parse(elements[2]);
                    }
                    else if (elements[0] == "M")
                    {
                        carte.Montagnes.Add(new Point() { AxeX = int.Parse(elements[1]), AxeY = int.Parse(elements[2]) });
                    }
                    else if (elements[0] == "T")
                    {
                        carte.Tresors.Add(new Tresor() { AxeX = int.Parse(elements[1]), AxeY = int.Parse(elements[2]), Quantite = int.Parse(elements[3])});
                    }
                    else if (elements[0] == "A")
                    {
                        carte.Aventuriers.Add(new Aventurier()
                        {
                            Nom = elements[1],
                            Position = new Point() { AxeX = int.Parse(elements[2]), AxeY= int.Parse(elements[3])},
                            Orientation = elements[4],
                            Mouvements = elements[5]
                            
                        });
                    }


                    ligne = reader.ReadLine();
                }
            }

            return carte;

        }

        public string ToString()
        {
            return "C - " + Longueur + " - " + Hauteur;
        }


    }
}
