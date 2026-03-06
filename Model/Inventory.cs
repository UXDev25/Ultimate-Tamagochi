using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Models;

namespace Ultimate_Tamagochi.Model
{
    public class Inventory
    {
        public Item[] Storage { get; set; }

        public Inventory(Item[] storage)
        {
            Storage = storage;
        }
    }
}
