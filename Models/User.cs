using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ChatsModel;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<Chat> Chats { get; set; }
        public User() { }

        public User(int id, string name, string surname, string email, string password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }
    }
}
