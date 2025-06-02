using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Logic.Interfaces
{
    public interface ILogicUser
    {
        string DNI { get; }
        string Name { get; }
    }
}
