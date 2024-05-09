using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.ChatsModel;
using Models.GPTChatsModel;
using Repositories.Concreate;
using Repositories.Services.Abstract;
using Repositories.Services.Concreate;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IConfiguration _configuration;

        public MessageController(IMessageService messageService, IConfiguration configuration)
        {
            _messageService = messageService;
            _configuration = configuration;
        }

        [HttpGet("getall")]
        public IActionResult GetAllMessages()
        {
            var result = _messageService.GetAll();
            
            
                return Ok(result);
        }

        [HttpGet("messageId")]
        public IActionResult GetById(int messageId)
        {
            var message = _messageService.GetById(messageId);
            if (message == null )
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPost("add")]
        public IActionResult AddMessage(MessageModel message)
        {
             _messageService.Add(message, _configuration.GetConnectionString("OpenAIKey"));
            return Ok();
        }

        [HttpPut("update")]
        public  IActionResult Update(MessageModel message)
        {
            _messageService.Update(message);
            return Ok();
        }



        [HttpDelete("delete")]
        public IActionResult Delete(int messageId)
        {
            _messageService.Delete(messageId);
            return Ok(messageId); 
        }



    }
}

