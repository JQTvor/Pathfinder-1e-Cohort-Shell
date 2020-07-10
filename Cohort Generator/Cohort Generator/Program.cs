using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cohort_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            do
            {
            BasicCharactistics NPC = new BasicCharactistics();
            NPC.Race();
            NPC.PCClass();
            NPC.Allignment();
            NPC.AbilityScores();

                Console.WriteLine($"Your Cohort is a {NPC.allignment} {NPC.race} {NPC.pclass} ");
                Console.WriteLine($"Attributes: Str {NPC.attributes[0]}, Dex {NPC.attributes[1]}, Con {NPC.attributes[2]}, Int {NPC.attributes[3]}, Wis {NPC.attributes[4]}, Cha {NPC.attributes[5]}");

                Console.WriteLine("Would you like to try again? Y or N");
                string answer = Console.ReadLine();
                if (answer.ToLower() != "y")
                    repeat = false;

            } while (repeat == true);


            //Console.ReadLine();

            
        }
    }
}
