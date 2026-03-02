using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Model.Enums;

namespace Ultimate_Tamagochi.Model.Items
{
    public class Food : Item
    {
        public TypeFood TypeOfFood { get; set; }
        public Food(string name, float spawnChance, bool isConsumible, TypeFood type)
        {
            Name = name;
            SpawnChance = spawnChance;
            IsConsumible = isConsumible;
            TypeOfFood = type;
        }
    }
}
