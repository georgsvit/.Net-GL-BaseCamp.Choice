using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatOnPage.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime SendingTime { get; set; }
        public string AuthorName { get; set; }

        public Message(string text, DateTime sendingTime, string authorName)
        {
            Text = text;
            SendingTime = sendingTime;
            AuthorName = authorName;
        }
    }
}
