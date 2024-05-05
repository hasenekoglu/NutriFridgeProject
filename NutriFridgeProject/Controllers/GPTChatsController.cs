using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.GPTChatsModel;
using Repositories.Services.Abstract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPTChatsController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IConfiguration _configuration;

        public GPTChatsController(IMessageService messageService, IConfiguration configuration)
        {
            _messageService = messageService;
            _configuration = configuration;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _messageService.GetAll();
            
            {
                return Ok(result);
            }
            
        }


        

        [HttpGet("getbyid")]
        public IActionResult GetById(int messageId)
        {
            var result = _messageService.GetById(messageId);
            return Ok(result);
        }

       

       //burda kaldım
       //

        [HttpPost("addlist")]
        public async Task<IActionResult> AddMessage(List<MessageModel> messageModels)
        {
            var result = await _gptChatsService.AddList(gptChats, _configuration.GetConnectionString("GptApiKeyString"));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(GptChatsForUpdateDto gptChat)
        {
            var result = _gptChatsService.Update(gptChat);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

       

        [HttpDelete("delete")]
        public IActionResult Delete(GptChatsForUpdateDto gptChat)
        {
            var result = _gptChatsService.Delete(gptChat);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

      

    }
}
}
