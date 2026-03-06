using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Ultimate_Tamagochi.Model.Items;
using Ultimate_Tamagochi.UI;

namespace Ultimate_Tamagochi.Models
{
    public class Stats
    {
        public int Hunger
        {
            get;
            set
            {
                if (value >= UIConfig.Prompt._defMaxStat) value = UIConfig.Prompt._defMaxStat;
                if (value <= UIConfig.Prompt._defMinStat) value = UIConfig.Prompt._defMinStat;
                field = value;
            }
        }
        public int Energy 
        { 
            get; 
            set
            {
                if (value >= UIConfig.Prompt._defMaxStat) value = UIConfig.Prompt._defMaxStat;
                if (value <= UIConfig.Prompt._defMinStat) value = UIConfig.Prompt._defMinStat;
                field = value;
            } 
        }
        public int NutritionalState 
        { 
            get;
            set 
            { 
                if (value >= UIConfig.Prompt._defMaxNutr) value = UIConfig.Prompt._defMaxNutr;  
                if (value <= UIConfig.Prompt._defMinNutr) value = UIConfig.Prompt._defMinNutr;
                field = value;
            }
        }
        public int Health
        {
            get 
            {
                return (Energy + Hunger) / 2;
            } 
        }
        public Stats(int hunger, int energy, int nutr) 
        {
            Hunger = hunger;
            Energy = energy;
            NutritionalState = nutr;
        }

        public Stats() : this(UIConfig.Prompt._defMaxStat, UIConfig.Prompt._defMaxStat, UIConfig.Prompt._defMaxNutr) { }

        public void SetMaxStats() 
        {
            Hunger = UIConfig.Prompt._defMaxStat;
            Energy = UIConfig.Prompt._defMaxStat;
            NutritionalState = UIConfig.Prompt._defMaxNutr;
        }
        public void SetMinStats() 
        {
            Hunger = UIConfig.Prompt._defMinStat;
            Energy = UIConfig.Prompt._defMinStat;
            NutritionalState = UIConfig.Prompt._defMinNutr;
        }
    }
}
