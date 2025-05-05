namespace BookLibrary.Data.Interfaces
{
    public interface ICatalog
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
