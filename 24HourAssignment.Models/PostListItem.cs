using _24HourAssignment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Models
{
    public class PostListItem
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostText { get; set; }

        public List<Comment> CommentList { get; set; }
    }
}
