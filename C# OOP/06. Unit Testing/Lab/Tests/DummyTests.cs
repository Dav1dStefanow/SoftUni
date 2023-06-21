using NUnit.Framework;
using P01.TestAxe;
using System;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        [TestCase(20, 20, 10, 10, 10)]
        public void DummyLoosesHealthIfAttacked(
        int hp, int exp, int attack, int durability, int expectedResult)
        {
            Axe axe = new Axe(attack, durability);
            Dummy dummy = new Dummy(hp, exp);
            axe.Attack(dummy);
            Assert.That(dummy.Health, Is.EqualTo(expectedResult),"Dummy Health didn't change.");
        }
        [Test]
        public void DeadDummyThrowsExeptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 10);
           Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));
        }
        [Test]
        public void DeadDummyGivesXPIfDead()
        {
            Dummy dummy = new Dummy(0, 100);
            Assert.AreEqual(100,dummy.GiveExperience());
        }
        [Test]
        public void DummyDoesNotGiveXPIfNotDead()
        {
            Dummy dummy = new Dummy(100, 100);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
