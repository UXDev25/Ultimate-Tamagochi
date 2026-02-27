using System;
using System.Collections.Generic;
using System.Text;

namespace Ultimate_Tamagochi.Model
{
    public abstract class Item
    {
        protected string Name { get; set; }
        protected float SpawnChance { get; set; }
        protected bool IsConsumible { get; set; }


    }
}
