using Blueprints;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskRepository
{
    public class Repository : ITaskRepository
    {
        private TaskManagerEntities context = new TaskManagerEntities();

        public IComment AddComment(int taskID, IComment comment)
        {
            throw new NotImplementedException();
        }

        public ITask AddTask(ITask task)
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

        public ITask GetTask(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITask> GetTasks()
        {
            throw new NotImplementedException();
        }

        public ITask UpdateTask(ITask task)
        {
            throw new NotImplementedException();
        }

        public IUser AddUser(IUser user)
        {
            TaskUser newUser = new TaskUser() { First = user.First, Last = user.Last };
            newUser = context.TaskUser.Add(newUser);
            return new User() { ID = newUser.Id, First = newUser.First, Last = newUser.Last };
        }

        public IUser UpdateUser(IUser user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int ID)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(int ID)
        {
            var result = context.TaskUser
                .Where(x => x.Id.Equals(ID))
                .Select(x => new User() { ID = x.Id, First = x.First, Last = x.Last })
                .FirstOrDefault();
            return result;
        }

        public IEnumerable<IUser> GetUsers()
        {
            var result = context.TaskUser.Select(x => new User() { ID = x.Id, First = x.First, Last = x.Last });
            return result;
        }

        public int UpdateDatabase()
        {
            return context.SaveChanges();
        }

    }

    public class User : IUser
    {
        public int ID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }

    }

}
