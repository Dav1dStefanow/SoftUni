using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models.Universities
{
    public class University : IUniversity
    {
        private readonly List<string> categories = new List<string>()
        {
            "Technical",
            "Economical",
            "Humanity"
        };

        private int id;
        private string name;
        private string category;
        private int capacity;
        private List<int> requiredSubjects;

        public University(int universityId, string universityName, string category, int capacity, List<int> requiredSubjects)
        {
            this.requiredSubjects = requiredSubjects;
            this.Id = universityId;
            this.Name = universityName;
            this.Category = category;
            this.Capacity = capacity;
        }
        public int Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == " " || value == null)
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public string Category
        {
            get { return this.category; }
            private set
            {
                if (!categories.Contains(value))
                {
                    throw new ArgumentException($"University category {value} is not allowed in the application!");
                }
                this.category = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("University capacity cannot be a negative value!");
                }
                this.capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects => this.requiredSubjects;

        public int AdmittedStudentsCount { get; set; }
    }
}
