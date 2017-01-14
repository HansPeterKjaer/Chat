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
    public class ChatMessagesController : ApiController
    {
        private ChatContext db = new ChatContext();

        // GET: api/ChatMessages
        public IQueryable<ChatMessage> GetMessages()
        {
            return db.Messages;
        }

        // POST: api/ChatMessages
        [ResponseType(typeof(ChatMessage))]
        public IHttpActionResult PostChatMessage(ChatMessage chatMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Messages.Add(chatMessage);
            db.SaveChanges();

            chatMessage.ChatUser = db.Users.Find(chatMessage.ChatUserID);

            return CreatedAtRoute("DefaultApi", new { id = chatMessage.ID }, chatMessage);
        }
    }
}