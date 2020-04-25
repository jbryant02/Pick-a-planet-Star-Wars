using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Wars
{
    public static class ReadDocument
    {
        public static List<SWPlanets> ReadSWPlanets(string fileName)
        {
            var sWarsPlanets = new List<SWPlanets>();
            using (CsvReader stream = new CsvReader(fileName)) //opens new CSV reader from the CSV reader class.
            {
                
                    var counter = 0;
                    foreach (string[] values in stream.RowEnumerator)  //starts a loop to read through each line. The first line is already read in the Csvreader class, through a line I keyed.
                    {
                        var starWarsPlanets = new SWPlanets(); //instantiates a SWPlanets class to be used to assigned values in the loop.
                        starWarsPlanets.Name = values[0];
                        if (values[1] != "NA") //Handles the "NA" values present in the database, exchanges them for zero to allow the resulting fields to be parsed into uniform type.
                        {
                            starWarsPlanets.Rotation_period = Int32.Parse(values[1]);
                        }
                        else
                        {
                            starWarsPlanets.Rotation_period = 0;
                        }
                        if (values[2] != "NA")
                        {
                            starWarsPlanets.Orbital_period = Int32.Parse(values[2]);
                        }
                        else
                        {
                            starWarsPlanets.Orbital_period = 0;
                        }
                        if (values[3] != "NA")
                        {
                            starWarsPlanets.Diameter = Int32.Parse(values[3]);
                        }
                        else
                        {
                            starWarsPlanets.Diameter = 0;
                        }
                        starWarsPlanets.Climate = values[4];
                        starWarsPlanets.Gravity = values[5];
                        starWarsPlanets.Terrain = values[6];
                        if (values[7] != "NA")
                        {
                            starWarsPlanets.Surface_water = Int32.Parse(values[7]);
                        }
                        else
                        {
                            starWarsPlanets.Surface_water = 0;
                        }
                        if (values[8] != "NA")
                        {
                            starWarsPlanets.Population = Int64.Parse(values[8]);
                        }
                        else
                        {
                            starWarsPlanets.Population = 0;
                        }
                        starWarsPlanets.Number = counter;
                        


                        sWarsPlanets.Add(starWarsPlanets);
                    counter++;
                }
            }
            return sWarsPlanets;
        }

    }
}
