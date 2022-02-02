using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SzofttechZH2_POKLZ6.ViewModel.Behaviors;
using Xamarin.Forms;
using FakeItEasy;
using Xamarin.Forms.Internals;

namespace UnitTests
{
    [TestClass]
    public class CurrencyGetterTest
    {
        [TestMethod]
        public void OnFocusReceived_SendersItemsShouldNotPointToNull()
        {
            //Arrange
            Picker testPicker = new Picker();
            PrivateObject pObject = new PrivateObject(new CurrencyGetter());

            //Act
            pObject.Invoke("OnFocusReceived", testPicker, new FocusEventArgs(testPicker, true));

            //Assert
            Assert.IsNotNull(testPicker.Items);
        }

        [TestMethod]
        public void OnSelectedIndexChanged_Senders()
        {
            //Arrange
            var platformServicesFake = A.Fake<IPlatformServices>();
            Device.PlatformServices = platformServicesFake;

            Picker testPicker = new Picker();
            PrivateObject pObject = new PrivateObject(new CurrencyGetter());
            ListView listViewExchangeRates = new ListView();

            //Act
            pObject.Invoke("OnSelectedIndexChanged", testPicker, new EventArgs());

            //Assert
            Assert.IsTrue(true);
        }
    }
}
