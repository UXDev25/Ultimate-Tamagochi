using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Model;
using Ultimate_Tamagochi.Model.Enums;
using Ultimate_Tamagochi.Model.Items;
using Ultimate_Tamagochi.UI;

namespace Tamagochi
{
    public class ItemManager
    {

        //INSTANTIATIONS PRE-PROGRAM
        public static void InstantiateAllObjects(ref Item[] foodItems, ref Item[] toyItems, ref Item[] specialItems)
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
            Food rokakaka = new("Rokakaka", 2, true, (TypeFood)2);

            //TOYS
            Toy ball = new("Ball", 40, false, 20);
            Toy car = new("Car", 30, false, 50);
            Toy balloon = new("Balloon", 15, true, 80);
            Toy toyota = new("Toyota Corola", 12, true, 90);
            Toy albion = new("Albion online", 3, false, 100);


            //SPECIALS
            Special rock = new("Rock", 30, false, (EffectItem)2); 
            Special music = new("Music", 21, true, (EffectItem)6); 
            Special sadMovie = new("Sad movie", 17, true, (EffectItem)5); 
            Special survivor = new("Survivor", 15, true, (EffectItem)4); 
            Special maxiTomato = new("Maxitomato", 10, true, (EffectItem)3); 
            Special knife = new("Knife", 4, false, (EffectItem)0); 
            Special jesusPee = new("Jesus's piss", 2, true, (EffectItem)1); 
            Special drStone = new("Dr.Stone", 1, false, (EffectItem)1);


            //ORDERED BY SPAWN PERCENTAGE, LESS TO MORE (IMPORTANT)
            //- the total of all the percentages from the items of each array are UIConfig.Prompt._maxPercentage, if the number is lesser or greater, it will not work.
            foodItems = [rokakaka, fentanyl, mrClean, AkumaNoMi, pizza, hamburger, treat, magicPlant, rottenFlesh, animal_feed]; 
            toyItems = [albion, toyota, balloon, car, ball]; 
            specialItems = [drStone, jesusPee, knife, maxiTomato, survivor, sadMovie, music, rock];
        }

        // -----ITEM RANDOMIZATION-----
        public static Item RandomizeItem(Item[] foodItems, Item[] toyItems, Item[] specialItems) 
        {
            if (!IsArrayComplete(foodItems) || !IsArrayComplete(toyItems) || !IsArrayComplete(specialItems)) throw new Exception(UIConfig.Exceptions.PercentageException);
            var rand = new Random();
            Item[] selectedArray = SelectRandomItemArray(foodItems, toyItems, specialItems);
            int rolledNumber = rand.Next(UIConfig.Prompt._minPercentage, UIConfig.Prompt._maxPercentage);
            return SearchForItem(selectedArray, rolledNumber);
        }

        private static Item SearchForItem(Item[] selectedArray, int rolledNumber) 
        {
            for (int i = 0; i < selectedArray.Length; i++) 
            {
                if (rolledNumber <= CalculateCumulativeProbability(selectedArray, i)) return selectedArray[i];
            }
            throw new Exception("Error, item not found");
        }

        private static int CalculateCumulativeProbability(Item[] itemArray, int itemNumber) 
        {
            int cumulativeSum = 0;
            if (itemNumber == 0) return itemArray[itemNumber].SpawnChance;
            for (int i = 0; i <= itemNumber; i++) 
            {
                cumulativeSum += itemArray[i].SpawnChance;
            }
            return cumulativeSum;
        }

        private static Item[] SelectRandomItemArray(Item[] foodItems, Item[] toyItems, Item[] specialItems) 
        {
            var rand = new Random();
            int rolledNumber = rand.Next(UIConfig.Prompt._minCategoryNum, UIConfig.Prompt._categoryNum); //Be sure to insert into UIConfig.Prompt._categoryNum the same number of itemArrays that you inputed as parameters
            switch (rolledNumber) 
            {
                case 1: return foodItems;
                case 2: return toyItems;
                case 3: return specialItems;
                default: throw new Exception(UIConfig.Exceptions.ItemArrayNumException);
            }
        }

        public static bool IsArrayComplete(Item[] itemArray) 
        {
            int percentageSum = 0;
            for (int i = 0; i < itemArray.Length; i++) 
            {
                percentageSum = percentageSum + itemArray[i].SpawnChance;
            }
            if (percentageSum == UIConfig.Prompt._maxPercentage) return true;
            return false;
        }

        
        //UNUSED
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
