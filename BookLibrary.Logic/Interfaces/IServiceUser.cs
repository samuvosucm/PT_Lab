using BookLibrary.Data.Interfaces;

namespace BookLibrary.Logic.Interfaces
{
    public interface IServiceUser
    {
        public void AddUser(ILogicUser user);

        public IEnumerable<ILogicUser> GetAllUsers();
    }
}
