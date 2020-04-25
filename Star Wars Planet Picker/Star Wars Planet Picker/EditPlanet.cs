using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Star_Wars
{
    class EditPlanet
    {
        public static void DeleteSWPlanets(string fileName, List<SWPlanets> sw)
        {
            var counter = 0;
            foreach (var p in sw)
            {
                Console.WriteLine($"{sw[counter].Number}:{sw[counter].Name}"); //lists the planets so they can select deletion.
                counter++;
            }
            Console.WriteLine("Please type corresponding number to the planet you would like to remove");
            var selectionDelete = Console.ReadLine();
            var success = Int32.TryParse(selectionDelete, out int selectionDeleteParse); //try parse to convert to int.
            var storedNameforConfirmation = selectionDeleteParse;
            Console.WriteLine($"Confirm you would like to delete {sw[selectionDeleteParse].Name} as a planet. Key Y to confirm, key anything else to cancel and return to the main menu");
            string selectionConfirm = Console.ReadLine().ToUpper();
            if (selectionConfirm == "Y") //confirmation button to ensure deletion.
            {
                ReWriteSWPlanets(fileName, sw, selectionDeleteParse);
            }
            else
            {
                PlanetPicker.DisplayMainMenu();
            }
            Console.WriteLine($" {storedNameforConfirmation} has been deleted.");
            PlanetPicker.DisplayMainMenu();
        }
        public static void AlterSWPlanets(string fileName, List<SWPlanets> sw)
        {
            var counter = 0;
            foreach (var p in sw)
            {
                Console.WriteLine($"{sw[counter].Number}:{sw[counter].Name}"); //lists the planets so they can select a planet to edit.
                counter++;
            }
            Console.WriteLine("Please type corresponding number to the planet you would like to edit");
            var selectionEdit = Console.ReadLine();
            var success = Int32.TryParse(selectionEdit, out int selectionEditParse); //try parse to convert to int.
            var storedNameforConfirmation = selectionEditParse;
            Console.WriteLine($"Confirm you would like to edit {sw[selectionEditParse].Name} as a planet. Key Y to confirm, key anything else to cancel and return to the main menu");
            string selectionConfirm = Console.ReadLine().ToUpper();
            if (selectionConfirm == "Y") //confirmation button to ensure deletion.
            {

                ReWriteSWPlanets(fileName, sw, selectionEditParse);
                WriteDocument.WriteSWPlanets(fileName, sw); //Calls the WriteSWPlanet Method to add back the selected planets with the new info.
            }
            else
            {
                PlanetPicker.DisplayMainMenu();
            }
            Console.WriteLine($" {storedNameforConfirmation} has been edited.");
            PlanetPicker.DisplayMainMenu();
        }

        public static void ReWriteSWPlanets(string fileName, List<SWPlanets> sw, int selectionParse)
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                var i = 0;
                streamWriter.Write($"name,rotation_period,orbital_period,diameter,climate,gravity,terrain,surface_water,population \n"); //adds the first line of the csv back
                foreach (var p in sw)
                {
                    if (sw[i].Number != selectionParse) //checks to see if the number does not match the selected planet for deletion/edit. If it does, it does not readd this line.
                    {
                        var newPlanet = String.Join(",", sw[i].Name, sw[i].Rotation_period, sw[i].Orbital_period, sw[i].Diameter, $"\"{sw[i].Climate}\"", sw[i].Gravity, $"\"{sw[i].Terrain}\"", sw[i].Surface_water, sw[i].Population); //Adds each object of the each element back, wraps the ones that potentially have double quotes in commas with double quotes.
                        streamWriter.Write($"{newPlanet.ToString()} \n"); //writes the new line and attaches a new line at the end.
                    }
                    i++;
                }
            }
        }

    }
}

