using BookLibrary.Data.Interfaces;

namespace BookLibrary.Data.Objects
{
    internal class ProcessState : IProcessState
    {
        public List<ICatalog> Books { get; set; } = new();
        public List<IUser> Users { get; set; } = new();

    }
}
