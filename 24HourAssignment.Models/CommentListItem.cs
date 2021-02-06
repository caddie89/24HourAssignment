using _24HourAssignment.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Models
{
    public class CommentListItem
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public Guid Author { get; set; }

        public List<Reply> ReplyList { get; set; }
    }
}
