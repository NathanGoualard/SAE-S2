using System;
using System.Text;

class GenerateuyrDeLabyrinthe
{
    private int largeur;
    private int hauteur;
    private int[,] labyrinthe;

    // definie la taille du Labyrinthe (constructeur)
    public GenerateuyrDeLabyrinthe(int largeur, int hauteur)
    {
        this.largeur = largeur;
        this.hauteur = hauteur;
        labyrinthe = new int[hauteur, largeur];
    }

    // definie tous les casse comme des murs et app la fonction recherche en profondeur

    public void GeneratioDuLabirinthe()
    {
        for (int i = 0; i < hauteur; i++)
        {
            for (int j = 0; j < largeur; j++) {labyrinthe[i, j] = 1;}
        }

        RechercheEnProfondeur(0, 0);
    }

    // coeur du programme -

    private void RechercheEnProfondeur(int ligneDebut, int coloneDebut)
    {
        labyrinthe[ligneDebut, coloneDebut] = 0;

        int[] directions = { 1, 2, 3, 4 };
        Melange(directions);

        foreach (int direction in directions)
        {
            int nouvelleLigne = ligneDebut;
            int nouvelleColone = coloneDebut;

            if (direction == 1) {nouvelleLigne -= 2;} // en haut
            
            if (direction == 2) {nouvelleLigne += 2;} // en bas
           
            if (direction == 3) {nouvelleColone -= 2;} // a gauche
           
            if (direction == 4) {nouvelleColone += 2;} // a droite
            

            if (TestePosition(nouvelleLigne, nouvelleColone) && labyrinthe[nouvelleLigne, nouvelleColone] == 1)
            {
                int cheminLigne = ligneDebut + (nouvelleLigne - ligneDebut) / 2;
                int cheminColone = coloneDebut + (nouvelleColone - coloneDebut) / 2;
                labyrinthe[cheminLigne, cheminColone] = 0;
                RechercheEnProfondeur(nouvelleLigne, nouvelleColone);
            }
        }
    }

    //vérifie si la position se trouve dans le labyrinthe
    private bool TestePosition(int ligne, int colone)
    {
        return ligne >= 0 && ligne < hauteur && colone >= 0 && colone < largeur;
    }

    //Melange un tableau en une dimension
    private void Melange(int[] array)
    {
        Random rnd = new Random();
        for (int i = array.Length - 1; i >= 0; i--)
        {
            int randomIndex = rnd.Next(i + 1);
            int temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    //affiche les chemin et les mur du labyrinthe

    public void AffichageDuLabyrinthe()
    {
        for (int i = 0; i < hauteur; i++)
        {
            for (int j = 0; j < largeur; j++)
            {
                if (labyrinthe[i, j] == 0) {Console.Write("  ");}

                else {Console.Write("██");}
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int largeur, hauteur;
        Console.Write("veiller saisir la largeur de votre labyrinthe : ");
        largeur = Convert.ToInt32(Console.ReadLine());
        Console.Write("veiller saisir la hauteur de votre labyrinthe : ");
        hauteur = Convert.ToInt32(Console.ReadLine());


        GenerateuyrDeLabyrinthe labyrintheDeTeste = new GenerateuyrDeLabyrinthe(largeur, hauteur);
        labyrintheDeTeste.GeneratioDuLabirinthe();
        labyrintheDeTeste.AffichageDuLabyrinthe();
    }
}