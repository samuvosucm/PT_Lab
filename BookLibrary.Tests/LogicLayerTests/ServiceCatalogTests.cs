using BookLibrary.Data.Interfaces;
using BookLibrary.Data.Objects;
using BookLibrary.Logic.Interfaces;
using BookLibrary.Logic.Services;


namespace BookLibrary.Tests.LogicLayerTests
{
    [TestClass]
    public class ServiceCatalogTests
    {
        [TestMethod]
        public void BorrowBook_ShouldRemoveFromCatalog()
        {
            IDataRepository repository = CreateInMemoryDataRepository.CreateData();
            IServiceCatalog catalogService = new ServiceCatalog(repository);

            IUser user = repository.GetAllUsers().First();
            ICatalog book = repository.GetCatalog().First();

            catalogService.BorrowBook(book, user);

            Assert.IsNull(repository.GetFromCatalog(book.Name));
        }

        [TestMethod]
        public void AddToCatalog_ShouldAddToCatalog()
        {
            IDataRepository repository = CreateInMemoryDataRepository.CreateData();
            IServiceCatalog catalogService = new ServiceCatalog(repository);

            ICatalog book = new Catalog("Don Quijote de la Mancha");

            catalogService.AddToCatalog(book);

            Assert.IsNotNull(catalogService.GetFromCatalog(book.Name));
        }

        [TestMethod]
        public void ReturnBook_ShouldAddToCatalog()
        {
            IDataRepository repository = CreateInMemoryDataRepository.CreateData();
            IServiceCatalog catalogService = new ServiceCatalog(repository);

            IUser user = repository.GetAllUsers().First();
            ICatalog book = new Catalog("Don Quijote de la Mancha");

            catalogService.ReturnBook(book, user);

            Assert.IsNotNull(repository.GetFromCatalog(book.Name));
        }

        [TestMethod]
        public void RemoveFromCatalog_ShouldRemoveFromCatalog()
        {
            IDataRepository repository = CreateInMemoryDataRepository.CreateData();
            IServiceCatalog catalogService = new ServiceCatalog(repository);

            ICatalog book = repository.GetCatalog().First();
            
            catalogService.RemoveFromCatalog(book);

            Assert.IsNull(repository.GetFromCatalog(book.Name));
        }
    }
}
