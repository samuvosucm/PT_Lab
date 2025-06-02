using BookLibrary.Data.Interfaces;

namespace BookLibrary.Data.Objects.Events
{
    internal class EventReturnBook : Event
    {
        public override EventAction Action => EventAction.ReturnBook;
        public Guid BookGuid { get; }
        public string DNI { get; }


        public EventReturnBook(Guid bookGuid, string dni)
        {
            BookGuid = bookGuid;
            DNI = dni;
        }
    }
}
