using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.DAL
{
    public class ChatInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ChatContext>
    {
        protected override void Seed(ChatContext context)
        {
            var users = new List<ChatUser>
            {
                new ChatUser { Name = "System" }
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var messages = new List<ChatMessage>
            {
                new ChatMessage { ChatUserID = 1, MessageBody = "Chatten er tom."},
            };

            messages.ForEach(m => context.Messages.Add(m));
            context.SaveChanges();
        }
    }
}