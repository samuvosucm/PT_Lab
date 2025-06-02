using BookLibrary.Data.Interfaces;
using BookLibrary.Data.Objects;

namespace BookLibrary.Tests.Data
{
    internal static class UserFactory
    {
        internal static IUser CreateUser(string dni, string name)
        {
            return new User(dni, name);
        }
    }
}
