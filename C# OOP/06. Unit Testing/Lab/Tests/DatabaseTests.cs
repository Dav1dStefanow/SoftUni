using NUnit.Framework;
using P02.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Tests
{
    public class DatabaseTests
    {
        [Test]
        [TestCase(16)]
        [TestCase(10)]
        [TestCase(5)]
        public void DatabaseMustHaveMaximum16Elements(int count)
        {
            Database database = new Database();
           for(int i = 0; i < count;i++)
            {
                database.Add(i);
            }
            Assert.LessOrEqual(database.Count, 16);
        }
        [Test]
        public void AddMethodShouldThrowExeptionWhenItemsAreAbove16()
        {
            Database database = new Database();
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }
        [Test]
        [TestCase(1,17)]
        [TestCase(1, 27)]
        public void ConstructorMustThrowExeptionWhenElementsAreAbove16(int start, int end)
        {
            //Arrange
            int[] elements = Enumerable.Range(start, end).ToArray();

            /*Act*/
            /*Assert*/
            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }
        [Test]
        public void MethodRemoveShouldRemoveElementsWhenAbove0()
        {
            Database database = new Database(1, 2, 3);
            database.Remove();
            Assert.IsTrue(database.Count == 2);
        }
        [Test]
        public void MethodRemoveShouldThrowExeptionWhenCountIs0()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void FetchShouldReturnSameValues()
        {
            //Arrange
            Database database = new Database(1, 2, 3);

            //Act
            database.Add(4);
            database.Add(5);

            database.Remove();
            database.Remove();
            database.Remove();

            int[] fetchedData = database.Fetch();
            int[] expectedData = new int[] { 1, 2 };
            //Assert
            Assert.AreEqual(fetchedData, expectedData);
        }
    }
}
