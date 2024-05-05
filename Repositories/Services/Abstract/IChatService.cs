using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ChatsModel;

namespace Repositories.Services.Abstract
{
    public interface IChatService
    {
        IList<Chat> GetAll();
        Chat GetById(int chatId);
        void Add(Chat chat);
        void Update(Chat chat);
        void Delete(int chatId);
    }
}
