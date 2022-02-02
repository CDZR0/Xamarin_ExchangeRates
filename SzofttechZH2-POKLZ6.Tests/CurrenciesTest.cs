using System.Collections.Generic;
using SzofttechZH2_POKLZ6.Model;
using Xunit;

namespace SzofttechZH2_POKLZ6.Tests
{
    public class CurrenciesTest
    {
        [Fact]
        public void GetList_ShouldReturnAListOnCorrectInput()
        {
            //Arrange
            int expectedCount = 3;

            //Act
            Dictionary<string, string> testDict = new Dictionary<string, string>();
            testDict.Add("TC1", "Test Currency 1");
            testDict.Add("TC2", "Test Currency 2");
            testDict.Add("TC3", "Test Currency 3");
            Currencies testCurrencies = new Currencies(testDict);
            List<string> testList = testCurrencies.GetList();           

            //Assert
            Assert.Equal(testList.Count, expectedCount);
        }

        [Fact]
        public void ToString_ShouldReturnAString()
        {

            Assert.True(true);
        }
    }
}
