using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Star_Wars
{

    class PlanetPicker
    {
        public static void Main(string[] args)
        {
            string cd = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(cd);
            string newPath = Path.GetFullPath(Path.Combine(cd, @"..\..\..\"));// Moves up three folders to select the csv.
            var fileName = Path.Combine(newPath, "planets.csv"); //Calls the combine method to ensure the path given to the Read
            var fileContents = ReadDocument.ReadSWPlanets(fileName); //Calls the ReadSWPlanets method within the ReadDocument class and passes through the file name from the above line.
            var planet = new List<SWPlanets>();

            DisplayMainMenu();//User input beings.
            var topFivePop = Calculations.GetMostPopulous(fileContents);
            var bottomFivePop = Calculations.GetLeastPopulous(fileContents);
            //WriteDocument.WriteSWPlanets(fileName, fileContents);
            //EditPlanet.DeleteSWPlanets(fileName, fileContents); //Will need to initate a new document read in case the user has created a new planet.
            EditPlanet.DeleteSWPlanets(fileName, fileContents);
            //var biomes = Calculations.GetBiomes(fileContents);
            //var pickPop = Calculations.PickPopulation();
            //var pickBiome = Calculations.PickBiome(biomes);
            //var pickBiome2 = Calculations.PickBiome(biomes);
            //var pickBiome3 = Calculations.PickBiome(biomes);
            //var pickSurfaceWater = Calculations.PickSurfaceWater();
            //var myPlanet = Calculations.PickMyPlanet(pickPop, pickBiome, pickBiome2, pickBiome3, pickSurfaceWater, fileContents);
            //Calculations.ListPlanetsScore(fileContents);
            //Console.WriteLine($"The top five most populous planets are: \n{ string.Join("\n", topFivePop)}");
            //Console.WriteLine($"The top five least populous planets are: \n{ string.Join("\n", bottomFivePop)}");

            //Console.WriteLine($" The average population of the reported planets is: {planet.AveragePopulation = planet.Population / planet.Name.Count()} beings");
        }

        public static void DisplayMainMenu()
        {
            Console.WriteLine("Please select an option below: \n" +
                "1: Display a list of all current planets. \n" +
                "2: Show some superlatives about the planets \n" +
                "3: Create a new planet \n" +
                "4: Edit an existing planet \n" +
                "5: Answer a few questions to find a Stars Planet that suits you!");
            Console.ReadLine();


        }
    }
}
