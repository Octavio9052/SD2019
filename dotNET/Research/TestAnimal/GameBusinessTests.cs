using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameBusiness;
using AnimalSDK;

namespace TestAnimal
{
    [TestClass]
    public class GameBusinessTests
    {
        [TestMethod]
        public void TestGameBusiness()
        {
            var test = new AppTest();

            AppTest.Main(null);
        }
    }
}
