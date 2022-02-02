using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SzofttechZH2_POKLZ6.Model;

namespace UnitTests
{
    [TestClass]
    public class CurrenciesTest
    {
        [TestMethod]
        public void GetList_ShouldReturnAListOnCorrectInput()
        {
            //Arrange
            int expected = 3;
            Dictionary<string, string> testDict = new Dictionary<string, string>();
            testDict.Add("TC1", "Test Currency 1");
            testDict.Add("TC2", "Test Currency 2");
            testDict.Add("TC3", "Test Currency 3");
            Currencies testCurrencies = new Currencies(testDict);

            //Act
            List<string> testList = testCurrencies.GetList();

            //Assert
            Assert.AreEqual(expected, testList.Count);
        }

        [TestMethod]
        public void ToString_ShouldReturnAString()
        {
            //Arrange
            Dictionary<string, string> testDict = new Dictionary<string, string>();
            testDict.Add("TC1", "Test Currency 1");
            testDict.Add("TC2", "Test Currency 2");
            testDict.Add("TC3", "Test Currency 3");
            Currencies testCurrencies = new Currencies(testDict);

            //Act
            string receivedString = testCurrencies.ToString();

            //Assert
            Assert.IsTrue(receivedString.Length > 0);
            Assert.IsNotNull(receivedString);
        }
    }
}
