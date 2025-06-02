using BookLibrary.Data.DataBaseCache;
using BookLibrary.Data.Interfaces;
using BookLibrary.Data.Objects;
using System;

namespace BookLibrary.Tests.Data
{
    [TestClass]
    [DoNotParallelize]
    [DeploymentItem(@"Instrumentation\Database.mdf", @"Instrumentation")]
    public class SQLServerDataRepositoryTests
    {
        private static string? connectionString;

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            string _DBRelativePath = @"Instrumentation\Database.mdf";
            string _TestingWorkingFolder = Environment.CurrentDirectory;
            string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
        }

        [TestMethod]
        public void GetUser_ShouldGetUser()
        {
            Assert.IsNotNull(connectionString);
            IDataRepository repository = DataLayerFactory.CreateSQLServerDataRepository(connectionString);


            try
            {
                IUser? user = repository.GetUser("38293848N");
                Assert.IsNull(user);

                repository.AddUser(UserFactory.CreateUser("38293848N", "Juan"));
                IUser? user2 = repository.GetUser("38293848N");
                Assert.IsNotNull(user2);
                Assert.AreEqual("38293848N", user2.DNI);
            }
            finally
            {
                repository.TruncateAllData();
            }
        }

        [TestMethod]
        public void GetAllUsers_ShouldGetAllUser()
        {
            Assert.IsNotNull(connectionString);
            IDataRepository repository = DataLayerFactory.CreateSQLServerDataRepository(connectionString);


            try
            {
                repository.AddUser(UserFactory.CreateUser("38293848N", "Juan"));
                repository.AddUser(UserFactory.CreateUser("48293848M", "Juan"));

                IEnumerable<IUser> users = repository.GetAllUsers();
                Assert.IsNotNull(users);
                Assert.AreEqual<int>(2, users.Count());

                foreach (IUser p in users)
                    Assert.AreEqual("Juan", p.Name);
            }
            finally
            {
                repository.TruncateAllData();
            }
        }

    }
}
