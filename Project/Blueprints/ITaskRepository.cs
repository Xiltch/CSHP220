using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprints
{

    public interface ITaskRepository
    {
        IEnumerable<ITask> GetTasks();
        bool AddTask(ITask task);
        bool UpdateTask(ITask task);
        ITask GetTask(int ID);
        bool DeleteTask(int ID);
        bool AddComment(int taskID, IComment comment);
        bool DeleteComment(int ID);
    }

}
