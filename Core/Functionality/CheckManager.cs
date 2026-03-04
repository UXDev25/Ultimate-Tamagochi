using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Model;
using Ultimate_Tamagochi.Model.Interfaces;
using Ultimate_Tamagochi.Model.Items;
using Ultimate_Tamagochi.Models;
using Ultimate_Tamagochi.UI;
using Utils;

namespace Ultimate_Tamagochi.Core.Functionality
{
    public static class CheckManager
    {
        public static bool IsInventoryEmpty(Item[] storage)
        {
            if (storage.Length == 0)
            {
                Console.Clear();
                Console.WriteLine(UIConfig.Messages.EmptyInventory);
                return true;
            }
            return false;
        }

        public static bool IsExitOption(ref int responseItem, Player player)
        {
            player.Inventory.ShowInventory();
            Tools.CheckInt(ref responseItem, 1, player.Inventory.Storage.Length + 1, UIConfig.Messages.ErrorOption); // 1 represents the beggining of the array
            if (responseItem == player.Inventory.Storage.Length + 1) return true;
            return false;
        }

        public static void CheckFood(Item item, IEat eatPet)
        {
            if (item is Food foodItem)
            {
                Console.Clear();
                eatPet.IEat(foodItem);
                return;
            }
            Console.Clear();
            Console.WriteLine(UIConfig.Messages.ErrorOption);
        }

        public static void CheckToy(Item item, IPlay eatPet)
        {
            if (item is Toy toyItem)
            {
                Console.Clear();
                eatPet.IPlay(toyItem);
                return;
            }
            Console.Clear();
            Console.WriteLine(UIConfig.Messages.ErrorOption);
        }
    }
}
