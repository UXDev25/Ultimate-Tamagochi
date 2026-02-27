using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Model;
using Ultimate_Tamagochi.UI;

namespace Ultimate_Tamagochi.Models
{
    public class Player
    {
        public Pet OwnPet { get; set; }
        public Item[] Inventory { get; set; }

        public Player(Pet pet, Item[] inventory)
        {
            OwnPet = pet;
            Inventory = inventory;
        }

        public void AddToInventory(Item item) 
        { 
            Item[] auxInv = new Item[Inventory.Length + 1];
            for (int i = 0; i <= Inventory.Length; i++)
            {
                auxInv[i] = Inventory[i];
            }
            Inventory = auxInv;
            Inventory[Inventory.Length] = item;
        }

        public void DeleteFromInventory(Item item) 
        {
            bool hasFoundItem = false;
            for (int i = 0; i < Inventory.Length; i++) 
            {
                if (Inventory[i] == item) 
                {
                    if (Inventory.Length == 1) 
                    {
                        Inventory = [];
                        Console.WriteLine(UIConfig.Messages.ItemErased, item);
                        return;
                    }
                    Item[] auxInv = new Item[Inventory.Length - 1];
                    for (int j = 0; j < Inventory.Length; j++)
                    {
                        if (Inventory[j] != item && !hasFoundItem)
                        {
                            if (j == Inventory.Length - 1) auxInv[j - 1] = Inventory[j];
                            else auxInv[j] = Inventory[j];
                        }
                        else if (!hasFoundItem)
                        {
                            hasFoundItem = true;
                            j++;
                        }

                        if (hasFoundItem) 
                        {
                            if (j >= Inventory.Length) auxInv[auxInv.Length - 1] = Inventory[auxInv.Length - 2];
                            else auxInv[j - 1] = Inventory[j];
                        } 

                    }
                    Inventory = auxInv;
                    Console.WriteLine(UIConfig.Messages.ItemErased, item);
                    return;
                }
                Console.WriteLine(UIConfig.Messages.ItemNotFound, item);
                return;
            }
        }

        public void UseItem(Item item) 
        { 
        
        }
    }
}
