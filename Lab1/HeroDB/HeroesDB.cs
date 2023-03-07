using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace HeroDB
{
    //Complete!
    public class HeroesDB
    {
        private static List<Hero> _heroes;

        static HeroesDB()
        {
            LoadHeroes();
        }
        public static int Count
        {
            get
            {
                return _heroes.Count;
            }
        }
        public static void LoadHeroes()
        {
            string jsonText = File.ReadAllText("heroes.json");
            try
            {
                _heroes = JsonConvert.DeserializeObject<List<Hero>>(jsonText) ?? new List<Hero>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _heroes = new List<Hero>();
            }
        }

        public static Hero GetTheBest()
        {
            Hero theBest = _heroes[51];
            return theBest;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //
        //PART A
        //


        /*
         

        Part A-1: ShowHeroes
             The method should loop over the _heroes list and print the hero ID and the hero Name.
        */

        public static void ShowHeroes(int numHeroes = 0)
        {
            if (numHeroes == 0)
            {
                for (int i = 0; i < _heroes.Count; i++)
                {
                    Console.WriteLine($" {_heroes[i].Id}. {_heroes[i].Name}");

                }
            }
            else if (numHeroes != 0)
            {
                for (int i = 0; i < numHeroes; i++)
                {
                    Console.WriteLine($" {_heroes[i].Id}. {_heroes[i].Name}");
                }
            }
        }

        /*
         
        Part A-2: PrintHero
             The method should have a Hero parameter passed to it.Print the details of the Hero parameter(ID, Name, Powerstats.Intelligence, etc)
              See the lab document for a screenshot example under part A-3.

            Use the dot operator to gain access to members of a type.
            EX: to get to the Intelligence value on the Powerstats...  heroObject.Powerstats.Intelligence

        */

        public static void PrintHero(Hero hero)
        {
            //Display message confirmming that the hero has been found
            Console.Write("\n");
            Console.WriteLine($"{hero.Name} has been found!");

            //HEADER
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n");
            Console.Write($"{hero.Id}. {hero.Name}");

            //POWERSTATS
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n");
            Console.WriteLine("\t-----STATS-----");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\t\tIntelligence: ");
            Console.WriteLine(hero.Powerstats.Intelligence);
            Console.Write("\t\tStrength: ");
            Console.WriteLine(hero.Powerstats.Strength);
            Console.Write("\t\tSpeed: ");
            Console.WriteLine(hero.Powerstats.Speed);
            Console.Write("\t\tDurability: ");
            Console.WriteLine(hero.Powerstats.Durability);
            Console.Write("\t\tPower: ");
            Console.WriteLine(hero.Powerstats.Power);
            Console.Write("\t\tCombat: ");
            Console.WriteLine(hero.Powerstats.Combat);

            //APPEARANCE
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n");
            Console.WriteLine("\t-----APPEARANCE-----");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\t\tRace: ");
            Console.WriteLine(hero.Appearance.Race);
            Console.Write("\t\tHeight: ");
            Console.WriteLine(hero.Appearance.Height[1]);
            Console.Write("\t\tWeight: ");
            Console.WriteLine(hero.Appearance.Weight[1]);
            Console.Write("\t\tEye Color: ");
            Console.WriteLine(hero.Appearance.EyeColor);
            Console.Write("\t\tHair Color: ");
            Console.WriteLine(hero.Appearance.HairColor);

            //BIO
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n");
            Console.WriteLine("\t-----BIOGRAPHY-----");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\t\tFull Name: ");
            Console.WriteLine(hero.Biography.FullName);
            Console.Write("\t\tAlter Egos: ");
            Console.WriteLine(hero.Biography.AlterEgos);
            Console.Write("\t\tAliases: ");
            Console.WriteLine(hero.Biography.Aliases[0]);
            Console.Write("\t\tPlace of Birth: ");
            Console.WriteLine(hero.Biography.PlaceOfBirth);
            Console.Write("\t\tFirst Appearance: ");
            Console.WriteLine(hero.Biography.FirstAppearance);
            Console.Write("\t\tPublisher: ");
            Console.WriteLine(hero.Biography.Publisher);
            Console.Write("\t\tAlignment: ");
            Console.WriteLine(hero.Biography.Alignment);

            //WORK
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n");
            Console.WriteLine("\t-----WORK-----");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\t\tOccupation: ");
            Console.WriteLine(hero.Work.Occupation);

            //CONNECTIONS
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n");
            Console.WriteLine("\t-----CONNECTIONS-----");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\t\tGroup Affiliation: ");
            Console.WriteLine(hero.Connections.GroupAffiliation);
            
        }

        /*
         
        Part A-3: FindHero
             The method should have a string parameter for the name to search.
             The method needs to loop over the heroes list to try to find the hero.

                 Check if the hero name matches the parameter. If so, break out of the loop and return the found hero.

            (see the GetTheBest method on how to return a Hero object)

        */

        public static Hero? FindHero(string heroName)
        {
            foreach (Hero hero in _heroes)
            {
                if (hero.Name == heroName)
                {
                    PrintHero(hero);
                    return hero;
                }
            }
            return null;
        }




        //---------------------------------------------------------------------------------------------------------------------------------------------
        //
        //PART B
        //




        /*
         
        Part B-1: RemoveHero
             The method should have a string parameter for the name of the hero to remove.
             The method should loop over the heroes list.
             If the hero is found, remove the hero from the heroes list.
             Return true if the hero was found and removed.

             Return false if the hero was not found.

        */

        public static bool RemoveHero(string heroName)
        {
            bool heroFound = false;

            for (int i = 0; i < _heroes.Count; i++)
            {
                if (_heroes[i].Name == heroName)
                {
                    _heroes.RemoveAt(i);
                    heroFound = true;
                }
            }
            return heroFound;
        }

        /*
         
        Part B-2: StartsWith
             The method should have a string parameter for the name of the hero to match and a ref parameter for the List of heroes that were found.
             Loop over the heroes list and add every hero whose name starts with the string parameter to the List parameter. 

        */

        public static void StartsWith(string heroName, ref List<Hero> foundHero)
        {
            foundHero = new List<Hero>();

            foreach (var hero in _heroes)
            {
                if (hero.Name.StartsWith(heroName))
                {
                    foundHero.Add(hero);
                }
            }
        }

        /*
         
        Part B-3: RemoveAllHeroes
             The method should have a string parameter for the name of the hero to match and an out parameter for the List of heroes that were found and removed.
             Initialize the list inside the RemoveAllHeroes method
             Loop over the heroes list and add every hero whose name starts with the string parameter to the List parameter.

             Make sure to remove the hero from the heroes list.

        */

        public static void RemoveAllHeroes(string heroName, out List<Hero> removedHero)
        {
            removedHero = new List<Hero>();

            for (int i = 0; i < _heroes.Count; i++)
            {
                if (_heroes[i].Name.StartsWith(heroName))
                {
                    removedHero.Add(_heroes[i]);
                    //_heroes.Remove(hero);
                    _heroes.RemoveAt(i);
                    i--;
                }
                
            }
        }


        //---------------------------------------------------------------------------------------------------------------------------------------------
        //
        //PART C   
        //
        //


        /*
         
        Part C-1: Optional Parameter
              Add an optional parameter to the ShowHeroes method(see part A-1). Default it to 0.
              In the method,
              if the parameter has the default value of 0,
                  show all the heroes
              else
                  show the number of heroes that match the parameter.Example, if 10 is passed in, only show the first 10 heroes.

        */

    }
}
