using Chat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Chat.DAL
{
    public class ChatContext : DbContext
    {
        public ChatContext() : base("Chat")
        {
        }

        public DbSet<ChatMessage> Messages { get; set; }

        public DbSet<ChatUser> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}