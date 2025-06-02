    using BookLibrary.Data.Interfaces;

namespace BookLibrary.Data.Objects
{
    internal class User : IUser
    {
        public string DNI { get;}
        public string Name { get; }
        public User (string dni, string name) 
        {
            this.Name = name;
            this.DNI = dni;
        }
    }
}
