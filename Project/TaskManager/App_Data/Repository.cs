using Blueprints;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.App_Data
{
    public class Repository : ITaskRepository
    {
        private TaskManagerEntities context = new TaskManagerEntities();

        public void AddTask(ITask task)
        {
            Task newTask = new Task()
            {
                Id = task.ID,
                Name = task.Name,
                Details = task.Details,
                Start = task.Start,
                Stop = task.Stop,
                Status = (int)task.Status
            };

            context.Task.Add(newTask);
        }

        public void DeleteTask(int ID)
        {
            Task task = context.Task.SingleOrDefault(x => x.Id.Equals(ID));

            if (task == null)
                throw new ArgumentException("Task ID not found");

            context.Task.Remove(task);
        }

        public void UpdateTask(ITask task)
        {
            Task current = context.Task.SingleOrDefault(x => x.Id.Equals(task.ID));

            if (task == null)
                throw new ArgumentException("Task ID not found");

            var entry = context.Entry(current);

            var sourceProps = task.GetType().GetProperties();

            foreach (var propName in entry.CurrentValues.PropertyNames)
            {
                var sourceProp = sourceProps
                    .Where(x => x.Name.Equals(propName, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();
                if (propName.Equals("Status"))
                    entry.Property(propName).CurrentValue = (int)sourceProp.GetValue(task);
                else
                    entry.Property(propName).CurrentValue = sourceProp.GetValue(task);
            }
         
        }


        public ITask GetTask(int ID)
        {
            var result = context.Task
                .Where(x => x.Id.Equals(ID))
                .SelectITasks()
                .SingleOrDefault();
            return result;
        }

        public IEnumerable<ITask> GetTasks()
        {
            var result = context.Task.SelectITasks();
            return result;
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
                .SelectIUsers()
                .FirstOrDefault();
            return result;
        }

        public IEnumerable<IUser> GetUsers()
        {
            var result = context.TaskUser.SelectIUsers();
            return result;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

    }

    public static class DBExtensions
    {

        public static IEnumerable<IUser> SelectIUsers(this IQueryable<TaskUser> users)
        {
            return users.Select(x => new TaskManager.Models.User() { ID = x.Id, First = x.First, Last = x.Last });
        }

        public static IEnumerable<ITask> SelectITasks(this IQueryable<Task> tasks)
        {

            return tasks.Select(x => new TaskManager.Models.Task()
            {
                ID = x.Id,
                Name = x.Name,
                Details = x.Details,
                Status = (Blueprints.TaskStatus)x.Status,
                Start = x.Start,
                Stop = x.Stop,
                AssignedTo = x.AssignedTo.HasValue
                    ? new TaskManager.Models.User() { ID = x.TaskUser.Id, First = x.TaskUser.First, Last = x.TaskUser.Last }
                    : null
            });
        }
    }

}
