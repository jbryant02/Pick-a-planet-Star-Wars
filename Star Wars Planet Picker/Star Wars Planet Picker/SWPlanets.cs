using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Wars
{
    public class SWPlanets
    {
        private string _name;
        private int _rotation_period;
        private int _orbital_period;
        private int _diameter;
        private string _climate;
        private string _gravity;
        private string _terrain;
        private int _surface_water;
        private Int64 _population;
        private int _score = 0;
        private int number;


        public string Name { get => _name; set => _name = value; }
        public int Rotation_period { get => _rotation_period; set => _rotation_period = value; }
        public int Orbital_period { get => _orbital_period; set => _orbital_period = value; }
        public int Diameter { get => _diameter; set => _diameter = value; }
        public string Climate { get => _climate; set => _climate = value; }
        public string Gravity { get => _gravity; set => _gravity = value; }
        public string Terrain { get => _terrain; set => _terrain = value; }
        public int Surface_water { get => _surface_water; set => _surface_water = value; }
        public Int64 Population { get => _population; set => _population = value; }
        public int Score { get => _score; set => _score = value; }
        public int Number { get => number; set => number = value; }
    }
}
