using _24HourAssignment.Models;
using _24HourAssignment.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourAssignment.WebAPI.Controllers
{
    [Authorize]
    public class ReplyController : ApiController
    {
        //"Now let's add a Get All method:"
        public IHttpActionResult Get()
        {
        ReplyService replyService = CreateReplyService();
        var replies = replyService.GetReplies();
        return Ok(replies);
        }

        //"And a Post(ReplyCreate reply) method:"
        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.CreateReply(reply))
                return InternalServerError();

            return Ok();
        }


        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }

        /// <summary>
        /// 4.08
        /// </summary>
        /// <param name="CommentId"></param>
        /// <returns></returns>
        //public IHttpActionResult GetRepliesByCommentId(int CommentId)
        //{
        //    ReplyService replyService = CreateReplyService();
        //    var reply = replyService.GetCommentById(CommentId);
        //    return Ok(reply);
        //}


        //After We have the Comment (and maybe Post) classes/services in the local, we can find replies for a specific Comment, which is attached to a specific Post.  Pick up at 4.06 after pulling Caleb/Jon's classes/services/etc

    }
}
