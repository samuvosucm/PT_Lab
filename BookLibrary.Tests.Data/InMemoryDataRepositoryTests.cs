using BookLibrary.Data.Interfaces;
using BookLibrary.Data.Objects;

namespace BookLibrary.Tests.Data
{
    [TestClass]
    public class InMemoryDataRepositoryTests
    {

        [TestMethod]
        public void AddUser_ShouldAddUser()
        {
            IDataRepository repository = DataLayerFactory.CreateInMemoryDataRepository();
            IUser user = new User("Juan", "573827384N");

            repository.AddUser(user);

            Assert.IsNotNull(repository.GetUser(user.DNI));
        }

        [TestMethod]
        public void AddToCatalog_ShouldAddToCatalog()
        {
            IDataRepository repository = DataLayerFactory.CreateInMemoryDataRepository();
            ICatalog book = new Catalog("El Principito");

            repository.AddToCatalog(book);

            Assert.IsNotNull(repository.GetFromCatalog(book.Name));
        }

        [TestMethod]
        public void AddToCatalog_ShouldThrowInvalidOperationException()
        {
            IDataRepository repository = DataLayerFactory.CreateInMemoryDataRepository();
            ICatalog book = new Catalog("El Principito");

            repository.AddToCatalog(book);

            Assert.ThrowsException<InvalidOperationException>(() => repository.AddToCatalog(book));
        }

        [TestMethod]
        public void BorrowBook_ShouldRemoveFromCatalog()
        {
            IDataRepository repository = DataLayerFactory.CreateInMemoryDataRepository();
            ICatalog book = new Catalog("El Principito");
            IUser user = new User("Juan", "573827384N");

            repository.AddUser(user);
            repository.AddToCatalog(book);

            Assert.IsNotNull(repository.GetFromCatalog(book.Name));

            repository.BorrowBook(book, user);

            Assert.IsNull(repository.GetFromCatalog(book.Name));
        }

        [TestMethod]
        public void ReturnBook_ShouldAddToCatalog()
        {
            IDataRepository repository = DataLayerFactory.CreateInMemoryDataRepository();
            ICatalog book = new Catalog("El Principito");
            IUser user = new User("Juan", "573827384N");

            repository.AddUser(user);

            repository.ReturnBook(book, user);

            Assert.IsNotNull(repository.GetFromCatalog(book.Name));
        }

        [TestMethod]
        public void RemoveFromCatalog_ShouldRemoveFromCatalog()
        {
            IDataRepository repository = DataLayerFactory.CreateInMemoryDataRepository();
            ICatalog book = new Catalog("El Principito");

            repository.AddToCatalog(book);

            Assert.IsNotNull(repository.GetFromCatalog(book.Name));

            repository.RemoveFromCatalog(book);

            Assert.IsNull(repository.GetFromCatalog(book.Name));
        }

        [TestMethod]
        public void RemoveUser_ShouldRemoveUser()
        {
            IDataRepository repository = DataLayerFactory.CreateInMemoryDataRepository();
            IUser user = new User("Juan", "573827384N");

            repository.AddUser(user);

            Assert.IsNotNull(repository.GetUser(user.DNI));

            repository.RemoveUser(user);

            Assert.IsNull(repository.GetUser(user.DNI));
        }

        [TestMethod]
        public void GetEvents_ShouldReturnEvents()
        {
            IDataRepository repository = DataLayerFactory.CreateInMemoryDataRepository();
            IUser user = new User("Juan", "573827384N");

            repository.AddUser(user);

            Assert.IsNotNull(repository.GetUser(user.DNI));

            List<IEvent> events = repository.GetEvents();

            Assert.AreEqual(1, events.Count);
            Assert.AreEqual(events.First().Action, EventAction.AddUser);
        }
    }
}
