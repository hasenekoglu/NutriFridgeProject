using Models.ChatsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Dto;
using Models.GPTChatsModel;

namespace Repositories.Services.Abstract
{
    public interface IMessageService
    {
        IList<MessageModel> GetAll();
        MessageModel GetById(int messageId);
        void AddAsync(MessageForCreateDto messageModel);
        void Update(MessageModel messageModel);
        void Delete(int messageId);


    }
}
