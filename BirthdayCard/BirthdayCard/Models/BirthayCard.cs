using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BirthdayCard.Models
{
    public class BirthayCard
    {
        [Required(ErrorMessage = "Please enter who the card is from")]
        public string From { get; set; }
        [Required(ErrorMessage = "Please enter who the card is to")]
        public string To { get; set; }
        [Required(ErrorMessage = "Please enter a message for the card")]
        public string Message { get; set; }

    }
}