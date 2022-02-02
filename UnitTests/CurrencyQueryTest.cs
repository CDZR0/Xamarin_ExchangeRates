using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using SzofttechZH2_POKLZ6.Model;
using SzofttechZH2_POKLZ6.Model.Data;

namespace UnitTests
{
    [TestClass]
    public class CurrencyQueryTest
    {
        [TestMethod]
        public async Task GetListOfCurrenciesAsync_ShouldNotReturnNull()
        {
            //Act
            Currencies testCurrencies = await CurrencyQuery.GetListOfCurrenciesAsync();

            //Assert
            Assert.IsNotNull(testCurrencies);
        }

        [DataTestMethod]
        [DataRow("eur")]
        [DataRow("usd")]
        [DataRow("gbp")]
        public async Task GetSpecificCurrencyRatesAsync_ShouldNotReturnNull(string ISOCode)
        {
            //Act
            SpecificCurrency testCurrencies = await CurrencyQuery.GetSpecificCurrencyRatesAsync(ISOCode);

            //Assert
            Assert.IsNotNull(testCurrencies);
        }
    }
}
