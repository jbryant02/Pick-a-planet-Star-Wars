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
                //Console.WriteLine(biomeString[counter]);
                counter++;
            }
            char[] stringsToTrim = { '\n', ' ', '\r', '\t', ',' };
            var biomeArray = string.Join(",", biomeString.ToArray()).Trim(stringsToTrim).Trim(); //Joins the list of strings to an array. Trims whitespace and unwated characters.
            string[] biomeSplit = biomeArray.Split(","); //Splits the array into a list of strings to seperate the values hidden within the cells
            var biomeDistinct = biomeSplit.Distinct(); //Gives only the distinct terrains.
            var biomeList = biomeDistinct.ToList(); //Converts to a list.
            var counter1 = 0;
            foreach (var i in biomeList)
            {

                //Console.WriteLine(biomeList[counter1]);
                counter1++;
            }
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
                Console.WriteLine("Please enter in a valid number... Sorry... TK421 is not a number.");
                goto ReadLine;
            }
            if (biomePickParse > BiomeDict.Count || biomePickParse < 0)
            {
                Console.WriteLine("Please enter a number within the range... because right now it's as if millions of voices cried out and were suddenly silenced");
                goto ReadLine;
            }
            else
            {
                
                return biomePickParse;
            }
        }

        public static int PickPopulation()
        {
            Console.WriteLine($"Which population size do you prefer? Select 1 for Small, 2 for Medium, or 3 for Large");
        ReadLine: var popPick = Console.ReadLine(); //reads the population selected.
            bool success = Int32.TryParse(popPick, out int popPickParse); //Parses the biome to an int to be used in the PickMyPlanet method.
            if (success)
            {
            }
            else
            {
                Console.WriteLine("Please enter in a valid number... and never tell me the odds"); //Ensures input can be converted into an int.
                goto ReadLine;
            }
            if (popPickParse < 1 || popPickParse > 3) //Ensures number selected is within scope.
            {
                Console.WriteLine("Please enter a number within the range-- for example... three thousand seven hundred and twenty is too high!");
                goto ReadLine;
            }
            else
            {
                return popPickParse;
            }
        }

        public static int PickSurfaceWater()
        {
            Console.WriteLine($"Which surface water size size do you prefer? Select 1 for Small (0%-29.99%), 2 for Medium(30%-60%), or 3 for Large(60.01%+)");
        ReadLine: var waterPick = Console.ReadLine();
            bool success = Int32.TryParse(waterPick, out int waterPickParse);
            if (success)
            {
            }
            else
            {
                Console.WriteLine("Please enter in a valid number... and stop that ship... Blast em!"); //Ensures input can be converted into an int.
                goto ReadLine;
            }
            if (waterPickParse < 1 || waterPickParse > 3) //Ensures number selected is within scope.
            {
                Console.WriteLine("Please enter a number within the range-- or one thing's for sure, we're all gonna be a lot thinner!");
                goto ReadLine;
            }
            else
            {
                return waterPickParse;
            }

        }

        public static string PickMyPlanet(int popq, int terrainq, int terrainq2, int terrainq3, int waterq, List<SWPlanets> sw)
        {

            if (popq == 1)
            {
                var lowPop = from i in sw
                             where (i.Population < i.LowPopulation && i.Population > 1)
                             select i;
                var lowPopList = lowPop.ToList();
                var counter = 0;
                foreach (var i in lowPopList)
                {
                    lowPopList[counter].Score += 100;
                    //Console.WriteLine(lowPopList[counter].Name);
                    //Console.WriteLine(lowPopList[counter].Score);
                    counter++;
                }
            }
            if (popq == 2)
            {
                var medPop = from i in sw
                             where (i.Population >= i.LowPopulation && i.Population <= i.MedPopulation)
                             select i;
                var medPopList = medPop.ToList();
                var counter = 0;

                foreach (var i in medPopList)
                {
                    medPopList[counter].Score += 100;
                    //Console.WriteLine(medpopList[counter].Name);
                    //Console.WriteLine(medpopList[counter].Score);
                    counter++;
                }
            }
            if (popq == 3)
            {
                var highPop = from i in sw
                              where (i.Population > i.MedPopulation)
                              select i;
                var highPopList = highPop.ToList();
                var counter = 0;

                foreach (var i in highPopList)
                {
                    highPopList[counter].Score += 100;
                    //Console.WriteLine(highpopList[counter].Name);
                    //Console.WriteLine(highpopList[counter].Score);
                    counter++;
                }
            }

            if (BiomeDict.TryGetValue(terrainq, out string myValue)) //searches dictionary for value.
            {
                var biomeScore = from i in sw
                                 where i.Terrain.Contains(myValue) //selects Terrain that contains the biome selection
                                 select i;
                var counter = 0;
                var biomeScoreList = biomeScore.ToList();
                foreach (var i in biomeScoreList)
                {
                    biomeScoreList[counter].Score += 100; //Takes all selected values and adds 100 to the score.
                    //Console.WriteLine(biomeScoreList[counter].Name);
                    //Console.WriteLine(biomeScoreList[counter].Score);
                    counter++;
                }
            }
            if (BiomeDict.TryGetValue(terrainq2, out string myValue2)) //Unsure of how not to repeat code here...
            {
                var biomeScore = from i in sw
                                 where i.Terrain.Contains(myValue2)
                                 select i;
                var counter = 0;
                var biomeScoreList = biomeScore.ToList();
                foreach (var i in biomeScoreList)
                {
                    biomeScoreList[counter].Score += 100;
                    //Console.WriteLine(biomeScoreList[counter].Name);
                    //Console.WriteLine(biomeScoreList[counter].Score);
                    counter++;
                }
            }
            if (BiomeDict.TryGetValue(terrainq3, out string myValue3)) 
            {
                var biomeScore = from i in sw
                                 where i.Terrain.Contains(myValue3)
                                 select i;
                var counter = 0;
                var biomeScoreList = biomeScore.ToList();
                foreach (var i in biomeScoreList)
                {
                    biomeScoreList[counter].Score += 100;
                    //Console.WriteLine(biomeScoreList[counter].Name);
                    //Console.WriteLine(biomeScoreList[counter].Score);
                    counter++;
                }
            }
            else
            {
                Console.WriteLine("Error... I've got a bad feeling about this.");
            }

            if (waterq == 1)  //sorts through water selection, adds score if value is selected to appropriate planets.
            {
                var smallWater = from i in sw
                              where (i.Surface_water < 30)
                              select i;
                var smallWaterList = smallWater.ToList();
                var counter = 0;
                foreach (var i in smallWaterList)
                {
                    smallWaterList[counter].Score += 100;
                    counter++;
                }
            }
            if (waterq == 2)
            {
                var medWater = from i in sw
                                 where (i.Surface_water >= 30 && i.Surface_water <= 60)
                                 select i;
                var medWaterList = medWater.ToList();
                var counter = 0;
                foreach (var i in medWaterList)
                {
                    medWaterList[counter].Score += 100;
                    counter++;
                }
            }
            if (waterq == 3)
            {
                var largeWater = from i in sw
                                 where (i.Surface_water > 60)
                                 select i;
                var largeWaterList = largeWater.ToList();
                var counter = 0;
                foreach (var i in largeWaterList)
                {
                    largeWaterList[counter].Score += 100;
                    //Console.WriteLine(largeWaterList[counter].Name);
                    //Console.WriteLine(largeWaterList[counter].Score);
                    counter++;
                }
            }

            var pickedPlanets = (from i in sw
                                orderby i.Score descending
                                 select i).Take(5);
            var pickedPlanetsList = pickedPlanets.ToList();
            var counter1 = 0;
            Console.WriteLine("Based upon your results, your top planets are:");
            foreach (var i in pickedPlanetsList)
            {
                Console.WriteLine($"{pickedPlanetsList[counter1].Name} with a score of {pickedPlanetsList[counter1].Score} out of 500... Let me google that for you! https://www.google.com/search?q=Wookiepedia_{pickedPlanetsList[counter1].Name.Replace(" ","")}");
                counter1++;
            }

            return "";
        }
        public static void ListPlanetsScore(List<SWPlanets> sw)
        {
            var counter = 0;
            foreach (var i in sw) //sorts through planets and provides names and scores.
            {
                Console.WriteLine($"{sw[counter].Name}: {sw[counter].Score}");
                counter++;
            }

        }
    }
}