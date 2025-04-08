// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Bienvenu dans le jeu du bâtonnets. Vous ne pouvez rentirer que 1, 2 ou 3 bâtonnets par tour. Celui qui retire le dernier bâtonnets à perdu");
bool bBatonnet=true;
int batonnets = 20;
int retraitBatonnets = 0;
int actualBatonnets = batonnets;
int retraitOrdi = 0 ;
Random rand = new ();

Jeux();
bool Jeux()
{
    while (bBatonnet)
    {
        Console.WriteLine("Combien de bâtonnets voulez vous retirer? Actuellement il reste "+ actualBatonnets);
        
        bBatonnet = int.TryParse(Console.ReadLine(), out retraitBatonnets);
        actualBatonnets = actualBatonnets-retraitBatonnets;

        retraitOrdi = rand.Next(1,3);
        Console.WriteLine("Actuellement il reste "+ actualBatonnets + "L'ordi à retiré "+ retraitOrdi + "bâtonnets");
        actualBatonnets = actualBatonnets - retraitOrdi;
        if (actualBatonnets == 1)
        {
            retraitOrdi = 1;
        }
        if (actualBatonnets <= 0)
        {
            bBatonnet = false;
        }
    }
    Console.WriteLine("voulez vous recommencer ? oui/non");
    string reload = Console.ReadLine();
    if (reload == "oui")
    {
        actualBatonnets = batonnets;
        bBatonnet = true;
        Jeux();
    }

    return bBatonnet;
}

