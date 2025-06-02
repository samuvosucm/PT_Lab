using BookLibrary.Data.Interfaces;
using BookLibrary.Logic.Services.Objects;

namespace BookLibrary.Logic.Interfaces
{
    public abstract class LogicLayerFactory
    {
        public static ILogic CreateLogicLayer(IDataRepository? data = default)
        {
            return new BusinessLogic(data == null ? DataLayerFactory.CreateInMemoryDataRepository() : data);
        }
    }
}
 