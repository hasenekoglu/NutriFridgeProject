using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.GPTChatsModel;

namespace Repositories.Abstract
{
    public interface IMessageRepository
    {
        IList<MessageModel> GetAllMessage();
        public MessageModel GetMessageById(int id);
        public void AddMessage(MessageModel messageModel);
        public void UpdateMessage(MessageModel messageModel);
        public void DeleteMessage(int id);
    }
}
