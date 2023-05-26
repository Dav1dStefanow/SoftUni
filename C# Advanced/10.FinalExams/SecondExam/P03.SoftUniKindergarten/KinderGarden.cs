using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.SoftUniKindergarten
{
    internal class KinderGarden : IEnumerable<Child>
    {
        public KinderGarden(string name, int capacity) 
        {
            Name = name;
            Capacity = capacity;
            Children = new List<Child>();
        }

        private string name;
        private int capacity;
        private List<Child> children;

        public string Name
        { 
            get { return this.name; }
            set { this.name = value; }
        }
        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }
        public List<Child> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }

        public bool AddChild(Child child)
        {
            bool isAdded = false;
            if (children.Count != Capacity)
            {
                Children.Add(child);
                isAdded = true;
            }
            return isAdded;
        }
        public bool RemoveChild(string name)
        {
            string[] bothNames = name.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstName = bothNames[0];
            string lastName = bothNames[1];
            foreach (Child child in children)
            {
                if(child.FirstName == firstName && child.LastName == lastName)
                {
                    children.Remove(child);
                    return true;
                }
            }
            return false;
        }
        public int ChildrenCount() => Children.Count;
        public Child GetChild(string fullName)
        {
            string[] bothNames = fullName.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string firstName = bothNames[0];
            string lastName = bothNames[1];
            Child wantedChild = null;
            foreach(Child child in children)
            {
                if(child.FirstName == firstName && child.LastName == lastName)
                {
                    wantedChild = child;
                }
            }
            return wantedChild;
        }
        public void RegistryReport()
        {
            var sortedChildren = this.children.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
            Console.WriteLine($"Registered children in {Name}");
            foreach(Child child in sortedChildren)
            {
                Console.WriteLine(child);
            }
        }

        public IEnumerator<Child> GetEnumerator()
        {
            return new KinderGardenIterator(children);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
       
    }
}
