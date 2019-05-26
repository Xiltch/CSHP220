using Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskRepository
{
    public class Repository : ITaskRepository
    {
        public bool AddComment(int taskID, IComment comment)
        {
            throw new NotImplementedException();
        }

        public bool AddTask(ITask task)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(IUser user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteComment(int ID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTask(int ID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int ID)
        {
            throw new NotImplementedException();
        }

        public ITask GetTask(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITask> GetTasks()
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUser> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool UpdateTask(ITask task)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(IUser user)
        {
            throw new NotImplementedException();
        }
    }
}
