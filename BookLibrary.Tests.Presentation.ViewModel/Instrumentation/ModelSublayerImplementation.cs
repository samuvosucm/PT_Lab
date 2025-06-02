using BookLibrary.Presentation.Model.Interfaces;
using BookLibrary.Presentation.Model.Objects;

namespace BookLibrary.Tests.Presentation.ViewModel.Instrumentation
{
    internal class ModelSublayerImplementation : IModelSublayer
    {

        private readonly List<IModelUser> users = new List<IModelUser>
        {
            new ModelUser("Juan", "asdf")
        };
            
        public void AddUser(string dni, string name)
        {
            users.Add(new ModelUser(dni, name));
        }

        public IEnumerable<IModelUser> GetAllUsers()
        {
            return users;
        }
    }
}
