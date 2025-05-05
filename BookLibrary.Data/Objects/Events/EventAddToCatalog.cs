using BookLibrary.Data.Interfaces;

namespace BookLibrary.Data.Objects.Events
{
    internal class EventAddToCatalog : Event
    {
        public override EventAction Action => EventAction.AddToCatalog;
        public Guid BookGuid { get; }

        public EventAddToCatalog(Guid bookGuid)
        {
            BookGuid = bookGuid;
        }
    }
}
