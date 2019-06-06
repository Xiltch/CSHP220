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

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Must provide details")]
        public string Details { get; set; }
        [NotMapped]
        public TaskStatus Status { get; set; }
        [Column("Status")]
        private int EnumStatus { get { return (int)Status; } set { Status = (TaskStatus)value; } }
        public DateTime? Start { get; set; }
        public DateTime? Stop { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public IUser AssignedTo { get; set; }
        public int AssignedUserID { get; set; }
        public IEnumerable<IComment> Comments { get; set; }
    }
}