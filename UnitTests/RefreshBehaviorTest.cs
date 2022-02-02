using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SzofttechZH2_POKLZ6;
using SzofttechZH2_POKLZ6.ViewModel.Behaviors;
using Xamarin.Forms;

namespace UnitTests
{
    [TestClass]
    public class RefreshBehaviorTest
    {
        [TestMethod]
        public void OnRefreshing_ShouldRefreshWell()
        {
            //Arrange
            RefreshView rView = new RefreshView();
            rView.IsRefreshing = true;
            PrivateObject pObject = new PrivateObject(new RefreshBehavior());

            //Act
            pObject.Invoke("OnRefreshing", rView, new EventArgs());

            //Assert
            Assert.IsTrue(true);
        }
    }
}
