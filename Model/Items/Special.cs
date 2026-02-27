using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Model.Enums;

namespace Ultimate_Tamagochi.Model.Items
{
    public class Special : Item
    {
        public EffectItem Effect { get; set; }
        public Special(string name, float spawnChance, bool isConsumible, EffectItem effect)
        {
            Name = name;
            SpawnChance = spawnChance;
            IsConsumible = isConsumible;
            Effect = effect;
        }
    }
}
