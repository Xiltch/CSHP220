using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprints
{
    public interface IUser
    {
        int ID { get; set; }
        string First { get; set; }
        string Last { get; set; }
    }

}
