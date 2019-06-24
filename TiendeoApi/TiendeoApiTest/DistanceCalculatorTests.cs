using NUnit.Framework;
using System;
using TiendeoApi.Utils;

namespace Tests
{
    [TestFixture]
    public class DistanceCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Distance_ReturnExpectectedValue()
        {
            ///Arrange
            IDistanceCalculator distanceCalculator = new DistanceCalculator();
            decimal madridLatitude = 40.420300m;
            decimal madridLongitude = -3.705774m;
            decimal barcelonaLatitude = 41.385590m;
            decimal barcelonaLongitude = 2.168745m;
            double distanceMadridBarcelona = 505.14D;
            ///Action
            double distance = distanceCalculator.GetDistance(madridLatitude, barcelonaLatitude, madridLongitude, barcelonaLongitude);
            ///Assert
            Assert.That(Math.Round(distance, 2) == distanceMadridBarcelona);
        }

        [Test]
        public void Distance_ReturnExpectectedValueZero()
        {
            ///Arrange
            IDistanceCalculator distanceCalculator = new DistanceCalculator();
            decimal madridLatitude = 40.420300m;
            decimal madridLongitude = -3.705774m;
            double distanceZero = 0D;
            ///Action
            double distance = distanceCalculator.GetDistance(madridLatitude, madridLatitude, madridLongitude, madridLongitude);
            ///Assert
            Assert.That(distance == distanceZero);
        }
    }
}