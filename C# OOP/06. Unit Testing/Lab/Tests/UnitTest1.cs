using NUnit.Framework;
using P01.TestAxe;
using System;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        [TestCase(100, 100, 100, 100, 95)]  
        public void AxeLoosesDurabilityAfterAttack(
        int hp, int exp, int attack, int durability, int expectedResult)
        {
            Axe axe = new Axe(attack, durability);
            Dummy dummy = new Dummy(hp, exp);

            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedResult),"Axe Durability doesn't change after attack.");
        }
        [Test]
        public void BrokenAxeCantAttack()
        {
            
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(20, 0);

            
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }

}