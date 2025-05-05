namespace BookLibrary.Data.Interfaces
{
    public interface IEvent
    {
        Guid Id { get; }
        DateTime Date { get; }
        EventAction Action { get; }
    }

    public enum EventAction
    {
        AddUser,
        AddToCatalog,
        RemoveUser,
        RemovFromCatalog,
        BorrowBook,
        ReturnBook
    }
}
