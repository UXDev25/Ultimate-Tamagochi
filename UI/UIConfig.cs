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
            //UI
            public const int MaxNameChar = 12;
            public const int MinOption = 1;
            public const int MaxOption = 6; // it is made for the last option to be the EXIT option.
            public const int _maxPetOptions = 3;
            public const int _minPetOptions = 1;

            //Pet
            public const StatePet _defPetState = (StatePet)0;
            public const bool _defPetAlive = true;
            
            //Stats
            public const int _defMaxStat = 100;
            public const int _defMinStat = 0;
            public const int _defMaxNutr = 3;
            public const int _defMinNutr = -5;

            //Random
            public const int _maxPercentage = 100;
            public const int _minPercentage = 0;
            public const int _minCategoryNum = 1;
            public const int _categoryNum = 3;
        }

        public static class Values
        {
            public const int MealHungerValue = 50;
            public const int SnackHungerValue = 20;
            public const int SlEnergyIncrease = 60;
            public const int SlHungerDecrease = 40;

            //Random
            public const int ignoreChance = 50;
            public const int notPlayChance = 50;
            public const int sudSleepChance = 70;
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
            public const string OptionAsk = "What would you like to do?";
            public const string Options = $"1 - Feed\n2 - Sleep\n3 - Play\n4 - Use item\n5 - Search for items\n6 - {ExitOption}";
            public const string ExitOption = "Exit";
        }

        public static class Messages
        {
            //General
            public const string WelcomeMsg = "------------WELCOME TO ULTIMATE TAMAGOCHI------------";
            public const string Pet = "Congratulations! You are the owner of a new pet! What kind of pet do you want? (NUMBER: 1 TO 3)";
            public const string PetList = $"- 1:{Pets.Pet1}\n- 2:{Pets.Pet2}\n- 3:{Pets.Pet3}";
            public const string ErrorPetList = "Insert a pet from the list please";
            public const string NameAsk = "Great! What is their name? (LIMIT: 12 CHARACTERS)";
            public const string ErrorName = "Invalid name, please try again (remember the limit of characters is {0})";
            public const string ErrorOption = "Invalid option, please select one number from the list";
            public const string Close = "Ok then, goodbye!";

            //Player/Inventory
            public const string ItemNotFound = "{0} not found on your inventory";
            public const string ItemErased = "erased {0}";
            public const string ItemUsed = "You used {0} on your pet";
            public const string EmptyInventory = "You have no items";
            public const string ItemFound = "You found a {0}!";

            //Pet

            //-----STATES
            public const string Sick = "{0} feels very sick... A medical intervention will be needed";
            public const string Tired = "{0} feels tired, let them rest a little bit...";
            public const string Angry = "{0} is so mad! Be careful...";
            public const string Sad = "{0} feels very sad, poor {0}...";

            public const string NoPlay = "{0} does not want to play...";
            public const string SudSlept = "What? {0} slept suddenly...";
            public const string NoResponse = "{0} doesn't care about your opinon";

            //-----ITEMS
            public const string WhichItem = "Which Item do you want to use?";

            public const string NothingHappened = "Nothing happened...";
            public const string Eat = "{0} ate a {1}, ";
            public const string Meal = "It was awful... but {0} seems healthier!";
            public const string Snack = "It was delicious! but {0}'s tummy is starting to ache...";
            public const string Poison = "{0} started to uncontrollably convulsionate, oh no...";

            public const string Use = "You used a {0} on {1}, ";
            public const string Kill = "the {0} was used coldly to kill {1}, you are a monster...";
            public const string DeleteInventory = "Oh no! suddenly {0} ran towards you and destroyed all your items!";
            public const string Revive = "This is a miracle! {0} is now alive again!";
            public const string FillStats = "Wow! {0} looks more energetic than ever!";
            public const string SetAngry = "Uh oh... {0} didn't like that";
            public const string SetSad = "Oh no, looks like {0} is very very sad...";
            public const string SetHappy = "Yeah! {0} liked a lot that, he is happier than ever!";

            //-----ACTIONS
            public const string Sleep = "{0} went to sleep... It waked up with a lot of energy! Maybe a little breakfast will do good on them...";
            public const string Play = "{0} Played with {1}, ";
            public const string Played = "it was very epic, {0} is so happy! But very tired...";
        }

        public class Exceptions 
        {
            public const string PercentageException = "Error, the sumatory of all the item percentages of each individual array has to be equal to 100";
            public const string ItemArrayNumException = "Error, you must assign to UIConfig.Prompt._categoryNum the same number of itemArrays categories that exist";
        }
    }
}
