using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Model.Enums;
using Ultimate_Tamagochi.Model.Interfaces;

namespace Ultimate_Tamagochi.Models.Pets
{
    public class Dog : Pet, IEat, IPlay, ISleep
    {
        public Dog(string name, StatePet state, bool isAlive, Stats stats)
        {
            Name = name;
            State = state;
            IsAlive = isAlive;
            Stats = stats;
        }

        public Dog(string name, Stats stats) : this(name, UI.UIConfig.Prompt._defPetState, UI.UIConfig.Prompt._defPetAlive, stats)
        {
            Name = name;
            Stats = stats;
        }

        public void Clean()
        {

        }
    }
}
