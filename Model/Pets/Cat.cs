using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Model;
using Ultimate_Tamagochi.Model.Enums;
using Ultimate_Tamagochi.Model.Interfaces;
using Ultimate_Tamagochi.Model.Items;
using Ultimate_Tamagochi.UI;
namespace Ultimate_Tamagochi.Models.Pets
{
    public class Cat : Pet, IEat, IPlay, ISleep, IActions
    {

        public Cat(string name, StatePet state, bool isAlive, Stats stats) 
        {
            Name = name;
            State = state;
            IsAlive = isAlive;
            Stats = stats;
        }

        public Cat(string name, Stats stats) : this(name, UI.UIConfig.Prompt._defPetState, UI.UIConfig.Prompt._defPetAlive, stats) 
        {
            Name = name;
            Stats = stats;
        }

        public void Clean() 
        { 
        
        }



        //-----INTERFACES-----

        public virtual void Eat(Food food) 
        {
            if ((State == (StatePet)2 || State == (StatePet)3) && !WillAttendPlayer(State)) return;
            Console.WriteLine(UIConfig.Messages.Eat, Name, food.Name);
            HandleItemEffect(food);
        }
        public virtual void Play(Toy toy)
        {
            if (!WillAttendPlayer(State) || State == (StatePet)3) return;
            Console.WriteLine(UIConfig.Messages.Play, Name, toy.Name);
            HandleItemEffect(toy);
        }
        public virtual void Sleep()
        {
            if (State == (StatePet)2 && !WillAttendPlayer(State)) return;
            Console.WriteLine(UIConfig.Messages.Sleep, Name);
            SleepStatChanges();
        }

    }
}
