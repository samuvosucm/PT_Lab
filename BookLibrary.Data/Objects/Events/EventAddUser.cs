using BookLibrary.Data.Interfaces;

namespace BookLibrary.Data.Objects.Events
{
    internal class EventAddUser : Event
    {
        public override EventAction Action => EventAction.AddUser;
        public Guid UserGuid { get; }

        public EventAddUser(Guid userGuid)
        {
            UserGuid = userGuid;
        }
    }
}
