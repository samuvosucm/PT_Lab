using BookLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Objects.Events
{
    internal class EventRemoveUser : Event
    {
        public override EventAction Action => EventAction.RemoveUser;
        public Guid UserGuid { get; }

        public EventRemoveUser(Guid userGuid)
        {
            UserGuid = userGuid;
        }
    }
}
