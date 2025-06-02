using BookLibrary.Data.DataBaseCache;
using BookLibrary.Data.Interfaces;

namespace BookLibrary.Data.Objects
{
    internal class SQLServerDataRepository : IDataRepository
    {
        private ProcessStateDataContext _context;
        public SQLServerDataRepository(string connection)
        {
            _context = new ProcessStateDataContext(connection);
        }

        public void AddToCatalog(ICatalog catalog)
        {
            throw new NotImplementedException();
        }

        public void AddUser(IUser user)
        {
            _context.AddUser(user);
        }

        public void BorrowBook(ICatalog book, IUser user)
        {
            throw new NotImplementedException();
        }

        public List<IUser> GetAllUsers()
        {
            IEnumerable<DataBaseCache.User> users = _context.GetAllUsers();
            return users.Select(MapToIUser).ToList();
        }

        public List<ICatalog> GetCatalog()
        {
            throw new NotImplementedException();
        }

        public List<IEvent> GetEvents()
        {
            throw new NotImplementedException();
        }

        public ICatalog? GetFromCatalog(string name)
        {
            throw new NotImplementedException();
        }

        public IUser? GetUser(string dni)
        {
            DataBaseCache.User? user = _context.FilterUserByDNI_MethodSyntax(dni);
            return user == null ? null : MapToIUser(user);
        }

        public void RemoveFromCatalog(ICatalog catalog)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(IUser user)
        {
            throw new NotImplementedException();
        }

        public void ReturnBook(ICatalog book, IUser user)
        {
            throw new NotImplementedException();
        }

        private IUser MapToIUser(DataBaseCache.User user)
        {
            return new User(user.DNI, user.Name);
        }

        public void TruncateAllData()
        {
            _context.TruncateAllData();
        }
    }
}
