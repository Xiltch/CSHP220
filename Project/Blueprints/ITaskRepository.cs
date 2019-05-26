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
        ITask AddTask(ITask task);
        ITask UpdateTask(ITask task);
        ITask GetTask(int ID);
        bool DeleteTask(int ID);
        IComment AddComment(int taskID, IComment comment);
        bool DeleteComment(int ID);
        IEnumerable<IUser> GetUsers();
        IUser AddUser(IUser user);
        IUser UpdateUser(IUser user);
        IUser GetUser(int ID);
        bool DeleteUser(int ID);
    }

}
