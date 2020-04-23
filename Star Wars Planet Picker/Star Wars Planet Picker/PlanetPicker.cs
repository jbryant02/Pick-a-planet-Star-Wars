using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Star_Wars
{

    class PlanetPicker
    {
        static void Main(string[] args)
        {
            string cd = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(cd);
            var fileName = Path.Combine(directory.FullName, "planets.csv"); //Calls the combine method to ensure the path given to the Read
            var fileContents = ReadDocument.ReadSWPlanets(fileName); //Calls the ReadSWPlanets method within the ReadDocument class and passes through the file name from the above line.
            var planet = new List<SWPlanets>();
            var topFivePop = Calculations.GetMostPopulous(fileContents);
            var bottomFivePop = Calculations.GetLeastPopulous(fileContents);
            WriteDocument.WriteSWPlanets(fileName, fileContents);
            var biomes = Calculations.GetBiomes(fileContents);
            var pickPop = Calculations.PickPopulation();
            var pickBiome = Calculations.PickBiome(biomes);
            var pickBiome2 = Calculations.PickBiome(biomes);
            var pickBiome3 = Calculations.PickBiome(biomes);
            var pickSurfaceWater = Calculations.PickSurfaceWater();
            var myPlanet = Calculations.PickMyPlanet(pickPop, pickBiome, pickBiome2, pickBiome3, pickSurfaceWater, fileContents);
            //Calculations.ListPlanetsScore(fileContents);
            //Console.WriteLine($"The top five most populous planets are: \n{ string.Join("\n", topFivePop)}");
            //Console.WriteLine($"The top five least populous planets are: \n{ string.Join("\n", bottomFivePop)}");

            //Console.WriteLine($" The average population of the reported planets is: {planet.AveragePopulation = planet.Population / planet.Name.Count()} beings");
        }

    }
}
