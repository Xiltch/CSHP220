using Blueprints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Task : ITask
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Must provide a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Must provide details")]
        public string Details { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Stop { get; set; }
        public IUser AssignedTo { get; set; }
    }
}