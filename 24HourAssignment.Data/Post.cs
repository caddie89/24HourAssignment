﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string PostTitle { get; set; }

        [Required]
        public string PostText { get; set; }

        [Required]
        public Guid Author { get; set; }

        public virtual List<Comment> CommentList { get; set; } = new List<Comment>();

    }
}
