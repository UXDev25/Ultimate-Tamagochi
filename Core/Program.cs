using System;
using System.Numerics;
using Ultimate_Tamagochi.Core.Functionality;
using Ultimate_Tamagochi.Model;
using Ultimate_Tamagochi.Model.Enums;
using Ultimate_Tamagochi.Model.Items;
using Ultimate_Tamagochi.Models;
using Ultimate_Tamagochi.UI;
using Utils;

namespace Tamagochi 
{
    internal static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int responseType = 0;
            string petName = "";
            int option = 0;
            Item[] allObjectList = Array.Empty<Item>();

            ItemManager.InstantiateAllObjects();

            //------MAIN PROGRAM-----
            Console.WriteLine(UIConfig.Messages.WelcomeMsg);
            Console.WriteLine(UIConfig.Messages.Pet);
            Console.WriteLine(UIConfig.Messages.PetList);
            Tools.CheckInt(ref responseType, UIConfig.Prompt._minPetOptions, UIConfig.Prompt._maxPetOptions, UIConfig.Messages.ErrorPetList);
            Console.Clear();
            Console.WriteLine(UIConfig.Messages.NameAsk, UIConfig.Prompt.MaxNameChar);
            Tools.CheckName(ref petName, UIConfig.Prompt.MaxNameChar, UIConfig.Messages.ErrorName);
            SelectionManager.SelectPet(responseType, petName);
            Player player = new(SelectionManager.SelectPet(responseType, petName));
            Console.Clear();
            //--START
            do
            {
                UIManager.Draw(player.OwnPet);
                Console.WriteLine(UIConfig.InGameUIElements.OptionAsk);
                Console.WriteLine(UIConfig.InGameUIElements.Options);
                Console.WriteLine();
                Tools.CheckInt(ref option, UIConfig.Prompt.MinOption, UIConfig.Prompt.MaxOption, UIConfig.Messages.ErrorOption);
                Console.Clear();
                SelectionManager.SelectOption(option, player);
                player.OwnPet.UpdatePetState();
            } while (option != UIConfig.Prompt.MaxOption);
            
        }
    }
}
