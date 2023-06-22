using NUnit.Framework;
using P04.CarManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class CarManagerTests
    {

        [Test]
        public void MakeShouldThrowExeptionIfEmpty()
        {
            Car car = new Car("Porche", "Taycan GTS", 11.5, 130);
            Assert.That(car.Make, !Is.Null, "Make cannot be null or empty!");
        }
        [Test]
        public void ModelShouldThrowExeptionIfEmpty()
        {
            Car car = new Car("Porche", "Taycan GTS", 11.5, 130);
            Assert.That(car.Model, !Is.Null, "Make cannot be null or empty!");
        }
        [Test]
        [TestCase(20)]
        [TestCase(10)]
        [TestCase(12)]
        public void FuelConsumptionShouldThrowExeptionIfConsumptionIs0OrNegative(double consumption)
        {
            Car car = new Car("Porche", "Taycan GTS", consumption, 130);
            Assert.That(car.FuelConsumption, Is.GreaterThan(0), "Fuel consumption cannot be zero or negative!");
        }
        [Test]
        [TestCase(20)]
        [TestCase(100)]
        [TestCase(132.5)]
        public void FuelCapacityShouldThrowExeptionIfCApacityIs0OrNegative(double capacity)
        {
            Car car = new Car("Porche", "Taycan GTS", 11.5, capacity);
            Assert.That(car.FuelCapacity, Is.GreaterThan(0), "Fuel capacity cannot be zero or negative!");
        }
        [Test]
        public void RefuelMethodShouldThrowExeptionIfAmountIs0OrNegative()
        {
            Car car = new Car("Porche", "Taycan GTS", 11.5, 130);

            Assert.Throws<ArgumentException>(() => car.Refuel(0));
        }
        [Test]
        public void DriveMethodShouldThrowExeptionIfFuelIsNotEnough()
        {
            Car car = new Car("Porche", "Taycan GTS", 11.5, 20.3);
            car.Refuel(11);
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }
    }
}
