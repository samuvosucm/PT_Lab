using BookLibrary.Data.Interfaces;

namespace BookLibrary.Logic.Interfaces
{
    public interface ILogic
    {
        IServiceUser ServiceUser { get; }
        IServiceCatalog ServiceCatalog { get; }
        
    }
}
