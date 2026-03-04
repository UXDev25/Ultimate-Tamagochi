using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Model;
using Ultimate_Tamagochi.Model.Enums;
using Ultimate_Tamagochi.Model.Items;

namespace Tamagochi
{
    public class ItemManager
    {

        //INSTANTIATIONS PRE-PROGRAM
        public static void InstantiateAllObjects(Item[] foodItems, Item[] toyItems, Item[] specialItems)
        {
            //FOOD
            //----Meals
            Food animal_feed = new("Animal feed", 29, true, (TypeFood)0);
            Food rottenFlesh = new("Rotten flesh", 15, true, (TypeFood)0);
            Food magicPlant = new("Magic plant", 8, true, (TypeFood)0);

            //----Snacks
            Food treat = new("Treat", 23, true, (TypeFood)1);
            Food hamburger = new("Hamburger", 7, true, (TypeFood)1);
            Food pizza = new("Pizza", 5, true, (TypeFood)1);
            Food AkumaNoMi = new("Devil fruit", 2, true, (TypeFood)1);

            //----Poison
            Food mrClean = new("Mr Clean", 5, true, (TypeFood)2);
            Food fentanyl = new("Fentanyl", 4, true, (TypeFood)2);
            Food rokakaka = new("Rokakaka", 1, true, (TypeFood)2);

            //TOYS
            Toy ball = new("Ball", 40, false, 20);
            Toy car = new("Car", 30, false, 50);
            Toy balloon = new("Balloon", 10, true, 80);
            Toy toyota = new("Toyota Corola", 7, true, 90);
            Toy albion = new("Albion online", 3, false, 100);


            //SPECIALS
            Special rock = new("Rock", 70, false, (EffectItem)2);
            Special music = new("Music", 50, true, (EffectItem)6);
            Special sadMovie = new("Sad movie", 40, true, (EffectItem)5);
            Special survivor = new("Survivor", 35, true, (EffectItem)4);
            Special maxiTomato = new("Maxitomato", 25, true, (EffectItem)3);
            Special knife = new("Knife", 10, false, (EffectItem)0);
            Special jesusPee = new("Jesus's piss", 5, true, (EffectItem)1);
            Special drStone = new("Dr.Stone", 1, false, (EffectItem)1);

            foodItems = [animal_feed, rottenFlesh, magicPlant, treat, hamburger, pizza, AkumaNoMi, mrClean, fentanyl, rokakaka];
            toyItems = [ball, car, balloon, toyota, albion];
            specialItems = [rock, music, sadMovie, survivor, maxiTomato, knife, jesusPee, drStone];
        }

        public static Item[] AllObjectsArrayComposer(Item[] allItems, Item item) 
        {
            Item[] auxItems = new Item[allItems.Length + 1];
            if (allItems.Length == 0)
            {
                allItems = auxItems;
                allItems[0] = item;
                return allItems;
            }
            for (int i = 0; i < allItems.Length; i++)
            {
                auxItems[i] = allItems[i];
            }
            allItems = auxItems;
            allItems[allItems.Length] = item;
            return allItems;
        }
    }
}
