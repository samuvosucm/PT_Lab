using BookLibrary.Data.Interfaces;

namespace BookLibrary.Logic.Interfaces
{
    public interface IServiceUser
    {
        public void AddUser(IUser user);
        public void RemoveUser(IUser user);
        public IUser? GetUser(string DNI);
    }
}
