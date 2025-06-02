using BookLibrary.Data.Interfaces;
using BookLibrary.Logic.Interfaces;

namespace BookLibrary.Logic.Services
{
    internal class ServiceCatalog : IServiceCatalog
    {
        private readonly IDataRepository repository;

        public ServiceCatalog(IDataRepository repository)
        {
            this.repository = repository;
        }
        public void AddToCatalog(ICatalog book)
        {
            repository.AddToCatalog(book);
        }

        public void BorrowBook(ICatalog book, IUser user)
        {
            repository.BorrowBook(book, user);
        }

        public ICatalog? GetFromCatalog(string name)
        {
            return repository.GetFromCatalog(name);
        }

        public void RemoveFromCatalog(ICatalog book)
        {
            repository.RemoveFromCatalog(book);
        }

        public void ReturnBook(ICatalog book, IUser user)
        {
            repository.ReturnBook(book, user);
        }

        public IEnumerable<ICatalog> GetCatalog()
        {
            return repository.GetCatalog();
        }

        public void BorrowBook(ICatalog book, ILogicUser user)
        {
            throw new NotImplementedException();
        }

        public void ReturnBook(ICatalog book, ILogicUser user)
        {
            throw new NotImplementedException();
        }
    }
}
