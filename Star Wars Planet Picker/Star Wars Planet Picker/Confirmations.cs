using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Wars
{
    public static class Confirmations
    {
        public static bool Confirm()
        {
            string selectionConfirm = Console.ReadLine().ToUpper();
            if (selectionConfirm == "Y")
            {
                return true;
            }
            return false;
        }

        public static void WithinRange()
        {
            Console.WriteLine("Please enter a number within the range...");
        }

        public static void NotANumber()
        {
            Console.WriteLine("Please enter in a valid number...");
        }

        public static void Return()
        {
            Console.WriteLine("Type R to return to main menu, key anything else to exit program");
            string selectionConfirm = Console.ReadLine().ToUpper();
            if (selectionConfirm == "R")
            {
                MainMenu.DisplayMainMenu();
            }
            else
            {
                Environment.Exit(0); //exits program.
            }
        }
        public static void PrintScore(List<SWPlanets> fileContents)
        {
            Console.WriteLine("Type S to display a full list of planets with their corresponding score");
            string selectionConfirm = Console.ReadLine().ToUpper();
            if (selectionConfirm == "S")
            {
                Calculations.ListPlanetsScore(fileContents);
            }
        }
    }
}
