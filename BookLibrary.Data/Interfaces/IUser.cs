namespace BookLibrary.Data.Interfaces
{
    public interface IUser
    {
        Guid Id { get; }
        string DNI { get; set; }
        string Name { get; set; }
    }
}
