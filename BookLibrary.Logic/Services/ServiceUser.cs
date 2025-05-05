using BookLibrary.Data.Interfaces;
using BookLibrary.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Logic.Services
{
    internal class ServiceUser : IServiceUser
    {
        private readonly IDataRepository repository;

        public ServiceUser(IDataRepository repository)
        {
            this.repository = repository;
        }

        public void AddUser(IUser user)
        {
            repository.AddUser(user);
        }

        public IUser? GetUser(string DNI)
        {
            return repository.GetUser(DNI);
        }

        public void RemoveUser(IUser user)
        {
            repository.RemoveUser(user);
        }
    }
}
