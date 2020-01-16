using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace chatApp.Models.Homeviewmodel
{
    public class Indexviewmodel
    {
    
        [Display (Name = "Date")]
        public DateTime Datum { get; set; }

        [Display(Name = "Login")]
        public int TotalLogin { get; set; }

        [Display(Name = "Message")]
        public int Message { get; set; }
    }
}
