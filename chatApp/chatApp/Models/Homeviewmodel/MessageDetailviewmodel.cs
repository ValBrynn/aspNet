using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace chatApp.Models.Homeviewmodel
{
    public class MessageDetailviewmodel
    {
        [Display (Name = "sender")]
        public List<Message> getMsg2 { get; set; }

        [Display(Name = "sender")]
        public DateTime sendTimeStample { get; set; }
    }
}
