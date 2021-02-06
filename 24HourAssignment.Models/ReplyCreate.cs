using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Models
{
    public class ReplyCreate
    {
        [Required]
        [MaxLength(200, ErrorMessage = "You have exceed the maximum number of characters allowed (200).")]
        public string ReplyText { get; set; }
    }
}
