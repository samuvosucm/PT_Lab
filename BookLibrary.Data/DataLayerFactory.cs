using BookLibrary.Data.Interfaces;
using BookLibrary.Data.Objects;

namespace BookLibrary.Data
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
    }
}
