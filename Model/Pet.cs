using System;
using System.Collections.Generic;
using System.Text;
using Ultimate_Tamagochi.Model.Enums;

namespace Ultimate_Tamagochi.Models
{
    public abstract class Pet
    {
        public string Name { get; set; }
        public StatePet State { get; set; }
        public bool IsAlive { get; set; }
        public Stats Stats { get; set; }
        public DateTime BirthDate { get => DateTime.Today; }
    }
}
