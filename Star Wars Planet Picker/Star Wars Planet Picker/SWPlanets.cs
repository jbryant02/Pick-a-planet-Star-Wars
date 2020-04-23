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
        private int _lowPopulation = 10_000_000; //lower than 1,000,000
        private Int64 _medPopulation = 3_000_000_000; // between 1,000,000 and 300,000,0000
        private int _lowSurfaceWater = 30;
        private int _medSurfaceWater = 60;


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
        public int LowPopulation { get => _lowPopulation; private set => _lowPopulation = value; } //private set prevents change to numbers.
        public Int64 MedPopulation { get => _medPopulation; private set => _medPopulation = value; } //private set prevents change to numbers.
        public int LowSurfaceWater { get => _lowSurfaceWater; private set => _lowSurfaceWater = value; }
        public int MedSurfaceWater { get => _medSurfaceWater; private set => _medSurfaceWater = value; }
    }
}
