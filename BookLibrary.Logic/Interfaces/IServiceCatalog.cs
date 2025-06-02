using BookLibrary.Data.Interfaces;

namespace BookLibrary.Logic.Interfaces
{
    public interface IServiceCatalog
    {
        public void AddToCatalog(ICatalog book);
        public void RemoveFromCatalog(ICatalog book);
        public ICatalog? GetFromCatalog(string name);
        public void BorrowBook(ICatalog book, ILogicUser user);
        public void ReturnBook(ICatalog book, ILogicUser user);
        public IEnumerable<ICatalog> GetCatalog();
    }
}
