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
            ListPlanets(sw); // calls the list sw planets to display names and numbers of planets.
            var selectionDeleteParse = SelectSWPlanetsEdit(sw);
            var storedNameforConfirmation = sw[selectionDeleteParse].Name;
            if (Confirmations.Confirm()) //calls the confirmation method to check to see if user confirms.
            {
                ReWriteSWPlanets(fileName, sw, selectionDeleteParse);
            }
            else
            {
                Console.Clear();
                MainMenu.DisplayMainMenu();
            }
            Console.Clear();
            Console.WriteLine($"{storedNameforConfirmation} has been deleted.");
            MainMenu.DisplayMainMenu();
        }
        public static void AlterSWPlanets(string fileName, List<SWPlanets> sw)
        {
            ListPlanets(sw); // calls the list sw planets to display names and numbers of planets.
            var selectionEditParse = SelectSWPlanetsEdit(sw);
            var storedNameforConfirmation = sw[selectionEditParse].Name;;
            if (Confirmations.Confirm()) //calls the confirmation method to check to see if user confirms.
            {
                ReWriteSWPlanets(fileName, sw, selectionEditParse);
                WriteDocument.WriteSWPlanets(fileName, sw); //Calls the WriteSWPlanet Method to add back the selected planets with the new info.
            }
            else
            {
                Console.Clear();
                MainMenu.DisplayMainMenu();
            }
            Console.Clear();
            Console.WriteLine($"{storedNameforConfirmation} has been edited.");
            MainMenu.DisplayMainMenu();
        }

        public static void ReWriteSWPlanets(string fileName, List<SWPlanets> sw, int selectionParse) //rewrites all planets except the one being edited or deleted.
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
        public static int SelectSWPlanetsEdit(List<SWPlanets> sw) //avoids duplicating code used by both edit and delete. Gets a number for both, and returns that to the method,
        {
            Console.WriteLine("Please type corresponding number to the planet you would like to edit/delete");
            var selectionEdit = Console.ReadLine();
            var success = Int32.TryParse(selectionEdit, out int selectionEditParse); //try parse to convert to int.
            Console.WriteLine($"Confirm you would like to edit/delete {sw[selectionEditParse].Name} as a planet. Key Y to confirm, key anything else to cancel and return to the main menu");
            return selectionEditParse;

        }

        public static void ListPlanets(List<SWPlanets> sw)
        {
            var counter = 0;
            foreach (var p in sw)
            {
                Console.WriteLine($"{sw[counter].Number}:{sw[counter].Name}"); //lists the planets so they can select a planet to edit.
                counter++;
            }
        }
    }
}

