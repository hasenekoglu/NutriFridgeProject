using Microsoft.EntityFrameworkCore;
using Models;
using Models.GPTChatsModel;
using Repositories.Abstract;
using Repositories.Context;

namespace Repositories.Concreate;

public class MessageRepository : IMessageRepository
{
    private readonly ApplicationDbContext _context;

    public MessageRepository(ApplicationDbContext context)
    {
        _context = new ApplicationDbContext();
    }


    public IList<MessageModel> GetAllMessage()
    {

        return _context.Set<MessageModel>().ToList();
    }

    public IList<MessageModel> GetAllMessagesByChatId(int chatId)
    {
        var result = (from message in _context.Messages where message.ChatId == chatId select new MessageModel
        {
            Id = message.Id,
            ChatId = message.ChatId,
            SendBy = message.SendBy,
            ResponseId = message.ResponseId,
            UserInput = message.UserInput
        }).ToList();

        return result;
    }

    public MessageModel GetMessageById(int id)
    {
        return _context.Messages.FirstOrDefault(m => m.Id == id);
    }

    public void AddMessage(MessageModel messageModel)
    {
        _context.Messages.Add(messageModel);
        _context.SaveChanges();
    }

    public void UpdateMessage(MessageModel messageModel)
    {
        _context.Entry(messageModel).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteMessage(int id)
    {
        var message = _context.Messages.Find(id);
        if (message != null)
        {
            _context.Messages.Remove(message);
            _context.SaveChanges();
        }
    }

   
}