using System;
using System.Collections.Generic;
using System.Text;
using Tamagochi;
using Ultimate_Tamagochi.Model;
using Ultimate_Tamagochi.Model.Interfaces;
using Ultimate_Tamagochi.Models;
using Ultimate_Tamagochi.Models.Pets;
using Ultimate_Tamagochi.UI;

namespace Ultimate_Tamagochi.Core.Functionality
{
    internal class SelectionManager
    {
        public static Pet SelectPet(int response, string name)
        {
            switch (response)
            {
                case 1: return new Cat(name, new Stats());
                case 2: return new Dog(name, new Stats());
                case 3: return new Chick(name, new Stats());
                default: return new Cat(name, new Stats());
            }
        }

        public static void SelectOption(int option, Player player, Item[] foodArray, Item[] toyArray, Item[] specialArray)
        {
            int responseItem = 0;
            switch (option)
            {
                case 1:
                    if (player.OwnPet is IEat eatPet)
                    {
                        if (IsEmptyOrExitOption(player.Inventory.Storage, ref responseItem, player)) return;
                        CheckManager.CheckFood(player.Inventory.Storage[responseItem - 1], eatPet);
                    }
                    else Console.WriteLine(UIConfig.Messages.ErrorOption);
                    break;
                case 2:
                    if (player.OwnPet is ISleep sleepPet)
                    {
                        Console.Clear();
                        sleepPet.ISleep();
                    }
                    else Console.WriteLine(UIConfig.Messages.ErrorOption);
                    break;
                case 3:
                    if (player.OwnPet is IPlay playPet)
                    {
                        if (IsEmptyOrExitOption(player.Inventory.Storage, ref responseItem, player)) return;
                        CheckManager.CheckToy(player.Inventory.Storage[responseItem - 1], playPet);
                    }
                    else Console.WriteLine(UIConfig.Messages.ErrorOption);
                    break;
                case 4:
                    if (IsEmptyOrExitOption(player.Inventory.Storage, ref responseItem, player)) return;
                    Console.Clear();
                    player.UseItem(player.Inventory.Storage[responseItem - 1]);
                    break;
                case 5:
                    Console.Clear();
                    if (player.Inventory.Storage.Length >= UIConfig.Prompt._maxInventorySize) 
                    {
                        Console.Clear();
                        Console.WriteLine(UIConfig.Messages.MaxItems);
                        return;
                    }
                    player.AddToInventory(ItemManager.RandomizeItem(foodArray, toyArray, specialArray));
                    Console.WriteLine(UIConfig.Messages.ItemFound, player.Inventory.Storage[player.Inventory.Storage.Length - 1].Name);
                    break;
                case 6:
                    if (IsEmptyOrExitOption(player.Inventory.Storage, ref responseItem, player)) return;
                    Console.Clear();
                    player.DeleteFromInventory(player.Inventory.Storage[responseItem - 1]);
                    break;
                case 7:
                    Console.WriteLine(UIConfig.Messages.Close);
                    break;
            }
        }

        private static bool IsEmptyOrExitOption(Item[] storage, ref int responseItem, Player player) 
        {
            if (CheckManager.IsInventoryEmpty(player.Inventory.Storage)) return true;
            if (CheckManager.IsExitOption(ref responseItem, player))
            {
                Console.Clear();
                return true;
            }
            return false;
        } 
    }
}
