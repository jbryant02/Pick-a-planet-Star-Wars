using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Wars
{
    class MainMenu
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("Please select an option below: \n" +
                "1: Display a list of all current planets. \n" +
                "2: Show some superlatives about the planets \n" +
                "3: Create a new planet \n" +
                "4: Edit an existing planet \n" +
                "5: Delete an existing planet \n" +
                "6: Answer a few questions to find a Stars planet that suits you!");
            var fileName = ReadDocument.ReadFileforPath();
            var mainMenuPick = Console.ReadLine();
            var success = Int32.TryParse(mainMenuPick, out int mainMenuSelectionParse);
            if (success)
            {
                if (mainMenuSelectionParse == 1) //Called methods here and below instead of using the if statements in case I ever want to expand the program to be able to call a method without relying on user input.
                {
                    ListofPlanets(fileName);
                }
                if (mainMenuSelectionParse == 2)
                {
                    Superlatives(fileName);
                }
                if (mainMenuSelectionParse == 3)
                {
                    CreateAPlanet(fileName);
                }
                if (mainMenuSelectionParse == 4)
                {
                    EditAPlanet(fileName);
                }
                if (mainMenuSelectionParse == 5)
                {
                    DeleteAPlanet(fileName);
                }
                if (mainMenuSelectionParse == 6)
                {
                    PickMyPlanet(fileName);
                }
                else
                {
                    Confirmations.WithinRange();
                }
            }
            else
            {
                Confirmations.NotANumber();
            }
        }

        public static void ListofPlanets(string fileName)
        {
            var fileContents = ReadDocument.ReadFileforList(fileName); //The methods are designed to read every time... this was done because when a user changes something, it should be reflected in the data the next time they try and call another method,
            Calculations.ListAllPlanets(fileContents);
            Confirmations.Return();
        }
        public static void Superlatives(string fileName)
        {
            var fileContents = ReadDocument.ReadFileforList(fileName);
            var topFivePop = Calculations.GetMostPopulous(fileContents);
            var bottomFivePop = Calculations.GetLeastPopulous(fileContents);
            Console.WriteLine($"The top five most populous planets are: \n{ string.Join("\n", topFivePop)}");
            Console.WriteLine($"The top five least populous planets are: \n{ string.Join("\n", bottomFivePop)}");
            Confirmations.Return();
        }
        public static void CreateAPlanet(string fileName)
        {
            Console.WriteLine("Perhaps the archives are incomplete?");
            var fileContents = ReadDocument.ReadFileforList(fileName);
            WriteDocument.WriteSWPlanets(fileName, fileContents);
            Confirmations.Return();
        }
        public static void EditAPlanet(string fileName)
        {
            var fileContents = ReadDocument.ReadFileforList(fileName);
            EditPlanet.AlterSWPlanets(fileName, fileContents); //Will need to initate a new document read in case the user has created a new planet.
            Confirmations.Return();
        }
        public static void DeleteAPlanet(string fileName)
        {
            var fileContents = ReadDocument.ReadFileforList(fileName);
            EditPlanet.DeleteSWPlanets(fileName, fileContents);
            Confirmations.Return();
        }
        public static void PickMyPlanet(string fileName)
        {
            var fileContents = ReadDocument.ReadFileforList(fileName);
            var biomes = Calculations.GetBiomes(fileContents);
            var pickPop = Calculations.PickPopulation();
            var pickBiome = Calculations.PickBiome(biomes);
            var pickBiome2 = Calculations.PickBiome(biomes);
            var pickBiome3 = Calculations.PickBiome(biomes);
            var pickSurfaceWater = Calculations.PickSurfaceWater();
            var myPlanet = Calculations.PickMyPlanet(pickPop, pickBiome, pickBiome2, pickBiome3, pickSurfaceWater, fileContents);
            Confirmations.PrintScore(fileContents);
            Confirmations.Return();
        }
    }
}
