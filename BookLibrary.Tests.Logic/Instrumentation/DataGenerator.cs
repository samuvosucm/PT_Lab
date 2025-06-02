using BookLibrary.Data.Interfaces;
using BookLibrary.Data.Objects;
using BookLibrary.Logic.Interfaces;
using BookLibrary.Logic.Services.Objects;

namespace BookLibrary.Tests.Logic.Instrumentation
{
    internal static class DataGenerator
    {
        internal static IDataRepository CreateDataRepository()
        {
            IDataRepository repository = DataLayerFactory.CreateInMemoryDataRepository();

            IUser user = new User("Juan", "573827384N");
            repository.AddUser(user);
            ICatalog book = new Catalog("El Principito");
            repository.AddToCatalog(book);

            return repository;
        }

        internal static IDataRepository CreateEmptyRepository()
        {
            IDataRepository repository = DataLayerFactory.CreateInMemoryDataRepository();

            return repository;
        }

        internal static ILogicUser CreateUser()
        {
            return new LogicUser("28384728M", "Felipe");
        }

        internal static ICatalog CreateCatalog()
        {
            return new Catalog("Don Quijote de la Mancha");
        }

    }
}
