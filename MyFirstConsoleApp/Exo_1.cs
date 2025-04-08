// See https://aka.ms/new-console-template for more information

bool bMinNUmber = false;
bool bMaxNUmber = false;
int minNumber = 0;
int maxNumber = 0;
int lastMinNumber = minNumber;
int lastMaxNumber = maxNumber;

Console.WriteLine("Bonjour, choississez un nombre minimum");
do
{
    bMinNUmber = int.TryParse(Console.ReadLine(), out minNumber);
    if (!bMinNUmber)Console.WriteLine("S'il vous plait entrez un entier");
    
}while(!bMinNUmber);

Console.WriteLine("Bonjour, choississez un nombre maximum");
do
{
    bMaxNUmber = int.TryParse(Console.ReadLine(), out maxNumber);
    if (!bMaxNUmber) Console.WriteLine("S'il vous plait entrez un entier");

} while (!bMaxNUmber);

int searchNumber = maxNumber/2;
bool result = false;
int round = 0;

while (!result)
{
    Console.WriteLine("votre nombre est-il" + searchNumber + ". Répondez par oui ou non");
    string answerNumber = Console.ReadLine();
    if (answerNumber == "oui")
    {
        result = true;
        Console.WriteLine("J'ai mis " + round + "round pour trouver la réponse");
        break;
    }
    else
    {
        AnswerSize();
    }
}

int AnswerSize()
{
    Console.WriteLine("le nombre est-il plus grand ou plus petit");
    string answer = Console.ReadLine();
    if (answer == "petit")
    {
        
        lastMaxNumber = searchNumber;
        searchNumber = (lastMaxNumber + lastMinNumber) / 2;
        round++;

    }
    else if (answer == "grand")
    {
        lastMinNumber = searchNumber;
        searchNumber = (lastMaxNumber + lastMinNumber) / 2;
        round++;
    }
    else
    {
        Console.WriteLine("Répondez par petit ou grand, s'il vous plait.");
    }

    return searchNumber;
}



    