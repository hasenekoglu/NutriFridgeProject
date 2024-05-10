using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Models.Dto;
using Models.GPTChatsModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Repositories.Abstract;
using Repositories.Concreate;
using Repositories.Services.Abstract;

namespace Repositories.Services.Concreate
{
    public class MessageService : IMessageService
    {
        protected readonly IMessageRepository _messageRepository;
        protected readonly IConfiguration _configuration;
        protected readonly IChatService _chatService;

        public MessageService(IMessageRepository messageRepository, IConfiguration configuration)
        {
            _messageRepository = messageRepository;
            _configuration = configuration;
        }

        public IList<MessageModel> GetAll()
        {
            return _messageRepository.GetAllMessage();
        }

        public MessageModel GetById(int messageId)
        {
            return _messageRepository.GetMessageById(messageId);
        }

        public async Task AddAsync(MessageForCreateDto message)
        {   var oldMessages = _messageRepository.GetAllMessagesByChatId(message.ChatId);
            //promp eklencek
            //string prompt = message.UserInput != "string" ? message.UserInput :
            //    $"Act as a chatbot. You are a chatbot designed to help humans in emergency. Current emergency reported is {"postDetails.Title"}." +
            //    $"Note that user's height is {""}, gender is {"postDetails.Gender"}, blood type is {"postDetails.BloodType"}. " +
            //    $"User is allergic to {"""postDetails.Allergies"""}, and has {"postDetails.Diseases"} and is {"postDetails.Age"} years old." +
            //    " Suggest possible actions. Start first message with \"Hi, I'm ResQ Helpbot!\". " +
            //    " And keep your messages short and accurate as user is probably in a dangerous condition and in a hurry.";
            string prompt = message.UserInput;
            var model = "gpt-3.5-turbo";
            var maxTokens = 200;
            var messages = new List<object>();
            messages.Add(new
            {
                role = "user",
                content = prompt,
            });

            foreach (var oldMessage in oldMessages)
            {
                messages.Add(new
                {
                    role = "user",
                    content = oldMessage.UserInput,
                });
            }
            using (var client = new HttpClient())
            {
                var apikey = _configuration.GetConnectionString("OpenAIKey");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);
                var requestBody = new
                {
                    messages = messages,
                    model = model,
                    max_tokens = maxTokens,
                    temperature = 0.7,
                };

                var requestContent = JsonConvert.SerializeObject(requestBody);
                var responseContent = client
                    .PostAsync("https://api.openai.com/v1/chat/completions",
                        new StringContent(requestContent, Encoding.UTF8, "application/json")).Result.Content
                    .ReadAsStringAsync().Result;

                dynamic response = JObject.Parse(responseContent);

                var userMessage = new MessageModel()
                {
                    UserInput = message.UserInput != "string" ? message.UserInput : null,
                    ResponseId = response.id.ToString(),
                    
                   // Usage = response.usage.ToString(),
                    UserId = message.UserId,
                    ChatId = message.ChatId,
                    SendBy= "User"
                };
                if (message.UserInput!= null)
                    _messageRepository.AddMessage(userMessage);

                var result = new MessageModel()
                {
                    UserInput = response.choices[0].message.content,
                  
                    ResponseId = response.id.ToString(),
                  
                    
                    UserId = message.UserId,
                    ChatId= message.ChatId,
                    SendBy = "Gpt"
                };
                _messageRepository.AddMessage(result);
            }


        }

        public void Update(MessageModel messageModel)
        {
            _messageRepository.UpdateMessage(messageModel);
        }

        public void Delete(int messageId)
        {
            _messageRepository.DeleteMessage(messageId);
        }
    }
}
