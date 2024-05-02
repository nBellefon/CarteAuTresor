using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Model
{
    public class Aventurier
    {
        public string Nom { get; set; }
        public Point Position { get; set; }
        public string Orientation { get; set; }
        public string Mouvements { get; set; }
        public int Tresors { get; set; }

        //Méthode pour changer l'orientation
        public void ChangerOrientation(char mouvement)
        {
            //On défini une array dans un sens spécifique
            string[] directions = new string[] { "N", "E", "S", "O" };
            int index = Array.IndexOf(directions, Orientation);

            //En fonction du déplacement il faut faire attention à ne pas dépasser les limites
            if(mouvement == 'G')
            {
                //Si l'index == 3 alors on le met à 0 sinon on réduit de 1 
                index = index == 0 ? 3 : index - 1;
            }
            else if(mouvement == 'D')
            {
                index = (index + 1)%4;
            }

            Orientation = directions[index];    

        }

        //Méthode pour avancer en fonction de la direction
        public void Avancer(Carte carte)
        {
            int newX = Position.AxeX;
            int newY = Position.AxeY;
            //L'orientation définie le mouvement sur la carte
            switch (Orientation)
            {
                case "N":
                    newY--;
                    break;
                case "S":
                    newY++;
                    break;
                case "E":
                    newX++;
                    break;
                case "O":
                    newX--;
                    break;
            }

            //On vérifie si le mouvement est possible à effectuer sur la carte
            if (VerifierPostion(carte, newX,newY))
            {
                //Si oui, on déplace l'aventurier
                Position.AxeX = newX;
                Position.AxeY = newY;
                RecupTresors(carte);
            }


        }

        //Méthode qui vérifie si une position est valide sur une carte
        private bool VerifierPostion(Carte carte, int x, int y)
        {
            //On vérifie si la position est hors des limites de la carte
            if (x < 0 || x >= carte.Longueur || y < 0 || y >= carte.Hauteur)
            {
                return false;
            }
            //On vérifie si il y a une montagne sur la position
            if (carte.Montagnes.Any(montagne => montagne.AxeX == x &&  montagne.AxeY == y))
            { 
                return false; 
            }
            //On vérifie s'il y a un aventurier sur la position
            if (carte.Aventuriers.Any(aventurier => aventurier.Position.AxeX == x && aventurier.Position.AxeY == y))
            {
                return false;
            }

            return true;
        }

        //Méthode qui effectue la récupération d'un trésor
        public void RecupTresors(Carte carte)
        {
            //On récupère le trésor présent sur la position
            Tresor? tresor = carte.Tresors.FirstOrDefault(tresor => tresor.AxeX == Position.AxeX && tresor.AxeY == Position.AxeY);

            //Si il y a un trésor sur la poisition en question
            if (tresor != null)
            {
                Tresors++;
                tresor.Quantite--;

                //S'il n'y a plus de tresor, alors on supprime de la carte
                if(tresor.Quantite <= 0)
                {
                    carte.Tresors.Remove(tresor);
                }
            }
        }

        public string ToString()
        {
            return "A - " + Nom + " - " + Position.AxeX + " - " + Position.AxeY+" - "+Orientation+" - "+Tresors;
        }


    }
}
