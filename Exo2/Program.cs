// See https://aka.ms/new-console-template for more information

Console.WriteLine("De combien avez vous besoin?");
float montantEuro = 0;
bool bMontantEuro = false;

int twoEuro = 0;
int oneEuro = 0;
int fiftyCents = 0;
int tweentyCents = 0;
int teenCents = 0;
int fiveCents = 0;
int twoCents = 0;
int oneCents = 0;

do
{
    bMontantEuro = float.TryParse(Console.ReadLine(), out montantEuro);
    if (!bMontantEuro)Console.WriteLine("S'il vous plait entrez un montant");
    
}while(!bMontantEuro);

int montantEuroCents = (int)(montantEuro * 100);

        twoEuro = (int)MathF.Round(montantEuroCents / 200,MidpointRounding.ToZero);
        montantEuroCents -= twoEuro * 200;

        oneEuro = (int)MathF.Round(montantEuroCents / 100,MidpointRounding.ToZero);
        montantEuroCents -= oneEuro * 100;

        fiftyCents = (int)MathF.Round(montantEuroCents / 50,MidpointRounding.ToZero);
        montantEuroCents -= fiftyCents * 50;

        tweentyCents = (int)MathF.Round(montantEuroCents / 20,MidpointRounding.ToZero);
        montantEuroCents -= tweentyCents * 20;

        teenCents = (int)MathF.Round(montantEuroCents / 10,MidpointRounding.ToZero);
        montantEuroCents -= teenCents * 10;

        fiveCents = montantEuroCents / 5;
        montantEuroCents -= fiveCents * 5;

        twoCents = (int)MathF.Round(montantEuroCents / 2,MidpointRounding.ToZero);
        montantEuroCents -= twoCents * 2;

        oneCents = (int)MathF.Round(montantEuroCents / 1,MidpointRounding.ToZero);
        montantEuroCents -= oneCents * 1;

Console.WriteLine("Vous avez besoin de : "+ twoEuro + " 2 euros, " + oneEuro + " 1 euros, " + fiftyCents + " 50 cents, "
    + tweentyCents + " 20 cents, " + teenCents + " 10 cents, " + fiveCents + " 5 cents, " + twoCents + " 2 cents, " + oneCents + " 1 cents.");
