using _24HourAssignment.Data;
using _24HourAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    PostId = model.PostId,
                    CommentText = model.CommentText,
                    Author = _userId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.Author == _userId)
                        .Include(e => e.ReplyList)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    Author = e.Author,
                                    CommentId = e.CommentId,
                                    CommentText = e.CommentText,
                                    ReplyList = e.ReplyList
                                }
                        ).ToList();
                return query.ToArray();
                     
            }
        }

    }
}
