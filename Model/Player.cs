using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Model;
using Ultimate_Tamagochi.Model.Enums;
using Ultimate_Tamagochi.Model.Items;
using Ultimate_Tamagochi.UI;

namespace Ultimate_Tamagochi.Models
{
    public class Player
    {
        public Pet OwnPet { get; set; }
        public Inventory Inventory { get; set; }

        public Player(Pet pet)
        {
            OwnPet = pet;
            Inventory = new Inventory(new Item[0]);
        }

        public void AddToInventory(Item item) 
        {
            //Double check
            if (Inventory.Storage.Length == UIConfig.Prompt._maxInventorySize) 
            {
                Console.Clear();
                Console.WriteLine(UIConfig.Messages.MaxItems);
                return;
            }
            Item[] auxInv = new Item[Inventory.Storage.Length + 1];
            if (Inventory.Storage.Length == 0)
            {
                Inventory.Storage = auxInv;
                Inventory.Storage[0] = item;
                return;
            }
            for (int i = 0; i < Inventory.Storage.Length; i++)
            {
                auxInv[i] = Inventory.Storage[i];
            }
            Inventory.Storage = auxInv;
            Inventory.Storage[Inventory.Storage.Length - 1] = item;
        }

        public void DeleteFromInventory(Item item)
        {
            bool hasFoundItem = false;
            for (int i = 0; i < Inventory.Storage.Length; i++)
            {
                if (Inventory.Storage[i] == item)
                {
                    if (Inventory.Storage.Length == 1)
                    {
                        Inventory.Storage = [];
                        return;
                    }
                    Item[] auxInv = new Item[Inventory.Storage.Length - 1];
                    for (int j = 0; j < Inventory.Storage.Length; j++)
                    {
                        if (Inventory.Storage[j] != item && !hasFoundItem)
                        {
                            if (j == Inventory.Storage.Length - 1) auxInv[j - 1] = Inventory.Storage[j];
                            else auxInv[j] = Inventory.Storage[j];
                        }
                        else if (!hasFoundItem)
                        {
                            hasFoundItem = true;
                            j++;
                        }

                        if (hasFoundItem)
                        {
                            if (j >= Inventory.Storage.Length) auxInv[auxInv.Length - 1] = Inventory.Storage[auxInv.Length - 2];
                            else auxInv[j - 1] = Inventory.Storage[j];
                        }

                    }
                    Inventory.Storage = auxInv;
                    return;
                }
            }
            Console.WriteLine(UIConfig.Messages.ItemNotFound, item);
        }

        public void UseItem(Item item) 
        {
            Console.WriteLine(UIConfig.Messages.ItemUsed, item.Name);
            OwnPet.HandleItemEffect(item);
            if (OwnPet.IsAlive) if (item.IsConsumible) DeleteFromInventory(item);
            
        } 
    }
}
