using System;
using System.Collections.Generic;
using System.Text;

namespace Ultimate_Tamagochi.Models
{
    public class Stats
    {
        public int Hunger { get; set; }
        public int Energy { get; set; }
        public int Health { get; set; }
        public Stats(int hunger, int energy, int health) 
        {
            Hunger = hunger;
            energy = energy;
            health = health;
        }
    }
}
