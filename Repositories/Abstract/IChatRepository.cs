using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ChatsModel;

namespace Repositories.Abstract
{
    public interface IChatRepository
    {
        IList<Chat> GetAllChats();
        public Chat GetChatById(int id);
        public void AddChat(Chat chat);
        public void UpdateChat(Chat chat);
        public void DeleteChat(int id);
    }
}
