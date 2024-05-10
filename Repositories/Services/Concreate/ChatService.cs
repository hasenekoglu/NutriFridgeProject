using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Models.ChatsModel;
using Models.Dto;
using OpenAI.Interfaces;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels.ResponseModels;
using Repositories.Abstract;
using Repositories.Concreate;
using Repositories.Services.Abstract;

namespace Repositories.Services.Concreate
{
    public class ChatService: IChatService
    {
        protected readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
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

        public void Add(ChatForCreateDto chat)
        {
            var chatToCreate = new Chat(chat.Id, chat.Title, chat.Description, chat.UserId);
            _chatRepository.AddChat(chatToCreate);
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
