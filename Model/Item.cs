using System;
using System.Collections.Generic;
using System.Text;

namespace Ultimate_Tamagochi.Model
{
    public abstract class Item
    {
        public string Name { get; set; }
        protected float SpawnChance { get; set; }
        public bool IsConsumible { get; set; }

    }
}
