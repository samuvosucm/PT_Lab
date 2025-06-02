using BookLibrary.Presentation.Model.Interfaces;

namespace BookLibrary.Presentation.Model.Objects
{
    internal class ModelUser : IModelUser
    {
        public string DNI { get; set; }
        public string Name { get; set; }
        public ModelUser(string dni, string name)
        {
            Name = name;
            DNI = dni;
        }
    }
}
