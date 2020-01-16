using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace chatApp.Models.Homeviewmodel
{
    public class InboxViewModel
    {
        [Display(Name = "email")]
        public List<Message> getMsg { get; set; }

        [Display(Name = "Read")]
        public int Read { get; set; }

        [Display(Name = "Deleted")]
        public int Deleted { get; set; }
    }
}
