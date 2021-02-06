using _24HourAssignment.Models;
using _24HourAssignment.Services;
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

            return Ok;
        }


        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetCommentId());
            var replyService = new ReplyService(commentId);
            return replyService;
        }

    }
}
