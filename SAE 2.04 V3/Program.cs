using SAE_2._04_V3;
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        //saisie des dimensions du labyrhinte
        int largeur, hauteur;

        Console.Write("veiller saisir la largeur de votre labyrinthe : ");
        largeur = Convert.ToInt32(Console.ReadLine());

        Console.Write("veiller saisir la hauteur de votre labyrinthe : ");
        hauteur = Convert.ToInt32(Console.ReadLine());


        GenerateuyrDeLabyrinthe labyrintheDeTeste = new GenerateuyrDeLabyrinthe(largeur, hauteur);
        //creation du labyrhinte
        labyrintheDeTeste.GenerationDuLabyrinthe();
        //affichage du labyrhinte
        labyrintheDeTeste.AffichageDuLabyrinthe();
    }
}