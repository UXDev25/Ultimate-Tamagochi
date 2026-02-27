using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Model;
using Ultimate_Tamagochi.Model.Enums;
using Ultimate_Tamagochi.Model.Interfaces;
namespace Ultimate_Tamagochi.Models.Pets
{
    public class Cat : Pet, IEat, IPlay, ISleep
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
        public virtual void Eat(Item item) { }
        public virtual void Play(Item item){

        }
        public virtual void Sleep()
        {

        }

    }
}
