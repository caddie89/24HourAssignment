using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Models
{
    public class ReplyListItem
    {
        [Required]
        public Guid ReplyId { get; set; }
        [Required]
        public string ReplyText { get; set; }
        [Required]
        public Guid Author { get; set }

        //virtual list of replies? (from prompt)

        //Foreign Key to Post via Id w/ virtual Post? (from prompt)
        [Required]
        [Display(Name ="When:")]
        public DateTimeOffset CreatedUtc { get; set; }  //from eleven note.Models.NoteListItem

    }
}
