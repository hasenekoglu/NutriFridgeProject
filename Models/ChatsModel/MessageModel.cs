using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ChatsModel;


namespace Models.GPTChatsModel
{
    public class MessageModel 
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public int ChatId  { get; set; }
        public string UserInput { get; set; }
        public string ResponseId { get; set; }
        public string SendBy { get; set; }

        public virtual Chat Chat { get; set; }

        // public int UserId { get; set; }
        public virtual User User { get; set; }

        public MessageModel()
        {
            
        }

        public MessageModel(int id, int userId, int chatId, string userInput, string responseId)
        {
            Id = id;
            UserId = userId;
            ChatId = chatId;
            UserInput = userInput;
            ResponseId = responseId;
        }
    }

    
}
