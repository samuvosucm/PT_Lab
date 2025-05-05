
using BookLibrary.Data.Interfaces;

namespace BookLibrary.Data.Objects.Events
{
    internal class EventBorrowBook : Event
    {
        public override EventAction Action => EventAction.BorrowBook;
        public Guid BookGuid { get; }
        public Guid UserGuid { get; }


        public EventBorrowBook(Guid bookGuid, Guid userGuid)
        {
            BookGuid = bookGuid;
            UserGuid = userGuid;
        }
    }
}
