using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Chat.DAL;
using Chat.Models;

namespace Chat.Controllers.API
{
    public class ChatUsersController : ApiController
    {
        private ChatContext db = new ChatContext();

        // GET: api/ChatUsers/5
        [ResponseType(typeof(ChatUser))]
        public IHttpActionResult GetChatUser(int id)
        {
            ChatUser chatUser = db.Users.Find(id);
            if (chatUser == null)
            {
                return NotFound();
            }

            return Ok(chatUser);
        }

        // POST: api/ChatUsers
        [ResponseType(typeof(ChatUser))]
        public IHttpActionResult PostChatUser(ChatUser chatUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(chatUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chatUser.ID }, chatUser);
        }
    }
}