using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Globals.dx = 6;
            Console.WriteLine("Your D6 roll is: " + Globals.RandomDx());
            Console.WriteLine("");

            int isPlaying = 1;
            while (isPlaying == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Would you like to roll again? or Check?");
                string ans = Console.ReadLine();
                if (ans=="yes")
                {
                    Console.WriteLine("How many sides to the dice?");
                    Globals.dx = int.Parse(Console.ReadLine());
                    Console.WriteLine("How many dice do you want to roll?");
                    int dRolls = int.Parse(Console.ReadLine());

                    List<int> rolls = new List<int>();
                    rolls.Clear();
                    for (int i = 0; i < dRolls; i++)
                    {
                        rolls.Add(Globals.RandomDx());
                    }
                    int e = 0;
                    int f = rolls.Count;
                    while (e < f)
                    {
                        Console.Write(rolls[e] + ", ");
                        e++;
                    }
                }
                else if(ans=="check"){
                    Console.WriteLine("how many");
                    Globals.checker = int.Parse(Console.ReadLine());
                    Console.WriteLine(Globals.PRolls());
                }
                else if(ans=="no"){
                    isPlaying = 0;
                }
            }
        }
    }
    static class Globals
    {
        public static int dx;
        public static int checker;
        public static Random rnd = new Random();
        private static List<int> previousRolls = new List<int>();

        public static int RandomDx()
        {
            int i = rnd.Next(1, dx);
            previousRolls.Add(i);
            return i;
        }

        public static string PRolls()
        {
            int i = 0;
            float sum = 0;
            string combindedString = "";
            while (i < checker)
            {
                sum += previousRolls[i];
                combindedString += previousRolls[i];
                combindedString += ", ";
                i++;
            }
            combindedString += " Average is ";
            float av = sum / i;
            combindedString += av;
            combindedString += " || Total is ";
            combindedString += sum;
            return combindedString;
        }
    }
}
