using BookLibrary.Data.Objects;

namespace BookLibrary.Data.Interfaces
{
    public abstract class DataLayerFactory
    {
        public static IDataRepository CreateInMemoryDataRepository()
        {
            return new InMemoryDataRepository();
        }

        public static IDataRepository CreateInMemoryDataRepository(IDataRepository dataRepository)
        {
            return new InMemoryDataRepository(dataRepository);
        }

        public static IDataRepository CreateSQLServerDataRepository(string connection)
        {
            return new SQLServerDataRepository(connection);
        }
    }
}
