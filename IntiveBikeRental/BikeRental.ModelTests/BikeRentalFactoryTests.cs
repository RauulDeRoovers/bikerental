using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikeRental.Contract;
using System.Xml.Linq;
using BikeRental.Service;
using System.Collections.Generic;

namespace BikeRental.Model.Tests
{
    [TestClass()]
    public class BikeRentalFactoryTests
    {
        //TODO: create xsd schema definition from xml
        //TODO: i assume console is log
        // TODO: handle false result
        //TODO: comment on the 0.00000001 for GeFamilyWeekRentalForThreeTest
        //TODO: add tests for Family Day/Week Rentals for Three/Four/Five
        private IBikeRentalFactory bikeRentalFactory;

        [TestInitialize]
        public void TestInitialize()
        {
            var xml = XDocument.Load("BikeRentalTypes.xml");
            IBikeRentalTypesService bikeRentalTypesService = new XmlBikeRentalTypesService(xml);
            bikeRentalFactory = new BikeRentalFactory(bikeRentalTypesService);
        }

        [TestMethod()]
        public void BikeRentalFactoryDoesNotBreakIfInvalidDiscountBikeRentalTypeExistsInConfig()
        {
            var xml = XDocument.Load("BikeRentalTypesBrokenInvalidDiscount.xml");
            IBikeRentalTypesService bikeRentalTypesService = new XmlBikeRentalTypesService(xml);
            IBikeRentalFactory bikeRentalFactoryEmpty = new BikeRentalFactory(bikeRentalTypesService);
            Assert.AreEqual(0, bikeRentalFactoryEmpty.GetBikeRentalsCount(), "Bike Rental Factory should have no Bike Rental Types.");
        }

        [TestMethod()]
        public void BikeRentalFactoryDoesNotBreakIfDuplicatedByNameBikeRentalTypeExistsInConfig()
        {
            var xml = XDocument.Load("BikeRentalTypesDuplicatedNames.xml");
            IBikeRentalTypesService bikeRentalTypesService = new XmlBikeRentalTypesService(xml);
            IBikeRentalFactory bikeRentalFactoryEmpty = new BikeRentalFactory(bikeRentalTypesService);
            Assert.AreEqual(2, bikeRentalFactoryEmpty.GetBikeRentalsCount(), "Bike Rental Factory should have only 2 Bike Rental Types");
        }

        [TestMethod()]
        public void GetHourRentalTest()
        {
            IBikeRental hourRental = bikeRentalFactory.GetHourRental();
            Assert.AreEqual(1, hourRental.BikesAmount, "Bikes Amount should be 1 for Hour rentals.");
            Assert.AreEqual(1, hourRental.LengthInHours, "Length in Hours should be 1 for Hour rentals.");
            Assert.AreEqual(5, hourRental.UnitPrice, "Unit Price should be 5 for Hour rentals.");
            Assert.AreEqual(5, hourRental.TotalPrice, "Total Price should be 5 for Hour rentals.");
        }

        [TestMethod()]
        public void GeDayRentalTest()
        {
            IBikeRental dayRental = bikeRentalFactory.GetDayRental();
            Assert.AreEqual(1, dayRental.BikesAmount, "Bikes Amount should be 1 for Day rentals.");
            Assert.AreEqual(24, dayRental.LengthInHours, "Length in Hours should be 24 for Day rentals.");
            Assert.AreEqual(20, dayRental.UnitPrice, "Unit Price should be 20 for Day rentals.");
            Assert.AreEqual(20, dayRental.TotalPrice, "Total Price should be 20 for Day rentals.");
        }

        [TestMethod()]
        public void GeWeekRentalTest()
        {
            IBikeRental weekRental = bikeRentalFactory.GetWeekRental();
            Assert.AreEqual(1, weekRental.BikesAmount, "Bikes Amount should be 1 for Week rentals.");
            Assert.AreEqual(168, weekRental.LengthInHours, "Length in Hours should be 168 for Week rentals.");
            Assert.AreEqual(60, weekRental.UnitPrice, "Unit Price should be 60 for Week rentals.");
            Assert.AreEqual(60, weekRental.TotalPrice, "Total Price should be 60 for Week rentals.");
        }

        [TestMethod()]
        public void GeFamilyHourRentalForThreeTest()
        {
            IBikeRental familyHourRentalForThree = bikeRentalFactory.GeFamilyHourRentalForThree();
            Assert.AreEqual(3, familyHourRentalForThree.BikesAmount, "Bikes Amount should be 3 for Family Hour Rental For Three rentals.");
            Assert.AreEqual(1, familyHourRentalForThree.LengthInHours, "Length in Hours should be 1 for Family Hour Rental For Three rentals.");
            Assert.AreEqual(5, familyHourRentalForThree.UnitPrice, "Unit Price should be 5 for Family Hour Rental For Three rentals.");
            Assert.AreEqual(10.5, familyHourRentalForThree.TotalPrice, "Total Price should be 10.5 for Family Hour Rental For Three rentals.");
        }

        [TestMethod()]
        public void GeFamilyDayRentalForThreeTest()
        {
            IBikeRental familyDayRentalForThree = bikeRentalFactory.GeFamilyDayRentalForThree();
            Assert.AreEqual(3, familyDayRentalForThree.BikesAmount, "Bikes Amount should be 3 for Family Day Rental For Three rentals.");
            Assert.AreEqual(24, familyDayRentalForThree.LengthInHours, "Length in Hours should be 24 for Family Day Rental For Three rentals.");
            Assert.AreEqual(20, familyDayRentalForThree.UnitPrice, "Unit Price should be 20 for Family Day Rental For Three rentals.");
            Assert.AreEqual(42, familyDayRentalForThree.TotalPrice, "Total Price should be 42 for Family Day Rental For Three rentals.");
        }

        [TestMethod()]
        public void GeFamilyWeekRentalForThreeTest()
        {
            IBikeRental familyWeekRentalForThree = bikeRentalFactory.GeFamilyWeekRentalForThree();
            Assert.AreEqual(3, familyWeekRentalForThree.BikesAmount, "Bikes Amount should be 3 for Family Week Rental For Three rentals.");
            Assert.AreEqual(168, familyWeekRentalForThree.LengthInHours, "Length in Hours should be 168 for Family Week Rental For Three rentals.");
            Assert.AreEqual(60, familyWeekRentalForThree.UnitPrice, "Unit Price should be 60 for Family Week Rental For Three rentals.");
            Assert.AreEqual(126, familyWeekRentalForThree.TotalPrice, 0.00000001, "Total Price should be 126 for Family Week Rental For Three rentals.");
        }

        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException), "There is no rental configured with name Family Week Rental For Six")]
        public void GeFamilyWeekRentalForSixTest()
        {
            IBikeRental familyWeekRentalForSix = bikeRentalFactory.GeFamilyWeekRentalForSix();
        }
    }
}