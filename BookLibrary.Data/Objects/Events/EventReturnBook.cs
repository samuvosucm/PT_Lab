using BookLibrary.Data.Interfaces;

namespace BookLibrary.Data.Objects.Events
{
    internal class EventReturnBook : Event
    {
        public override EventAction Action => EventAction.ReturnBook;
        public Guid BookGuid { get; }
        public Guid UserGuid { get; }


        public EventReturnBook(Guid bookGuid, Guid userGuid)
        {
            BookGuid = bookGuid;
            UserGuid = userGuid;
        }
    }
}
