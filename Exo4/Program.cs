// See https://aka.ms/new-console-template for more information
class Exo1;

internal class Program
    {
        public static void Main(string[] args)
        {   
            Console.WriteLine("Merci d'écrire un message");
            string testOne = Console.ReadLine().ToLower();
            char [] charArray = testOne.ToCharArray();
            Array.Reverse(charArray);
            string testTwo = new string(charArray);
            Console.WriteLine(testTwo);
            Console.WriteLine(checkPalindrome(testTwo));
            // Console.WriteLine(occurences(testTwo));
        }
        public static bool checkPalindrome(string testTwo)
        {
            char[] charArray = testTwo.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray).Equals(testTwo);
            
        }

        // public static string occurences(string testTwo)
        // {
        //     char letter = char.ToLower(Console.ReadKey().KeyChar);
        //     int occurences = 0;
        //     // foreach (string c in testTwo)
        //     // {
        //     //     if (c == letter)
        //     //     {
        //     //         occurences++;
        //     //     }
        //     // }
        //     //
        //     // return occurences;
        //
        // }
    }
    