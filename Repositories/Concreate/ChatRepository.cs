using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.ChatsModel;
using Models.GPTChatsModel;
using Repositories.Abstract;
using Repositories.Context;

namespace Repositories.Concreate
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _context;

        public ChatRepository(ApplicationDbContext context)
        {
            _context = new ApplicationDbContext();
        }


        public IList<Chat> GetAllChats()
        {

            return _context.Set<Chat>().ToList();
        }

        public Chat GetChatById(int id)
        {
            return _context.Chats.FirstOrDefault(m => m.Id == id);
        }

        public void AddChat(Chat chat)
        {
            _context.Chats.Add(chat);
            _context.SaveChanges();
        }

        public void UpdateChat(Chat chat)
        {
            _context.Entry(chat).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteChat(int id)
        {
            var chat = _context.Chats.Find(id);
            if (chat != null)
            {
                _context.Chats.Remove(chat);
                _context.SaveChanges();
            }
        }
    }
}
