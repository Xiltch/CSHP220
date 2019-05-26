using Blueprints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class User : IUser
    {
        public int ID { get; set; }
        [Required(ErrorMessage="Must provide a First name")]
        public string First { get; set; }
        [Required(ErrorMessage = "Must provide a First name")]
        public string Last { get; set; }
    }
}