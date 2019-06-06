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
        ITask Task { get; set; }
        DateTime Date { get; set; }
        IUser CreatedBy { get; set; }
        string Details { get; set; }
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
    }
}
