using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Model;
using Ultimate_Tamagochi.Model.Enums;
using Ultimate_Tamagochi.Model.Items;
using Ultimate_Tamagochi.UI;

namespace Ultimate_Tamagochi.Models
{
    public abstract class Pet
    {
        public string Name { get; set; }
        public StatePet State { get; set; }
        public bool IsAlive { get; set; }
        public Stats Stats { get; set; }
        public DateOnly BirthDate => DateOnly.FromDateTime(DateTime.Now);

        
        //------STATE HANDLING------
        public void UpdatePetState() 
        {
            if (Stats.Health <= 20 || Stats.NutritionalState <= 0)
            {
                if (Stats.Health == 0) 
                {
                    State = (StatePet)5;
                    IsAlive = false;
                    return;
                }
                State = (StatePet)4;
                Console.WriteLine(UIConfig.Messages.Sick, Name);
                return;
            }
            if (Stats.Energy <= 30)
            {
                State = (StatePet)3;
                Console.WriteLine(UIConfig.Messages.Tired, Name);
                return;
            }
            if (Stats.Hunger <= 50)
            {
                State = (StatePet)2;
                Console.WriteLine(UIConfig.Messages.Angry, Name);
            }
        }

        protected bool WillAttendPlayer(StatePet state)
        {
            var rand = new Random();
            bool finalVal;
            switch (state)
            {
                case (StatePet)0:
                    return true;
                case (StatePet)1:
                    finalVal = rand.Next(UIConfig.Prompt._minPercentage, UIConfig.Prompt._maxPercentage) >= UIConfig.Values.notPlayChance;
                    if (!finalVal) Console.WriteLine(UIConfig.Messages.NoPlay);
                    return finalVal;
                case (StatePet)2:
                    finalVal = rand.Next(UIConfig.Prompt._minPercentage, UIConfig.Prompt._maxPercentage) >= UIConfig.Values.ignoreChance;
                    if (!finalVal) Console.WriteLine(UIConfig.Messages.NoResponse);
                    return finalVal;
                case (StatePet)3:
                    finalVal = rand.Next(UIConfig.Prompt._minPercentage, UIConfig.Prompt._maxPercentage) >= UIConfig.Values.sudSleepChance;
                    if (!finalVal) Console.WriteLine(UIConfig.Messages.SudSlept);
                    return finalVal;
                default: return false;
            }

        }

        //-------Maybe ill make all this functions in a new class...

        //------ITEM HANDLING-------
        public void HandleItemEffect(Item item)
        {
            switch (item)
            {
                case Food foodItem:
                    HandleFoodEffects(foodItem);
                    break;
                case Toy toyItem:
                    HandleToyEffects(toyItem);
                    break;
                case Special specialItem:
                    HandleSpecialEffects(specialItem);
                    break;
                default:
                    Console.WriteLine(UIConfig.Messages.NothingHappened);
                    break;
            }
        }

        //Food
        private void HandleFoodEffects(Food food) 
        {
            switch (food.TypeOfFood) 
            {
                case (TypeFood)0:
                    Console.WriteLine(UIConfig.Messages.Meal, Name);
                    HandleMealStatChanges();
                    break;
                case (TypeFood)1:
                    Console.WriteLine(UIConfig.Messages.Snack, Name);
                    HandleSnackStatChanges();
                    break;
                case (TypeFood)2:
                    Console.WriteLine(UIConfig.Messages.Poison, Name);
                    HandleDeathStatChanges();
                    break;
            }
        }

        private void HandleMealStatChanges() 
        {
            Stats.Hunger = Stats.Hunger + UIConfig.Values.MealHungerValue;
            State = (int)State < 3 ? (StatePet)((int)State + 1) : (StatePet)2;
            Stats.NutritionalState = Stats.NutritionalState + 1;
        }
        private void HandleSnackStatChanges()
        {
            Stats.Hunger = Stats.Hunger + UIConfig.Values.SnackHungerValue;
            State = (StatePet)0;
            Stats.NutritionalState = Stats.NutritionalState - 1;
        }
        private void HandleDeathStatChanges()
        {
            Stats.SetMinStats();
            State = (StatePet)5;
            IsAlive = false;
        }

        //Toys
        private void HandleToyEffects(Toy toy)
        {
            Console.WriteLine(UIConfig.Messages.Played, Name);
            Stats.Energy = Stats.Energy - toy.Epicness;
            Stats.Hunger = Stats.Hunger - toy.Epicness;
        }

        //Special
        private void HandleSpecialEffects(Special special)
        {
            switch (special.Effect)
            {
                case (EffectItem)0:
                    Console.WriteLine(UIConfig.Messages.Kill, special.Name, Name);
                    HandleDeathStatChanges();
                    break;
                case (EffectItem)1:
                    Console.WriteLine(UIConfig.Messages.Revive, Name);
                    HandleRevival(special);
                    break;
                case (EffectItem)2:
                    Console.WriteLine(UIConfig.Messages.NothingHappened, Name);
                    break;
                case (EffectItem)3:
                    Console.WriteLine(UIConfig.Messages.FillStats, Name);
                    Stats.SetMaxStats();
                    break;
                case (EffectItem)4:
                    Console.WriteLine(UIConfig.Messages.SetAngry, Name);
                    State = (StatePet)2;
                    break;
                case (EffectItem)5:
                    Console.WriteLine(UIConfig.Messages.SetSad, Name);
                    State = (StatePet)1;
                    break;
                case (EffectItem)6:
                    Console.WriteLine(UIConfig.Messages.SetHappy, Name);
                    State = (StatePet)0;
                    break;
            }
        }

        private void HandleRevival(Special special) 
        {
            IsAlive = true;
            State = (StatePet)0;
            Stats.SetMaxStats();
        }

        //Sleep
        protected void SleepStatChanges() 
        {
            Stats.Hunger = Stats.Hunger - UIConfig.Values.SlHungerDecrease;
            Stats.Energy = Stats.Energy + UIConfig.Values.SlEnergyIncrease;
        }
    }
}
