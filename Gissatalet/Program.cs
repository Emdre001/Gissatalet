using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Gissatalet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int nr1 = GetNumber("Input a number");
                int nr2 = GetNumber("Input another number");
                int counter = 0;
                int guess;
                Random rnd = new Random();
                int rndnr = rnd.Next(nr1, nr2);

                Console.WriteLine($"A number between {nr1} and {nr2} has been chosen, Guess which number it is");

                do
                {
                    string s = Console.ReadLine();
                    guess = int.Parse(s);

                    if (guess != rndnr)
                    {
                        if (guess > rndnr)
                            Console.WriteLine("Wrong, Guess is too high");
                        counter++;
                    }

                    if (guess < rndnr)
                    {
                        Console.WriteLine("Wrong, Guess is too low");
                        counter++;
                    }
                }
                while (guess != rndnr);
                counter++;
                Console.WriteLine($"Correct! It took {counter} tries");
                counter = 0;
            }
            while (!Terminate("do you want to exit? (yes / no)"));
            
        }

        private static bool Terminate(string question)
        {
            string cont;
            do
            {
                Console.WriteLine(question);
                cont = Console.ReadLine();

            } while (!(cont.Trim().ToLower() == "yes" || cont.Trim().ToLower() == "no"));

            if (cont.Trim().ToLower() == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int GetNumber(string question)
        {
            int nr;
            bool all_ok;

            do
            {
                Console.WriteLine(question);
                string s_nr = Console.ReadLine();

                all_ok = int.TryParse(s_nr, out nr);
                if (!all_ok)
                {
                    Console.WriteLine("Not a number");
                }
            } while (!all_ok);
            return nr;
        }

    }
}


//Ange två tal
//Datorn tänker på ett tal mellan de angiva talen.
//gissa talet
//om rätt, bekräfta
//Annars, säg högre eller lägre och gissa igen (två if-satset
// räkna gissningar (counter)
