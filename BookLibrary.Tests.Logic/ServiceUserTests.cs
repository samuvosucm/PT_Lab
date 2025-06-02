using BookLibrary.Data.Interfaces;
using BookLibrary.Logic.Interfaces;
using BookLibrary.Logic.Services;
using BookLibrary.Tests.Logic.Instrumentation;

namespace BookLibrary.Tests.Logic
{
    
    [TestClass]
    public class ServiceUserTests
    {
        [TestMethod]
        public void AddUser_ShouldAddUser()
        {
            IDataRepository repository = DataGenerator.CreateEmptyRepository();
            IServiceUser userService = new ServiceUser(repository);

            userService.AddUser(DataGenerator.CreateUser());

            Assert.AreEqual<int>(1, userService.GetAllUsers().Count());
        }

        [TestMethod]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            IDataRepository repository = DataGenerator.CreateDataRepository();
            IServiceUser userService = new ServiceUser(repository);

            Assert.AreEqual<int>(1, userService.GetAllUsers().Count());
        }
    }
}
