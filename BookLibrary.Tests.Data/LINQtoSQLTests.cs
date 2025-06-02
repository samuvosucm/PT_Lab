using BookLibrary.Data.DataBaseCache;

namespace BookLibrary.Tests.Data
{
   
    [TestClass]
    [DoNotParallelize]
    [DeploymentItem(@"Instrumentation\Database.mdf", @"Instrumentation")]
    public class LINQtoSQLTests
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
        public void UserContructorTest()
        {
            using (ProcessStateDataContext processState = new ProcessStateDataContext(connectionString))
            {
                Assert.IsNotNull(processState);
                Assert.AreEqual<int>(0, processState.Users.Count());
                
                try
                {
                    processState.AddUser(UserFactory.CreateUser("38293848N", "Juan"));
                    Assert.AreEqual<int>(1, processState.Users.Count());
                }
                finally
                {
                    processState.TruncateAllData();
                }
            }
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            using (ProcessStateDataContext processState = new ProcessStateDataContext(connectionString))
            {
                Assert.IsNotNull(processState);
                Assert.AreEqual<int>(0, processState.Users.Count());

                try
                {
                    processState.AddUser(UserFactory.CreateUser("38293848N", "Juan"));
                    processState.AddUser(UserFactory.CreateUser("78267848N", "Felipe"));
                    processState.AddUser(UserFactory.CreateUser("28293848N", "Miguel"));

                    Assert.AreEqual<int>(3, processState.Users.Count());
                }
                finally
                {
                    processState.TruncateAllData();
                }
            }
        }

        [TestMethod]
        public void FilterUserByDNI_MethodSyntax()
        {
            using (ProcessStateDataContext processState = new ProcessStateDataContext(connectionString))
            {
                Assert.IsNotNull(processState);
                Assert.AreEqual<int>(0, processState.Users.Count());

                try
                {
                    processState.AddUser(UserFactory.CreateUser("38293848N", "Juan"));
                    processState.AddUser(UserFactory.CreateUser("78267848N", "Felipe"));
                    processState.AddUser(UserFactory.CreateUser("28293848N", "Miguel"));

                    User? user = processState.FilterUserByDNI_MethodSyntax("78267848N");

                    Assert.IsNotNull(user);
                    Assert.AreEqual(user.DNI, "78267848N");

                }
                finally
                {
                    processState.TruncateAllData();
                }
            }
        }

        [TestMethod]
        public void FilterUserByDNI_QuerySyntax()
        {
            using (ProcessStateDataContext processState = new ProcessStateDataContext(connectionString))
            {
                Assert.IsNotNull(processState);
                Assert.AreEqual<int>(0, processState.Users.Count());

                try
                {
                    processState.AddUser(UserFactory.CreateUser("38293848N", "Juan"));
                    processState.AddUser(UserFactory.CreateUser("78267848N", "Felipe"));
                    processState.AddUser(UserFactory.CreateUser("28293848N", "Miguel"));

                    User? user = processState.FilterUserByDNI_QuerySyntax("78267848N");

                    Assert.IsNotNull(user);
                    Assert.AreEqual(user.DNI, "78267848N");

                }
                finally
                {
                    processState.TruncateAllData();
                }
            }
        }
    }
    
}
