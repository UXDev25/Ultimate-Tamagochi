using System;
using Ultimate_Tamagochi.Model.Enums;
using Ultimate_Tamagochi.Models;
using Ultimate_Tamagochi.UI;

namespace tamagochi 
{
    public static class Program
    {
        public static void Main()
        {
            
        }
        public static void Draw(Pet pet) 
        {
            Console.Write(UIConfig.AsciiDrawings.Header, pet.BirthDate, pet.GetType().Name);
            Console.WriteLine();
            Console.Write(UIConfig.AsciiDrawings.Tamagochi, GetPetArt(pet));
            Console.WriteLine();
            Console.WriteLine(UIConfig.InGameUIElements.Name, pet.Name);
            Console.WriteLine(UIConfig.InGameUIElements.EmotionalState, pet.State);
            Console.WriteLine();
            Console.WriteLine(UIConfig.InGameUIElements.HungerStat, DrawBar(pet));
        }
        public static string DrawBar(Pet pet) 
        {
            return "aa";
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
