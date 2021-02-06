using _24HourAssignment.Data;
using _24HourAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Services
{

    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }


        //CreateReply
        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    Author = _userId,
                    CommentId = model.CommentId,
                    ReplyText = model.ReplyText,
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GetReplies
        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Replies
                    .Where(e => e.Author == _userId)
                    .Select(
                        e => new ReplyListItem
                        {
                            ReplyId = e.ReplyId,
                            ReplyText = e.ReplyText
                        }
                  );
                return query.ToArray();
            }
        }

        ////4.08 GetRepliesByCommentId
        //public ReplyDetail GetRepliesByCommentId(int CommentId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //            .Replies
        //            .Single(e => e.ReplyId == Id && e.AuthorId == _userId);
        //        return
        //            new ReplyDetail
        //            {
        //                ReplyId = entity.ReplyId,
        //                ReplyText = entity.ReplyText,
        //                CreatedUtc = entity.CreatedUtc,
        //                ModifiedUtc = entity.ModifiedUtc
        //            };
        //    }
        //}



    }
}
