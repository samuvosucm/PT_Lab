using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Interfaces
{
    public interface IDataRepository
    {
        List<IUser> GetAllUsers();
        List<ICatalog> GetCatalog();
        List<IEvent> GetEvents();
        IUser? GetUser(string dni);
        ICatalog? GetFromCatalog(string name);
        void AddUser(IUser user);
        void AddToCatalog(ICatalog catalog);
        void RemoveUser(IUser user);
        void RemoveFromCatalog(ICatalog catalog);
        void BorrowBook(ICatalog book, IUser user);
        void ReturnBook(ICatalog book, IUser user);

    }

}
