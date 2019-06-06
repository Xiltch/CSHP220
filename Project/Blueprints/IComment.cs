using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprints
{
    public interface IComment
    {
        int ID { get; set; }
        DateTime Created { get; set; }
        ITask Task { get; set; }
        IUser CreatedBy { get; set; }
        string Details { get; set; }
    }
}
