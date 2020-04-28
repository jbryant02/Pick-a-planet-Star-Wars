using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Wars
{
    public static class Confirmations
    {
        public static bool Confirm() 
            //gets confirmation for different methods... if a user types y it returns true to enter an if statement. 
            //It returns false to skip the if statement to either return to the main menu or exit the project.
        {
            string selectionConfirm = Console.ReadLine().Trim().ToUpper();
            if (selectionConfirm == "Y")
            {
                return true;
            }
            if (selectionConfirm == "R")
            {
                MainMenu.DisplayMainMenu();
                Console.Clear();
                return false;
            }
            else
            {
                return false;
            }
        }

        public static void WithinRange()
        {
            Console.WriteLine("Please enter a number within the range...");  //Provides feedback if the user input is outside of the range.
        }

        public static void NotANumber()
        {
            Console.WriteLine("Please enter in a valid number..."); //Provides feedback if the user input is not a number.
        }

        public static void Return() //checks for user input to either return to the main menu or exit the program.
        {
            Console.WriteLine("Type R to return to main menu, key anything else to exit program");
            string selectionConfirm = Console.ReadLine().Trim().ToUpper(); 
            if (selectionConfirm == "R")
            {
                Console.Clear();
                MainMenu.DisplayMainMenu();
            }
            else
            {
                Environment.Exit(0); //exits program.
            }
        }
        public static void PrintScore(List<SWPlanets> fileContents) //checks for confirmation to display full list of scores.
        {
            Console.WriteLine("\n\nType S to display a full list of planets with their corresponding matches to your criteria");
            string selectionConfirm = Console.ReadLine().Trim().ToUpper();
            if (selectionConfirm == "S")
            {
                Console.Clear();
                Calculations.ListPlanetsScore(fileContents);
            }
        }
    }
}
