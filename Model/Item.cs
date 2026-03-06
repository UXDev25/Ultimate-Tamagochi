using System;
using System.Collections.Generic;
using System.Text;

namespace Ultimate_Tamagochi.Model
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int SpawnChance { get; set; }
        public bool IsConsumible { get; set; }

    }
}
