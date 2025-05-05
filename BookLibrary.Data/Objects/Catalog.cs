using BookLibrary.Data.Interfaces;

namespace BookLibrary.Data.Objects
{
    internal class Catalog : ICatalog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public Catalog (string name)
        {
            Name = name;
        }
    }
}
