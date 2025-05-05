using BookLibrary.Data.Interfaces;

namespace BookLibrary.Logic.Interfaces
{
    public interface IServiceCatalog
    {
        public void AddToCatalog(ICatalog book);
        public void RemoveFromCatalog(ICatalog book);
        public ICatalog? GetFromCatalog(string name);
        public void BorrowBook(ICatalog book, IUser user);
        public void ReturnBook(ICatalog book, IUser user);
    }
}
