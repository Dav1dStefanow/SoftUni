using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models.Subjects
{
    public abstract class Subject : ISubject
    {
        protected int id;
        protected string name;
        protected double rate;
        protected Subject(int subjectId, string subjectName)
        {
            this.Id = subjectId;
            this.Name = subjectName;
        }
        public int Id
        {
            get { return this.id; }
            protected set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (value == null || value == " ")
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double Rate
        {
            get { return this.rate; }
            protected set { this.rate = value; }
        }
    }
}
