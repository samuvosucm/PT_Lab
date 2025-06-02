using BookLibrary.Data.Interfaces;
using System.Diagnostics;

namespace BookLibrary.Data.DataBaseCache
{
    partial class ProcessStateDataContext
    {
        public void AddUser(IUser user)
        {

            this.Users.InsertOnSubmit(MapToDBUser(user));
            this.SubmitChanges();
        }

        public User? FilterUserByDNI_MethodSyntax(string dni)
        {
            return this.Users.SingleOrDefault(user => user.DNI == dni);
        }

        public User? FilterUserByDNI_QuerySyntax(string dni)
        {
            return (from user in this.Users
                    where user.DNI.Equals(dni)
                    select user).SingleOrDefault();
        }

        public IEnumerable<User> GetAllUsers() 
        {
            return this.Users;
        }

        private User MapToDBUser(IUser user)
        {
            return new User
            {
                DNI = user.DNI,
                Name = user.Name,
            };
        }

        [Conditional("DEBUG")]
        public void TruncateAllData()
        {
            Users.DeleteAllOnSubmit<User>(Users);
            SubmitChanges();
        }
    }
}