using System;
using Ultimate_Tamagochi.Model;
using Ultimate_Tamagochi.Model.Enums;
using Ultimate_Tamagochi.Model.Items;
using Ultimate_Tamagochi.Models;
using Ultimate_Tamagochi.Models.Pets;
using Ultimate_Tamagochi.UI;
using Utils;

namespace tamagochi 
{
    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int responseType = 0;
            string petName = "";

            Toy ball = new Toy("Ball", 100, false, 20);
            Food hamburger = new Food("Hamburger", 100, false, (TypeFood)1);
            Special knife = new Special("Knife", 100, false, (EffectItem)0);


            //------MAIN PROGRAM-----
            Console.WriteLine(UIConfig.Messages.WelcomeMsg);
            Console.WriteLine(UIConfig.Messages.Pet);
            Console.WriteLine(UIConfig.Messages.PetList);
            Tools.CheckInt(ref responseType, UIConfig.Prompt._minPetOptions, UIConfig.Prompt._maxPetOptions, UIConfig.Messages.ErrorPetList);
            Console.Clear();
            Console.WriteLine(UIConfig.Messages.NameAsk, UIConfig.Prompt._defMaxNameChar);
            Tools.CheckName(ref petName, UIConfig.Prompt._defMaxNameChar, UIConfig.Messages.ErrorName);
            SelectPet(responseType, petName);
            Player player = new(SelectPet(responseType, petName));
            Console.Clear();

            //--START
            Draw(player.OwnPet);
        }

        //FUNCTIONALITY
        private static Pet SelectPet( int response, string name) 
        {
            switch (response) 
            {
                case 1: return new Cat(name, new Stats());
                case 2: return new Dog(name, new Stats());
                case 3: return new Chick(name, new Stats());
                default: return new Cat(name, new Stats());
            }
        }

        //UI MANAGEMENT
        private static void Draw(Pet pet) 
        {
            Console.Write(UIConfig.AsciiDrawings.Header, pet.BirthDate, pet.GetType().Name);
            Console.WriteLine();
            Console.Write(UIConfig.AsciiDrawings.Tamagochi, GetPetArt(pet));
            Console.WriteLine();
            Console.WriteLine(UIConfig.InGameUIElements.Name, pet.Name);
            Console.WriteLine(UIConfig.InGameUIElements.EmotionalState, pet.State);
            Console.WriteLine();
            Console.WriteLine(UIConfig.InGameUIElements.HungerStat, DrawBar(pet.Stats.Hunger),ConsoleColor.Magenta);
            Console.WriteLine(UIConfig.InGameUIElements.EnergyStat, DrawBar(pet.Stats.Energy), ConsoleColor.Yellow);
            Console.WriteLine(UIConfig.InGameUIElements.HealthStat, DrawBar(pet.Stats.Health), ConsoleColor.Green);
            Console.ResetColor();
        }
        public static string DrawBar(int stat) 
        {
            char[] defaultBar = UIConfig.InGameUIElements.BarOGMold.ToCharArray();
            int unPercentage = (stat * 20) / 100;
            for (int i = 0; i < unPercentage; i++) 
            {
                defaultBar[i] = '#';
            }
            string finalBar = new string(defaultBar);
            return string.Format(UIConfig.InGameUIElements.BarMold, finalBar, stat);
        }
        public static string GetPetArt(Pet pet)
        {
            switch (pet.State) 
            {
                default: return "^‿^";
                case (StatePet)1: return "╥﹏╥";
                case (StatePet)2: return "ಠ_ಠ";
                case (StatePet)3: return "-_- zZ";
                case (StatePet)4: return "x_x";
                case (StatePet)5: return "XoX";
            }
        }
    }
}
