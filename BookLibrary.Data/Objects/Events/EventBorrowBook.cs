
using BookLibrary.Data.Interfaces;

namespace BookLibrary.Data.Objects.Events
{
    internal class EventBorrowBook : Event
    {
        public override EventAction Action => EventAction.BorrowBook;
        public Guid BookGuid { get; }
        public string DNI { get; }


        public EventBorrowBook(Guid bookGuid, string dni)
        {
            BookGuid = bookGuid;
            DNI = dni;
        }
    }
}
