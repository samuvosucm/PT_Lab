namespace BookLibrary.Data.Interfaces
{
    public interface IProcessState
    {
        public List<ICatalog> Books { get; }
        public List<IUser> Users { get; }
    }
}
