using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please select attendance response")]
        public bool? WillAttend { get; set; }

    }
}