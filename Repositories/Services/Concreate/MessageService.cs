using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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
        protected readonly IChatService _chatService;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IList<MessageModel> GetAll()
        {
            return _messageRepository.GetAllMessage();
        }

        public MessageModel GetById(int messageId)
        {
            return _messageRepository.GetMessageById(messageId);
        }

        public void Add(MessageModel messageModel, string apiKey)
        {
            var oldMessages = _messageRepository.GetAllMessagesByChatId(messageModel.ChatId);
            string prompt = messageModel.UserInput != "string" ? messageModel.UserInput :
                $"Act as a chatbot. You are a chatbot designed to help humans in emergency. Current emergency reported is {"postDetails.Title"}." +
                $"Note that user's height is {""}, gender is {"postDetails.Gender"}, blood type is {"postDetails.BloodType"}. " +
                $"User is allergic to {"""postDetails.Allergies"""}, and has {"postDetails.Diseases"} and is {"postDetails.Age"} years old." +
                " Suggest possible actions. Start first message with \"Hi, I'm ResQ Helpbot!\". " +
                " And keep your messages short and accurate as user is probably in a dangerous condition and in a hurry.";
            var model = "gpt-3.5-turbo";
            var maxTokens = 200;
            var messages = new List<object>();
            messages.Add(new
            {
                role = "User",
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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                var requestBody = new
                {
                    messages = messages,
                    model = model,
                    max_tokens = maxTokens,
                    temperature = 0.7,
                };

                var requestContent = JsonConvert.SerializeObject(requestBody);
                var responseContent =  client.PostAsync("https://api.openai.com/v1/chat/completions", new StringContent(requestContent, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
               
                dynamic response = JObject.Parse(responseContent);

                var userMessage = new MessageModel()
                {
                    UserInput = messageModel.UserInput != "string" ? messageModel.UserInput : null,
                    ResponseId = response.id.ToString(),
                    
                   // Usage = response.usage.ToString(),
                    UserId = messageModel.UserId,
                    ChatId = messageModel.ChatId,
                    SendBy= "User"
                };
                if (messageModel.UserInput!= null)
                    _messageRepository.AddMessage(messageModel);

                var result = new MessageModel()
                {
                    UserInput = response.choices[0].message.content,
                  
                    ResponseId = response.id.ToString(),
                  
                    
                    UserId = messageModel.UserId,
                    ChatId= messageModel.ChatId,
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
