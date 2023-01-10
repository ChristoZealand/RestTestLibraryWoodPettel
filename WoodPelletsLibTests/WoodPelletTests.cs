using Microsoft.VisualStudio.TestTools.UnitTesting;
using WoodPelletsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib.Tests
{
    [TestClass()]
    public class WoodPelletTests
    {
        WoodPellet woodPelletNormal = new WoodPellet(1, "WoodBrand1", 20.99, 3);
        WoodPellet woodPelletBrandLessThanTwoCharacters = new WoodPellet(2, "W", 20.99, 3);
        WoodPellet woodPelletNegativePrice = new WoodPellet(3, "WoodBrand2", -1.85, 2);
        WoodPellet woodPelletQaulityLow = new WoodPellet(4, "WoodBrand3", 1.85, 0);
        WoodPellet woodPelletQualityHigh = new WoodPellet(5, "WoodBrand4", 1.85, 6);

        [TestMethod()]
        public void ToStringTest()
        {
            string str = woodPelletNormal.ToString();

            Assert.AreEqual("{Id=1, Brand=WoodBrand1, Price=20,99, Quality=3}", str);
        }

        [DataRow("22")]
        [DataRow("333")]
        [TestMethod()]
        public void ValidateBrandTest(string brand)
        {
            woodPelletNormal.Brand = brand;
            woodPelletNormal.ValidateBrand();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletBrandLessThanTwoCharacters.ValidateBrand());
        }

        [DataRow(0.00)]
        [DataRow(1.00)]
        [TestMethod()]
        public void ValidatePriceTest(double price)
        {
            woodPelletNormal.Price = price;
            woodPelletNormal.ValidatePrice();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletNegativePrice.ValidatePrice());
        }

        [DataRow(1)]
        [DataRow(3)]
        [DataRow(5)]
        [TestMethod()]
        public void ValidateQualityTest(int quality)
        {
            woodPelletNormal.Quality = quality;
            woodPelletNormal.ValidateQuality();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletQaulityLow.ValidateQuality());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletQualityHigh.ValidateQuality());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            woodPelletNormal.Validate();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletBrandLessThanTwoCharacters.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletNegativePrice.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletQaulityLow.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletQualityHigh.Validate());
        }
    }
}