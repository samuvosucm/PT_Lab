using BookLibrary.Logic.Interfaces;

namespace BookLibrary.Logic.Services.Objects
{
    internal class LogicUser : ILogicUser
    {
        public string DNI { get; set; }
        public string Name { get; set; }
        public LogicUser(string dni, string name)
        {
            Name = name;
            DNI = dni;
        }
    }
}
