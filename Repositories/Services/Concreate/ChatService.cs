using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Models.ChatsModel;
using OpenAI.Interfaces;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels.ResponseModels;
using Repositories.Concreate;
using Repositories.Services.Abstract;

namespace Repositories.Services.Concreate
{
    public class ChatService: IChatService
    {
        protected readonly ChatRepository _chatRepository;

        public ChatService(ChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public IList<Chat> GetAll()
        {
            return _chatRepository.GetAllChats();
        }

        public Chat GetById(int chatId)
        {
            return _chatRepository.GetChatById(chatId);
        }

        public void Add(Chat chat)
        {
            _chatRepository.AddChat(chat);
        }

        public void Update(Chat chat)
        {
            _chatRepository.UpdateChat(chat);
        }

        public void Delete(int chatId)
        {
            _chatRepository.DeleteChat(chatId);
        }
    }
}
