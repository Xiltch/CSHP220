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
        void AddTask(ITask task);
        void UpdateTask(ITask task);
        ITask GetTask(int ID);
        void DeleteTask(int ID);
        void AddComment(int taskID, IComment comment);
        void DeleteComment(int ID);
        IEnumerable<IUser> GetUsers();
        void AddUser(IUser user);
        void UpdateUser(IUser user);
        IUser GetUser(int ID);
        void DeleteUser(int ID);
    }

}
