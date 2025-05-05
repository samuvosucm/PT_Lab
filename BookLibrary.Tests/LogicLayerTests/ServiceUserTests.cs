using BookLibrary.Data.Interfaces;
using BookLibrary.Data.Objects;
using BookLibrary.Logic.Interfaces;
using BookLibrary.Logic.Services;

namespace BookLibrary.Tests.LogicLayerTests
{
    [TestClass]
    public class ServiceUserTests
    {
        [TestMethod]
        public void AddUser_ShouldAddUser()
        {
            IDataRepository repository = CreateInMemoryDataRepository.CreateData();
            IServiceUser userService = new ServiceUser(repository);

            IUser user = new User("Juan Antonio", "273849389N");

            userService.AddUser(user);

            Assert.IsNotNull(userService.GetUser(user.DNI));
        }

        [TestMethod]
        public void RemoveUser_ShouldRemoveUser()
        {
            IDataRepository repository = CreateInMemoryDataRepository.CreateData();
            IServiceUser userService = new ServiceUser(repository);

            IUser user = new User("Juan Antonio", "273849389N");
            userService.AddUser(user);
            Assert.IsNotNull(userService.GetUser(user.DNI));

            userService.RemoveUser(user);
            Assert.IsNull(userService.GetUser(user.DNI));
        }

    }
}
