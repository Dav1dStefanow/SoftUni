using NUnit.Framework;
using P03.ExtendedDatabase;
using System;

namespace Tests
{
    public class DatabasePersonTests
    {
        [Test]
        public void AddMethodShouldThowExeptionIfThereAlreadyIsPersonWhithThisName()
        {
            Person[] persons = new Person[] { new Person(23,"David"), new Person(25, "Martin") };
            Database database = new Database(persons);

            Person person = new Person(27, "David");

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }
        [Test]
        public void AddMethodShouldThowExeptionIfThereAlreadyIsPersonWhithThisId()
        {
            Person[] persons = new Person[] { new Person(23, "David"), new Person(25, "Martin") };
            Database database = new Database(persons);

            Person person = new Person(23, "Ico");

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }
        [Test]
        public void RemoveMethodShouldRemovePersonIfCountAbove0()
        {
            Person[] persons = new Person[] { new Person(23, "David"), new Person(25, "Martin") };
            Database database = new Database(persons);
            database.Remove();

            Assert.IsTrue(database.Count == 1);
        }
        [Test]
        public void RemoveMethodShouldThrowExeptionIfCountIS0AndImplementIt()
        {
            Database database = new Database();
            
            Assert.Throws<InvalidOperationException>(database.Remove);
        }
        [Test]
        public void FindByUsernameShouldThrowExeptionIfNoUserIsPresentWithThisName()
        {
            Database database = new Database(new Person(45,"Gosho"));
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("David"));
        }
        [Test]
        public void FindByIdShouldThrowExeptionIfNoUserIsPresentWithThisId()
        {
            Database database = new Database(new Person(45, "Gosho"));
            Assert.Throws<InvalidOperationException>(() => database.FindById(51));
        }
        [Test]
        public void FindByIdShouldThrowExeptionIfTheGivenNumIsNegative()
        {
            Database database = new Database(new Person(45, "Gosho"));
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-45));
        }
    }
}
