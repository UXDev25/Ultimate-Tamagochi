using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Model;
using Ultimate_Tamagochi.Model.Enums;
using Ultimate_Tamagochi.Models;

namespace Ultimate_Tamagochi.UI
{
    public static class UIConfig
    {
        public static class Prompt
        {
            public const StatePet _defPetState = (StatePet)0;
            public const bool _defPetAlive = true;
            public const int _defMaxStat = 100;
        }

        public static class Pets
        {
            public const string Pet1 = "Cat";
            public const string Pet2 = "Dog";
            public const string Pet3 = "Chick";
        }

        public static class AsciiDrawings 
        {
            public const string Header = "╔════════════════════════════════╗\r\n" +
                "║          TAMAGOTCHI            ║\r\n" +
                "║    DateOfBirth: {0}     ║\r\n" +
                "║       Type: {1}                ║\r\n" +
                "╚════════════════════════════════╝";
            public const string Tamagochi = "      /\\_/\\      \r\n" +
                "     ( {0} )     \r\n" +
                "     /       \\    \r\n" +
                "    |         |   \r\n" +
                "     \\__/\\___/    ";
            //Faces
        }

        public static class InGameUIElements 
        {
            public const string Name = "Name: {0}";
            public const string EmotionalState = "Emotional State: {0}";
            public const string HungerStat = "Hunger: {0}";
            public const string EnergyStat = "Energy: {0}";
            public const string HealthStat = "Health: {0}";
            public const string BarMold = "[{0}] {1}%";
            public const string BarOGMold = "--------------------";

            public const string Divider = "-----------------------------";
            public const string Optons = "1 - Eat\n2 - Sleep\n3 - Play\n4 - Play\n5 - Exit";
        }

        public static class Messages
        {
            //General
            public const string WelcomeMsg = "------------WELCOME TO ULTIMATE TAMAGOCHI------------";
            public const string Pet = "Congratulations! You are the owner of a new pet! What kind of pet do you want? (NUMBER: 1 TO 3)";
            public const string PetList = $"- 1:{Pets.Pet1}\n-- 2:{Pets.Pet1}\n- 3:{Pets.Pet3}";
            public const string ErrorPetList = "Insert a pet from the list please";
            public const string NameAsk = "Great! What is their name? (LIMIT: 12 CHARACTERS)";
            public const string ErrorName = "Invalid name, please try again (remember the limit of characters is 12)";

            //Player/Inventory
            public const string ItemNotFound = "{0} not found on your inventory";
            public const string ItemErased = "erased {0}";
        }
    }
}
