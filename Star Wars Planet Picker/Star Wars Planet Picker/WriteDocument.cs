using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Star_Wars
{
    class WriteDocument
    {


        public static void WriteSWPlanets(string fileName, List<SWPlanets> sw)
        {
            if (File.Exists(fileName))
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))  //allows appends to files without reading the entire doc and writing on to it.
                {

                    var newSWP = new SWPlanets();
                    Console.WriteLine("First enter in a planet name");
                    newSWP.Name = Console.ReadLine();
                    Console.WriteLine("Now enter in an rotational period, enter 0 if unknown. No letters!");
                ReadRotation: if (Int32.TryParse(Console.ReadLine(), out int Rotation)) //parses selection, the following code then attaches the newSWP and the selected values to a SWPlanet object.
                    {
                        newSWP.Rotation_period = Rotation;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid selection");
                        goto ReadRotation;
                    }
                    Console.WriteLine("Now enter in an orbital period, enter 0 if unknown. No letters!");
                ReadOrbit: if (Int32.TryParse(Console.ReadLine(), out int Orbit))
                    {
                        newSWP.Orbital_period = Orbit;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid selection");
                        goto ReadOrbit;
                    }
                    Console.WriteLine("Now enter in a Diameter, enter 0 if unknown. No letters!");
                ReadDiameter: if (Int32.TryParse(Console.ReadLine(), out int Diameter))
                    {
                        newSWP.Diameter = Diameter;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid selection");
                        goto ReadDiameter;
                    }
                    Console.WriteLine("Now enter in Climate information, in order to correctly submit multiple entries, please key as comma seperated values without spaces- I.E. - temperate,arctic");
                    newSWP.Climate = Console.ReadLine();
                    Console.WriteLine("Please enter the graviational constant. If unknown, please type 0");
                    newSWP.Gravity = Console.ReadLine();
                    Console.WriteLine("Now enter in Terrain information, in order to correctly submit multiple entries, please key as comma seperated values without spaces- I.E. -mountains,seas,grasslands,deserts");
                    newSWP.Terrain = Console.ReadLine();
                    Console.WriteLine("Please enter in the percentage of the planet covered in water represented as an integer, if unknown, please type 0");
                ReadWater: if (Int32.TryParse(Console.ReadLine(), out int Water))
                    {
                        newSWP.Surface_water = Water;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid selection");
                        goto ReadWater;
                    }
                    Console.WriteLine("Please key the population as a whole number. If unknown, please put 0.");
                ReadPopulation: if (Int32.TryParse(Console.ReadLine(), out int Population))
                    {
                        newSWP.Population = Population;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid selection");
                        goto ReadPopulation;
                    }

                    Console.WriteLine($"Confirm you would like to add {newSWP.Name} as a planet. Key Y to confirm, Key anything else to cancel and return to the main menu");
                    if (Confirmations.Confirm()) //calls the confirmation method to check to see if user confirms.
                    {
                        var newPlanet = String.Join(",", newSWP.Name, newSWP.Rotation_period, newSWP.Orbital_period, newSWP.Diameter, $"\"{newSWP.Climate}\"", newSWP.Gravity, $"\"{newSWP.Terrain}\"", newSWP.Surface_water, newSWP.Population); //Joins the objects attributes. Adds double quotations to fields that could have additional commas.
                        using (StreamWriter sww = new StreamWriter(fs))
                        {
                            sww.WriteLine($"{newPlanet}"); //appends string to the end of the csv.
                        }
                    }
                    else
                    {
                        MainMenu.DisplayMainMenu();
                    }
                    Console.Clear();
                    Console.WriteLine($"{newSWP.Name} has been created.");
                }
            }
            MainMenu.DisplayMainMenu();
        }

    }
}
