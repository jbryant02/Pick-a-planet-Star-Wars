using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Wars
{
    class MainMenu
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("-------------------------------------------------------------------------" +
                "\nPlease select an option below:                                          ||\n" +
                "[1]: Display a list of all current planets.                             ||\n" +
                "[2]: Show some superlatives about the planets.                          ||\n" +
                "[3]: Create a new planet                                                ||\n" +
                "[4]: Edit an existing planet                                            ||\n" +
                "[5]: Delete an existing planet                                          ||\n" +
                "[6]: Answer a few questions to find a Star Wars planet that suits you!  ||\n" +
                "[7]: Exit program                                                       ||" +
                "\n-------------------------------------------------------------------------");
            var fileName = ReadDocument.ReadFileforPath(); //calls read file path method to get to the directory that contains the csv and saves it as a string.
            var mainMenuPick = Console.ReadLine(); //prompts user input to get a selection.
            var success = Int32.TryParse(mainMenuPick, out int mainMenuSelectionParse);
            if (success)
            {
                if (mainMenuSelectionParse == 1) //Called methods here and below instead of using the if statements in case I ever want to expand the program to be able to call a method without relying on user input.
                {
                    ListofPlanets(fileName);  //List planets
                }
                if (mainMenuSelectionParse == 2)
                {
                    Superlatives(fileName); //List superlatives
                }
                if (mainMenuSelectionParse == 3)
                {
                    CreateAPlanet(fileName); //Create a planet
                }
                if (mainMenuSelectionParse == 4)
                {
                    EditAPlanet(fileName); //Edit a planet
                }
                if (mainMenuSelectionParse == 5)
                {
                    DeleteAPlanet(fileName); //Delete a planet
                }
                if (mainMenuSelectionParse == 6)
                {
                    PickMyPlanet(fileName); //Primary intended function, helps user find a planet they might be interested after a short quiz.
                }
                if (mainMenuSelectionParse == 7)
                {
                    Environment.Exit(0); //Exits program.
                }
                else
                {
                    Confirmations.WithinRange(); //confirms within range.
                }
            }
            else
            {
                Confirmations.NotANumber(); //Confirms user input is a number.
            }
        }
        //The methods below are designed to re-read every time they are called... this was done because when a user changes something, it should be reflected in the data the next time they try and call another method,
        public static void ListofPlanets(string fileName)
        {
            Console.Clear();
            var fileContents = ReadDocument.ReadFileforList(fileName); 
            Calculations.ListAllPlanets(fileContents);
            Confirmations.Return();
        }
        public static void Superlatives(string fileName)
        {
            Console.Clear();
            var fileContents = ReadDocument.ReadFileforList(fileName);
            var topFivePop = Calculations.GetMostPopulous(fileContents);
            var bottomFivePop = Calculations.GetLeastPopulous(fileContents);
            Console.WriteLine($"The top five most populous planets are: \n{ string.Join("\n", topFivePop)}");
            Console.WriteLine($"The top five least populous planets are: \n{ string.Join("\n", bottomFivePop)}");
            Confirmations.Return();
        }
        public static void CreateAPlanet(string fileName)
        {
            Console.Clear();
            Console.WriteLine("It should be here... but it isn't.\n");
            var fileContents = ReadDocument.ReadFileforList(fileName);
            WriteDocument.WriteSWPlanets(fileName, fileContents);
            Confirmations.Return();
        }
        public static void EditAPlanet(string fileName)
        {
            Console.Clear();
            Console.WriteLine("Perhaps the archives are incomplete?\n");
            var fileContents = ReadDocument.ReadFileforList(fileName);
            EditPlanet.AlterSWPlanets(fileName, fileContents); 
            Confirmations.Return();
        }
        public static void DeleteAPlanet(string fileName)
        {
            Console.Clear();
            Console.WriteLine("I felt a great disturbance in the Force, as if millions of voices suddenly cried out in terror and were suddenly silenced.\n");
            var fileContents = ReadDocument.ReadFileforList(fileName);
            EditPlanet.DeleteSWPlanets(fileName, fileContents);
            Confirmations.Return();
        }
        public static void PickMyPlanet(string fileName)
        {
            Console.Clear();
            Console.WriteLine("You will answer a couple of questions and select three biomes of choice. " +
                "\nFor each answer you give it will find all of the planets that meet that critera. " +
                "\nWhen finished it will display a list of the top five planets with \nthe most amount of matches to your critera." +
                "\n \nPress Y to continue, R to return to the main menu or anything else to exit.");
            if (Confirmations.Confirm())
            {
                Calculations.DictClear(); //clears the dictionary so the test can be retaken.
                var fileContents = ReadDocument.ReadFileforList(fileName); //reads doc
                var biomes = Calculations.GetBiomes(fileContents); //gets a list of biome
                var pickPop = Calculations.PickPopulation(); //prompts population pick
                var pickBiome = Calculations.PickBiome(biomes); //next three questions take biome selections.
                var pickBiome2 = Calculations.PickBiome(biomes);
                var pickBiome3 = Calculations.PickBiome(biomes);
                var pickSurfaceWater = Calculations.PickSurfaceWater(); //prompts and reads surface water question
                Calculations.PickMyPlanet(pickPop, pickBiome, pickBiome2, pickBiome3, pickSurfaceWater, fileContents); //takes all the previous variables to get score.
                Confirmations.PrintScore(fileContents); //Prints score.
            }
            Confirmations.Return();
        }
    }
}
