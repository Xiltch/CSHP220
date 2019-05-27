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

        public void AddTask(ITask task)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(int ID)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(ITask task)
        {
            throw new NotImplementedException();
        }

        public ITask GetTask(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITask> GetTasks()
        {
            var result = context.Task.Select(x => new Task()
            {
                ID = x.Id,
                Name = x.Name,
                Details = x.Details,
                Status =  (Blueprints.TaskStatus)x.Status,
                Start = x.Start,
                Stop = x.Stop,
                AssignedTo = ConvertTaskUser(x.TaskUser)
            });
            return result;
        }

        private IUser ConvertTaskUser(TaskUser user)
        {
            return new User() { ID = user.Id, First = user.First, Last = user.Last };
        }

        public void AddComment(int taskID, IComment comment)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(int ID)
        {
            throw new NotImplementedException();
        }

        public void AddUser(IUser user)
        {
            TaskUser newUser = new TaskUser() { First = user.First, Last = user.Last };
            newUser = context.TaskUser.Add(newUser);
        }

        public void UpdateUser(IUser user)
        {
            TaskUser current = context.TaskUser.SingleOrDefault(x => x.Id.Equals(user.ID));

            if (current == null)
                throw new ArgumentException("User ID not found");

            context.Entry(current).CurrentValues.SetValues(user);

        }

        public void DeleteUser(int ID)
        {
            TaskUser user = context.TaskUser.SingleOrDefault(x => x.Id.Equals(ID));

            if (user == null)
                throw new ArgumentException("User ID not found");

            context.TaskUser.Remove(user);
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

        public int Save()
        {
            return context.SaveChanges();
        }

        private class User : IUser
        {
            public int ID { get; set; }
            public string First { get; set; }
            public string Last { get; set; }

        }

        private class Task : ITask
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Details { get; set; }
            public Blueprints.TaskStatus Status { get; set; }
            public DateTime? Start { get; set; }
            public DateTime? Stop { get; set; }
            public IUser AssignedTo { get; set; }
        }
    }

}
