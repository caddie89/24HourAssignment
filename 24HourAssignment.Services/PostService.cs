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
        // GET by ID
        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Include(m => m.CommentList)
                    .Single(e => e.PostId == id && e.Author == _userId);
                return
                    new PostDetail
                    {
                        Author = entity.Author,
                        PostId = entity.PostId,
                        PostTitle = entity.PostTitle,
                        PostText = entity.PostText,
                        CommentList = entity.CommentList
                    };
            }
        }
        // PUT
        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.PostId == model.PostId && e.Author == _userId);

                entity.PostTitle = model.PostTitle;
                entity.PostText = model.PostText;

                return ctx.SaveChanges() == 1;
            }
        }
        // DELETE
        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.PostId == postId && e.Author == _userId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
