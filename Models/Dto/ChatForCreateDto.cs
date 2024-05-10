using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dto
{
    public class ChatForCreateDto
    {
        public int Id { get; set; }
        public DateTime CreatedAd { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
