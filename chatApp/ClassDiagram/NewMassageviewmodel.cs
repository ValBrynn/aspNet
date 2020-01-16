using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace chatApp.Models.Homeviewmodel
{
    public class NewMassageviewmodel
    {
        [Required]
        [Display (Name = "Receiver")]
        public String Receiver { get; set; }

        [Required]
        [Display(Name = "Titel")]
        public String Titel { get; set; }
        //[Required]
        [Display(Name = "Message")]
        public String Message { get; set; }

        [Display(Name = "MessageId")]
        public int MessageId { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "SendInfoMessage")]
        public string SendInfoMessage { get; set; }

    }
}
