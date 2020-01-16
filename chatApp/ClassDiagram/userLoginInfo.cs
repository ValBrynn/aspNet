using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace chatApp.Models
{

    public class userLoginInfo
    {
        
        public String Id{ get; set; }
        [Key]
        public DateTime LogInDate { get; set; }
    }
}
