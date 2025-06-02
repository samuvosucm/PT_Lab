using BookLibrary.Presentation.Model.Interfaces;

namespace BookLibrary.Tests.Presentation.Model
{
    [TestClass]
    public sealed class ModelSublayerTests
    {
        [TestMethod]
        public void ModelSublayerTestMethod()
        {
            IModelSublayer layer = ModelSublayerFactory.CreateModelSublayer();
            Assert.IsNotNull(layer);
        }
    }
}
