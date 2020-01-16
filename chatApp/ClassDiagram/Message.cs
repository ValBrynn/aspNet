using System;
using System.ComponentModel.DataAnnotations;

namespace chatApp.Models
{
    public class Message
    {
        [Key]
        public int msgID { get;set; }
        public string senderID { get; set; }
        [Required]
        public string receiverID { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string message{ get; set; }
        public DateTime sendTimeStample { get;set; }
        public int isRead { get; set; }
        public int isDeleted { get; set; }
    }
}
