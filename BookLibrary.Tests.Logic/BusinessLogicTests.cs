using BookLibrary.Logic.Interfaces;
using BookLibrary.Tests.Logic.Instrumentation;

namespace BookLibrary.Tests.Logic
{
    [TestClass]
    public class BusinessLogicTests
    {

        [TestMethod]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            ILogic logicLayer = LogicLayerFactory.CreateLogicLayer(DataGenerator.CreateDataRepository());

            Assert.AreEqual<int>(1, logicLayer.ServiceUser.GetAllUsers().Count()); 
        }

    }
}
