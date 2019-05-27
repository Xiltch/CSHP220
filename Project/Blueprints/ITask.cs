using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprints
{
    public enum TaskStatus
    {
        DRAFT,
        PENDING,
        IN_PROGRESS,
        COMPLETED,
        CANCELLED
    }

    public interface ITask
    {
        int ID { get; set; }
        string Name { get; set; }
        string Details { get; set; }
        TaskStatus Status { get; set; }
        DateTime? Start { get; set; }
        DateTime? Stop { get; set; }
        IUser? AssignedTo { get; set; }
    }

}
