using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.GPTChatsModel;

namespace Models.ChatsModel
{
    public class Chat
    {
        public int Id { get; set; }
        public DateTime CreatedAd { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        
        //public Food Food { get; set; }
        //public Material Material { get; set; }

        public virtual ICollection<MessageModel> Messages { get; set; }


    }
}
