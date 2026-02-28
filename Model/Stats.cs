using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.UI;

namespace Ultimate_Tamagochi.Models
{
    public class Stats
    {
        public int Hunger { get; set; }
        public int Energy { get; set; }
        public int Health
        {
            get => (Energy + Hunger) / 2;
        }
        public Stats(int hunger, int energy) 
        {
            Hunger = hunger;
            Energy = energy;
        }

        public Stats() : this(UIConfig.Prompt._defMaxStat, UIConfig.Prompt._defMaxStat) { }
    }
}
