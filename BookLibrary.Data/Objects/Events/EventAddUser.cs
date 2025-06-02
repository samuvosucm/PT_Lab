using BookLibrary.Data.Interfaces;

namespace BookLibrary.Data.Objects.Events
{
    internal class EventAddUser : Event
    {
        public override EventAction Action => EventAction.AddUser;
        public string DNI { get; }

        public EventAddUser(string dni)
        {
            DNI = dni;
        }
    }
}
