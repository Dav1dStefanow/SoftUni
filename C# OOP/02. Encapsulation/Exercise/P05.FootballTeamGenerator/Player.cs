﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.FootballTeamGenerator
{
    internal class Player
    {
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting) 
        { 
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        private int skillLevel; 
        public string Name
        { 
            get { return name; }
            private set { name = value; }
        }
        public int Endurance
        {
            get { return endurance; }
            private set 
            {
                if (value < 0 || value > 100) throw new ArgumentException("Endurance should be between 0 and 100.");

                endurance = value;
            }
        }
        public int Sprint
        {
            get { return sprint; }
            private set 
            {
                if (value < 0 || value > 100) throw new ArgumentException("Sprint should be between 0 and 100.");

                sprint = value; 
            }

        }
        public int Dribble
        {
            get { return dribble; }
            private set 
            {
                if (value < 0 || value > 100) throw new ArgumentException("Dribble should be between 0 and 100.");

                dribble = value; 
            }
        }
        public int Passing
        {
            get { return passing; }
            private set 
            {
                if (value < 0 || value > 100) throw new ArgumentException("Passing should be between 0 and 100.");

                passing = value; 
            }
        }
        public int Shooting
        {
            get { return shooting; }
            private set 
            { 
                if(value < 0 ||  value > 100) throw new ArgumentException("Shooting should be between 0 and 100.");
                else shooting = value;
            }
        }

        public double SkillLevel => (this.Endurance + this.Passing + this.Shooting + this.Sprint + this.Dribble) / 5.0;
        
    }
}
