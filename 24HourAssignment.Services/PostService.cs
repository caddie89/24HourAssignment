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
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        // POST
        public bool CreatePost(PostCreate model)
        {
            var entity =

                new Post()
                {
                    Author = _userId,
                    PostTitle = model.PostTitle,
                    PostText = model.PostText,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // GET
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => e.Author == _userId)
                    .Include(m => m.CommentList)
                    .Select(
                        e =>
                            new PostListItem
                            {
                                PostId = e.PostId,
                                PostTitle = e.PostTitle,
                                PostText = e.PostText,
                                CommentList = e.CommentList
                            }
                    ).ToList();

                return query.ToArray();
            }
        }
    }
}
