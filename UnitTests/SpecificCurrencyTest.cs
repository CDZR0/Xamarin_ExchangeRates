using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using SzofttechZH2_POKLZ6.Model;

namespace UnitTests
{
    [TestClass]
    public class SpecificCurrencyTest
    {
        [TestMethod]
        public void ToString_ShouldReturnAString()
        {
            //Arrange
            SpecificCurrency sCurrencyTest = new SpecificCurrency();
            Dictionary<string, double> testDict = new Dictionary<string, double>();
            testDict.Add("eur", 360.32);
            testDict.Add("usd", 320.43);
            testDict.Add("gbp", 420.69);
            sCurrencyTest.Rates = testDict;

            //Act
            string receivedString = sCurrencyTest.ToString();

            //Assert
            Assert.IsNotNull(receivedString);
        }

        [TestMethod]
        public void GetDateAsDateTime_ShouldReturnADateTime()
        {
            //Arrange
            SpecificCurrency sCurrencyTest = new SpecificCurrency();
            DateTime expected = new DateTime(2021, 12, 9);

            //Act
            sCurrencyTest.Date = "2021-12-09";
            DateTime? testDateTime = sCurrencyTest.GetDateAsDateTime();

            //Assert
            Assert.IsNotNull(testDateTime);
            Assert.AreEqual(expected, testDateTime);
        }

        [TestMethod]
        public void GetFormattedRates_ShouldReturnAString()
        {
            //Arrange
            SpecificCurrency sCurrencyTest = new SpecificCurrency();
            Dictionary<string, double> testDict1 = new Dictionary<string, double>();
            testDict1.Add("eur", 360.32);
            testDict1.Add("usd", 320.43);
            testDict1.Add("gbp", 420.69);
            sCurrencyTest.Rates = testDict1;

            Dictionary<string, string> testDict2 = new Dictionary<string, string>();
            testDict2.Add("TC1", "Test Currency 1");
            testDict2.Add("TC2", "Test Currency 2");
            testDict2.Add("TC3", "Test Currency 3");
            Currencies testCurrencies = new Currencies(testDict2);

            //Act
            List<StringWithContent> receivedString = sCurrencyTest.GetFormattedRates(testCurrencies, 1.0);

            //Assert
            Assert.IsTrue(receivedString.Count > 0);
            Assert.IsNotNull(receivedString);
        }
    }
}
