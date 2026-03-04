using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Models;
using Ultimate_Tamagochi.UI;

namespace Ultimate_Tamagochi.Model
{
    public class Inventory
    {
        public Item[] Storage { get; set; }

        public Inventory(Item[] storage)
        {
            Storage = storage;
        }

        public void ShowInventory() 
        {
            if (Storage.Length == 0) return;
            for (int i = 0; i < Storage.Length; i++) 
            {
                Console.WriteLine($"{i + 1} - {Storage[i].Name}");
            }
            Console.WriteLine($"{Storage.Length + 1} - {UIConfig.InGameUIElements.ExitOption}");
        }
    }
}
