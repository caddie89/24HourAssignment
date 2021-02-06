using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Models
{
    public class CommentCreate
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string CommentText { get; set; }
        public Guid Author { get; set; }
    }
}
