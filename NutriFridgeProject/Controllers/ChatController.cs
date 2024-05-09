using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ChatsModel;
using Repositories.Services.Abstract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public IActionResult GetAllChats()
        {
            var chats = _chatService.GetAll();
            return Ok(chats);
        }

        [HttpGet("{chatId}")]
        public IActionResult GetChatById(int chatId)
        {
            var chat = _chatService.GetById(chatId);
            if (chat == null)
            {
                return NotFound();
            }
            return Ok(chat);
        }

        [HttpPost("add")]
        public IActionResult AddChat(Chat chat)
        {
            _chatService.Add(chat);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateChat(Chat chat)
        {
            _chatService.Update(chat);
            return Ok();
        }

        [HttpDelete("delete/{chatId}")]
        public IActionResult DeleteChat(int chatId)
        {
            _chatService.Delete(chatId);
            return Ok();
        }
    }
}
