using BookLibrary.Data;
using BookLibrary.Data.Interfaces;
using BookLibrary.Data.Objects;

namespace BookLibrary.Tests.LogicLayerTests
{
    internal class CreateInMemoryDataRepository
    {
        public static IDataRepository CreateData()
        {
            IDataRepository repository = DataLayerFactory.CreateInMemoryDataRepository();

            IUser user = new User("Juan", "573827384N");
            repository.AddUser(user);
            ICatalog book = new Catalog("El Principito");
            repository.AddToCatalog(book);

            return repository;
        }
    }
}
