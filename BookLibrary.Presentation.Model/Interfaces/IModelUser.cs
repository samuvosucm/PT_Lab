using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Presentation.Model.Interfaces
{
    public interface IModelUser
    {
        string DNI { get; set; }
        string Name { get; set; }
    }
}
