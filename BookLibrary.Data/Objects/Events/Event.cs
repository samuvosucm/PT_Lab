using BookLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Objects.Events
{
    internal abstract class Event : IEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime Date { get; } = DateTime.Now;
        public abstract EventAction Action { get; } 
    }
}
