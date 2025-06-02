using BookLibrary.Data.Interfaces;
using BookLibrary.Data.Objects.Events;

namespace BookLibrary.Data.Objects
{
    internal class InMemoryDataRepository : IDataRepository
    {
        public InMemoryDataRepository()
        {
            _libraryState = new ProcessState();
            _events = new List<IEvent>();
        }

        public InMemoryDataRepository(IDataRepository repository)
        {
            _libraryState = new ProcessState();
            _events = new List<IEvent>();

            _libraryState.Users.AddRange(repository.GetAllUsers());
            _libraryState.Books.AddRange(repository.GetCatalog());
        }

        private IProcessState _libraryState;
        private List<IEvent> _events;

        public List<IUser> GetAllUsers() => _libraryState.Users;
        public List<ICatalog> GetCatalog() => _libraryState.Books;
        public List<IEvent> GetEvents() => _events;

        public IUser? GetUser(string dni)
        {
            return _libraryState.Users.FirstOrDefault(c => c.DNI == dni);
        }

        public ICatalog? GetFromCatalog(string name)
        {
            return _libraryState.Books.FirstOrDefault(c => c.Name == name);
        }

        public void AddToCatalog(ICatalog catalog)
        {
            if (_libraryState.Books.Any(c => c.Id == catalog.Id))
            {
                throw new InvalidOperationException("Book already exists.");
            }

            _libraryState.Books.Add(catalog);
            _events.Add(new EventAddToCatalog(catalog.Id));
        }

        public void AddUser(IUser user)
        {
            if (_libraryState.Users.Any(c => c.DNI == user.DNI))
            {
                return;
            }

            _libraryState.Users.Add(user);
            _events.Add(new EventAddUser(user.DNI));
        }

        public void BorrowBook(ICatalog book, IUser user)
        {
            if (_libraryState.Books.FirstOrDefault(c => c.Id == book.Id) == null)
            {
                throw new InvalidOperationException("Book doesn't exist.");
            }
            if (_libraryState.Users.FirstOrDefault(c => c.DNI == user.DNI) == null)
            {
                throw new InvalidOperationException("User doesn't exist.");
            }

            _libraryState.Books.Remove(book);
            _events.Add(new EventBorrowBook(book.Id, user.DNI));
        }

        public void RemoveFromCatalog(ICatalog catalog)
        {
            if (_libraryState.Books.FirstOrDefault(c => c.Id == catalog.Id) == null)
            {
                throw new InvalidOperationException("Book doesn't exist.");
            }

            _libraryState.Books.Remove(catalog);
            _events.Add(new EventRemoveFromCatalog(catalog.Id));
        }

        public void RemoveUser(IUser user)
        {
            if (_libraryState.Users.FirstOrDefault(c => c.DNI == user.DNI) == null)
            {
                throw new InvalidOperationException("User doesn't exist.");
            }

            _libraryState.Users.Remove(user);
            _events.Add(new EventRemoveUser(user.DNI));
        }

        public void ReturnBook(ICatalog book, IUser user)
        {
            if (_libraryState.Books.Any(c => c.Id == book.Id))
            {
                throw new InvalidOperationException("Book already exists.");
            }
            if (_libraryState.Users.FirstOrDefault(c => c.DNI == user.DNI) == null)
            {
                throw new InvalidOperationException("User doesn't exist.");
            }

            _libraryState.Books.Add(book);
            _events.Add(new EventReturnBook(book.Id, user.DNI));
        }

        public void TruncateAllData()
        {
            _libraryState = new ProcessState();
            _events = new List<IEvent>();
        }
    }
}   
