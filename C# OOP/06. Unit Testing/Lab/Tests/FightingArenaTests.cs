using NUnit.Framework;
using P05.FightingArena;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class FightingArenaTests
    {
        [Test]
        public void WarriorNameShouldNotBeNullOrWhiteSpace()
        {
            Warrior w = new Warrior("David",20,350);

            Assert.That(w.Name, !Is.Null, "Name should not be empty or whitespace!");
        }
        [Test]
        public void WarriorDemageShouldBePositive()
        {
            Warrior w = new Warrior("David", 20, 350);

            Assert.That(w.Damage, Is.Positive, "Damage value should be positive!");
        }
        [Test]
        public void WarriorHealthShouldNotBeNegative()
        {
            Warrior w = new Warrior("David", 20, 0);

            Assert.That(w.HP, !Is.Negative, "HP should not be negative!");
        }
        [Test]
        [TestCase(70, 20, 10, 100)]
        [TestCase(70, 40, 50, 100)]
        [TestCase(70, 100, 50, 20)]
        public void MethodAttackShouldThrowExeptionIfWorriorIsTooWeak(int w1d,int w1hp, int w2d, int w2hp)
        {
            Warrior w = new Warrior("David", w1d, w1hp);
            Warrior W = new Warrior("Mitaka", w2d, w2hp);

            Assert.Throws<InvalidOperationException>(() => w.Attack(W));
        }
        [Test]
        public void MethodEnrollShouldThrowExeptionIfFighterIsAlreadyOnArena()
        {
            Arena wariors = new Arena();
            Warrior w1 = new Warrior("David",65,230);
            Warrior w2 = new Warrior("Mitio", 45, 236);
            Warrior w3 = new Warrior("Lichi", 85, 120);
            wariors.Enroll(w1);
            wariors.Enroll(w2);
            wariors.Enroll(w3);
            Warrior w4 = new Warrior("David", 234, 670);
            Assert.Throws<InvalidOperationException> (() => wariors.Enroll(w4));
        }
        [Test]
        public void MethodFightHasToThrowExeptionIfFighterIsNotEnrolled()
        {
            Arena wariors = new Arena();
            Warrior w1 = new Warrior("David", 65, 230);
            Warrior w2 = new Warrior("Mitio", 45, 236);
            Warrior w3 = new Warrior("Lichi", 85, 120);
            wariors.Enroll(w1);
            wariors.Enroll(w2);
            wariors.Enroll(w3);
            Assert.Throws<InvalidOperationException>(() => wariors.Fight("David","Martinesko"));
        }
    }
}
