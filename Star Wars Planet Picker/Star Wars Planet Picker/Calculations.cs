using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Linq;

namespace Star_Wars
{
    public class Calculations
    {
        public static Dictionary<int, string> BiomeDict = new Dictionary<int, string>();//Dictionary for creating key value pairs between biomes and their respective value for implementation in the scoring system.
        public static List<string> GetMostPopulous(List<SWPlanets> sw) //Gets most populous planets, takes the top 5, and converts to string.
        {
            var mostPop = (from i in sw
                           orderby i.Population descending
                           select i).Take(5);
            var mostPopString = new List<string>();
            foreach (var i in mostPop)
            {
                mostPopString.Add(i.Name.ToString());
            }
            return mostPopString;
        }
        public static List<string> GetLeastPopulous(List<SWPlanets> sw)//Gets least populous planets, excluding those with 0, and takes the top 5, and converts to string.
        {
            var leastPop = (from i in sw
                            where (i.Population >= 1)
                            orderby i.Population ascending
                            select i).Take(5);
            var leastPopString = new List<string>();
            foreach (var i in leastPop)
            {
                leastPopString.Add(i.Name.ToString());
            }
            return leastPopString;
        }
        public static List<string> GetBiomes(List<SWPlanets> sw) //Gets the biomes available.
        {
            var biome = (from i in sw
                         where (i.Terrain != "NA") //prevents items without values from being entered.
                         orderby i.Terrain ascending
                         select i);
            var biomeString = new List<string>();
            var counter = 0;
            foreach (var i in biome)
            {
                biomeString.Add(i.Terrain.ToString());
                counter++;
            }
            char[] stringsToTrim = { '\n', ' ', '\r', '\t', ',' };
            var biomeArray = string.Join(",", biomeString.ToArray()).Trim(stringsToTrim).Trim(); //Joins the list of strings to an array. Trims whitespace and unwated characters.
            string[] biomeSplit = biomeArray.Split(","); //Splits the array into a list of strings to seperate the values hidden within the cells
            var biomeDistinct = biomeSplit.Distinct(); //Gives only the distinct terrains.
            var biomeList = biomeDistinct.ToList(); //Converts to a list.
            return biomeList; //returns List
        }

        public static int PickBiome(List<string> biome)
        {

            int counter = 0;
            if (BiomeDict.Count == 0) //checks to verify the dict is empty.
            {
                foreach (var i in biome)
                {
                    Console.WriteLine($"Key {counter} to select {biome[counter]}"); //Prompts the user to select a biome.
                    Calculations.BiomeDict.Add(counter, biome[counter]); //Adds each to a dictionary to be used in the PickMyPlanet scoring system.
                    counter++;
                }
            }
            else
            {
                Console.WriteLine("Please select an additional biome!");
            }
            
        ReadLine: var biomePick = Console.ReadLine(); //reads the Biome selected.
            bool success = Int32.TryParse(biomePick, out int biomePickParse); //Parses the biome to an int to be used in the PickMyPlanet method.
            if (success)
            {
            }
            else
            {
                Confirmations.NotANumber();
                goto ReadLine;
            }
            if (biomePickParse > BiomeDict.Count || biomePickParse < 0)
            {
                Confirmations.WithinRange();
                goto ReadLine;
            }
            else
            {
                
                return biomePickParse;
            }
        }

        public static int PickPopulation()
        {
            Console.WriteLine($"Which population size do you prefer? \n" +
                $"Select 1 for Small (Less than 10 million)\n" +
                $"Select 2 for Medium (Between 10 million and 2.999 billion)\n" +
                $"Select 3 for Large (3 billion +)");
        ReadLine: var popPick = Console.ReadLine(); //reads the population selected.
            bool success = Int32.TryParse(popPick, out int popPickParse); //Parses the biome to an int to be used in the PickMyPlanet method.
            if (success)
            {
            }
            else
            {
                Confirmations.NotANumber();
                goto ReadLine;
            }
            if (popPickParse < 1 || popPickParse > 3) //Ensures number selected is within scope.
            {
                Confirmations.WithinRange();
                goto ReadLine;
            }
            else
            {
                return popPickParse;
            }
        }

        public static int PickSurfaceWater()
        {
            Console.WriteLine($"Which surface water % do you prefer? \n" +
                $"Select 1 for Small (0%-29.99%)\n" +
                $"Select 2 for Medium(30%-59.9%) \n" +
                $"Select 3 for Large(60.0%+)");
        ReadLine: var waterPick = Console.ReadLine();
            bool success = Int32.TryParse(waterPick, out int waterPickParse);
            if (success)
            {
            }
            else
            {
                Confirmations.NotANumber(); //Ensures input can be converted into an int.
                goto ReadLine;
            }
            if (waterPickParse < 1 || waterPickParse > 3) //Ensures number selected is within scope.
            {
                Confirmations.WithinRange();
                goto ReadLine;
            }
            else
            {
                return waterPickParse;
            }

        }

