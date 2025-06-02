using BookLibrary.Data.Interfaces;
using BookLibrary.Logic.Interfaces;

namespace BookLibrary.Logic.Services
{
    internal class ServiceUser : IServiceUser
    {
        private readonly IDataRepository repository;

        public ServiceUser(IDataRepository repository)
        {
            this.repository = repository;
        }

        public void AddUser(ILogicUser user)
        {
            repository.AddUser(new LogicToDataUser(user));
        }

        public IEnumerable<ILogicUser> GetAllUsers()
        {
            return repository.GetAllUsers().Select(u => new DataToLogicUser(u)).ToList();
        }

        private class LogicToDataUser : IUser
        {
            public string DNI { get; }
            public string Name { get; }

            public LogicToDataUser(ILogicUser logicUser)
            {
                DNI = logicUser.DNI;
                Name = logicUser.Name;
            }
        }

        private class DataToLogicUser : ILogicUser
        {
            public string DNI { get; }
            public string Name { get; }

            public DataToLogicUser(IUser user)
            {
                DNI = user.DNI;
                Name = user.Name;
            }
        }
    }
}
