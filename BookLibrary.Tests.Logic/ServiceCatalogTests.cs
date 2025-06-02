using BookLibrary.Data.Interfaces;
using BookLibrary.Data.Objects;
using BookLibrary.Logic.Interfaces;
using BookLibrary.Logic.Services;
using BookLibrary.Tests.Logic.Instrumentation;


namespace BookLibrary.Tests.Logic
{
    [TestClass]
    public class ServiceCatalogTests
    {

        [TestMethod]
        public void AddToCatalog_ShouldAddToCatalog()
        {
            IDataRepository repository = DataGenerator.CreateDataRepository();
            IServiceCatalog catalogService = new ServiceCatalog(repository);

            catalogService.AddToCatalog(DataGenerator.CreateCatalog());

            Assert.IsNotNull(catalogService.GetFromCatalog("Don Quijote de la Mancha"));
        }

        [TestMethod]
        public void RemoveFromCatalog_ShouldRemoveFromCatalog()
        {
            IDataRepository repository = DataGenerator.CreateDataRepository();
            IServiceCatalog catalogService = new ServiceCatalog(repository);

            ICatalog book = repository.GetCatalog().First();
            
            catalogService.RemoveFromCatalog(book);

            Assert.IsNull(repository.GetFromCatalog(book.Name));
        }
    }
}
