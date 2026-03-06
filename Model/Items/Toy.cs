using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Model.Enums;

namespace Ultimate_Tamagochi.Model.Items
{
    public class Toy : Item
    {
        public int Epicness { get; set; }
        public Toy(string name, float spawnChance, bool isConsumible, int epicness)
        {
            Name = name;
            SpawnChance = spawnChance;
            IsConsumible = isConsumible;
            Epicness = epicness;
        }
    }
}
