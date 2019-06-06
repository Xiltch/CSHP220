using Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Comment : IComment
    {
        public int ID { get; set; }
        public ITask Task { get; set; }
        public DateTime Date { get; set; }
        public IUser CreatedBy { get; set; }
        public string Details { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}