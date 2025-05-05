using BookLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Objects.Events
{
    internal class EventRemoveFromCatalog : Event
    {
        public override EventAction Action => EventAction.RemovFromCatalog;
        public Guid BookGuid { get; }


        public EventRemoveFromCatalog(Guid bookGuid)
        {
            BookGuid = bookGuid;
        }
    }
}
