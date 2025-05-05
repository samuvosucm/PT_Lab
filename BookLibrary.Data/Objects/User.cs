    using BookLibrary.Data.Interfaces;

namespace BookLibrary.Data.Objects
{
    internal class User : IUser
    {
        public Guid Id {  get; set; } = Guid.NewGuid();
        public string DNI { get; set; }
        public string Name { get; set; }
        
        public User (string dni, string name) 
        {
            this.Name = name;
            this.DNI = dni;
        }
    }
}
