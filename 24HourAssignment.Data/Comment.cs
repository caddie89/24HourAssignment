using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        [Required]
        public string CommentText { get; set; }

        [Required]
        public Guid Author { get; set; }

        public virtual List<Reply> ReplyList { get; set; } = new List<Reply>();
    }
}
