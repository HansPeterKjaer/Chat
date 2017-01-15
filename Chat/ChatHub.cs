using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using Chat.Models;
using Newtonsoft.Json.Serialization;

namespace Chat
{
    public class ChatHub : Hub
    {
        public void SendMessage(ChatMessage message)
        {
            var json = JsonConvert.SerializeObject(message, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            Clients.All.broadcastMessage(json);
        }
    }
}