        public static void PickMyPlanet(int popq, int terrainq, int terrainq2, int terrainq3, int waterq, List<SWPlanets> sw)
        {

            if (popq == 1)
            {
                var smallPop = 10_000_000;
                var lowerLimit = 0;
                Calculations.PopPick(lowerLimit, smallPop, sw);
            }
            if (popq == 2)
            {
                var medPop = 3_000_000_000;
                var lowerLimit = 10_000_000;
                Calculations.PopPick(lowerLimit, medPop, sw);
            }
            if (popq == 3)
            {
                var largePop = 9_223_372_036_854_775_807; //unable to not use a maximum limit in the method being used, used the int 64 max which is the highest number a user can put in.
                var lowerLimit = 3_000_000_000;
                Calculations.PopPick(lowerLimit, largePop, sw);
            }

            if (BiomeDict.TryGetValue(terrainq, out string myValue)) //searches dictionary for value.
            {
                AddBiomeScore(myValue, sw);
            }
            if (BiomeDict.TryGetValue(terrainq2, out string myValue2))
            {
                AddBiomeScore(myValue2, sw);
            }
            if (BiomeDict.TryGetValue(terrainq3, out string myValue3)) 
            {
                AddBiomeScore(myValue3, sw);
            }
            else
            {
                Console.WriteLine("Error... I've got a bad feeling about this.");
            }

            if (waterq == 1)  //sorts through water selection, adds score if value is selected to appropriate planets.
            {
                var smallWater = 30;
                var lowerLimit = 0;
                Calculations.AddWaterScore(smallWater, lowerLimit, sw); //calls method to add score to relevant planets.


            }
            if (waterq == 2)
            {
                var medWater = 60;
                var lowerLimit = 30;
                Calculations.AddWaterScore(medWater, lowerLimit, sw);

            }
            if (waterq == 3)
            {
                var largeWater = 101; //set 1 above so I can use only a less than operator in the method.
                var lowerLimit = 60;
                Calculations.AddWaterScore(largeWater, lowerLimit, sw);

            }

            var pickedPlanets = (from i in sw
                                orderby i.Score descending
                                 select i).Take(5);
            var pickedPlanetsList = pickedPlanets.ToList();
            var counter1 = 0;
            Console.WriteLine("Based upon your results, your top planets are:");
            foreach (var i in pickedPlanetsList)
            {
                Console.WriteLine($"{pickedPlanetsList[counter1].Name} with a criteria matched  " +
                    $"{pickedPlanetsList[counter1].Score / 100} out of 5... Let me google that for you! \n" + 
                    //Displays the score divided by 100 to get the total match. Originally had a 100 based score, but decided that planets that matched x number of critera 
                    //more clear and it was more simple to divide this by 100 then change all the score calculations.
                    $"https://www.google.com/search?q=Wookiepedia_{pickedPlanetsList[counter1].Name.Replace(" ","")}"); //Prints out a hyper link to google with a search for the planet.
                counter1++;
            }
        }
        public static void ListPlanetsScore(List<SWPlanets> sw)
        {
            var counter = 0;
            foreach (var i in sw) //sorts through planets and provides names and scores.
            {
                Console.WriteLine($"{sw[counter].Name}: {sw[counter].Score / 100}");
                counter++;
            }
        }
        public static void ListAllPlanets(List<SWPlanets> sw)
        {
            var counter = 0;
            foreach (var i in sw) //sorts through planets and provides all info.
            {
                Console.WriteLine($"{sw[counter].Name}: Climate(s): {sw[counter].Climate}, \n " +
                    $"Terrain(s): {sw[counter].Terrain}, Surface Water: {sw[counter].Surface_water}%, \n " +
                    $"Population: {sw[counter].Population} \n"); //excluded some mostly unused items to reduce the amount of content.
                counter++;
            }
        }
        public static void AddBiomeScore(string myValue, List<SWPlanets> sw)
        {
            var biomeScore = from i in sw
                             where i.Terrain.Contains(myValue) //selects Terrain that contains the biome selection
                             select i;
            var counter = 0;
            var biomeScoreList = biomeScore.ToList();
            foreach (var i in biomeScoreList)
            {
                biomeScoreList[counter].Score += 100; //Takes all selected values and adds 100 to the score.
                counter++;
            }
        }
        public static void AddWaterScore(int waterMaxLimit, int waterLowerLimit, List<SWPlanets> sw)
        {
            var WaterSelection = from i in sw //the code below matches the selection to planets meeting the criteria and assigns them a score of an additonal 100.
                             where (i.Surface_water <  waterMaxLimit && i.Surface_water >=  waterLowerLimit)
                             select i;
            var WaterList = WaterSelection.ToList();
            var counter = 0;
            foreach (var i in WaterList)
            {
                WaterList[counter].Score += 100;
                counter++;
            }
        }
        public static void PopPick(Int64 popqMinLimit, Int64 popqMaxLimit, List<SWPlanets> sw)
        {
            var Pop = from i in sw
                      where (i.Population < popqMaxLimit && popqMinLimit <= i.Population)
                      select i;
            var PopList = Pop.ToList();
            var counter = 0;
            foreach (var i in PopList)
            {
                PopList[counter].Score += 100;
                counter++;
            }
        }
        public static void DictClear()
        {
            BiomeDict.Clear(); //clears the dictionary so the user can take the test again and the biomes will display.
        }
    }
}