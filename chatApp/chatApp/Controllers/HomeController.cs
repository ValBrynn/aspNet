using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using chatApp.Models;
using Microsoft.AspNetCore.Authorization;
using chatApp.Models.Homeviewmodel;
using Microsoft.AspNetCore.Identity;
using chatApp.Data;
using System.Text;

namespace chatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _userDateTime;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //Constructor
        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext userDateTime, 
            SignInManager<ApplicationUser> signInManager)
        { this._userManager= userManager;this._userDateTime = userDateTime; this._signInManager = signInManager; }
        
        //Home 
        [Authorize]
        [HttpGet]
        public IActionResult Index(Indexviewmodel model)
        {
                LoginInfo a = new LoginInfo(_userManager, _signInManager, _userDateTime);
                a.Totallogin(_userManager.GetUserId(User), model);
                a.Datelogin(_userManager.GetUserId(User), model);
                a.unReadmsg(_userManager.GetUserId(User), model);
                return View(model);
        }

       //Inbox
        [Authorize]
        [HttpGet]
        public IActionResult Inbox(InboxViewModel model)
        {
          
            LoginInfo a = new LoginInfo(_userManager, _signInManager, _userDateTime);
            a.inbox(_userManager.GetUserId(User), model);
            a.Readmsg(_userManager.GetUserId(User), model);
            a.deletedMsg(_userManager.GetUserId(User), model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Inbox(String submit, MessageDetailviewmodel model)
        {
            HttpContext.Session.Set("key", Encoding.ASCII.GetBytes(submit));
            if (submit != null)
            {
                LoginInfo a = new LoginInfo(_userManager, _signInManager, _userDateTime);
                a.msgDetails(submit, model);
                return this.RedirectToAction("MessageDetail", "Home");
            }
            else
            {
                return View();
            }
        }

        //New Message
        [Authorize]
        [HttpGet]
        public IActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMessage(NewMassageviewmodel model)
        {
            //ViewData["Message"] = "Your contact page.";
            LoginInfo a = new LoginInfo(_userManager, _signInManager, _userDateTime);
            a.send(_userManager.GetUserId(User), model);
            return View(model);
        }

        //Message detail (show title and Date/Time)
        [HttpGet]
        public ActionResult MessageDetail(MessageDetailviewmodel model)
        {
            byte[] bite;
            HttpContext.Session.TryGetValue("key", out bite);
            string someString = Encoding.ASCII.GetString(bite);
            LoginInfo a = new LoginInfo(_userManager, _signInManager, _userDateTime);
            a.msgDetails(someString, model);
            return View(model);
        }

        [HttpPost]
        public ActionResult MessageDetail(string submit2, MessageDetailviewmodel model)
        {
           HttpContext.Session.Set("msgkey", Encoding.ASCII.GetBytes(submit2));
            LoginInfo a = new LoginInfo(_userManager, _signInManager, _userDateTime);
            a.Changereadtabel(submit2, model);
           // a.msgDetails(submit, model);
            return this.RedirectToAction("TheMessage", "Home");
        }

        //Show the message
        [HttpGet]
        public ActionResult TheMessage(TheMassageviewmodel model)
        {
            byte[] bite;
            HttpContext.Session.TryGetValue("msgkey", out bite);
            string someString = Encoding.ASCII.GetString(bite);
            LoginInfo a = new LoginInfo(_userManager, _signInManager, _userDateTime);
            a.Themsg(someString, model);

            return View(model);
        }

        [HttpPost]
        public ActionResult TheMessage()
        {
            byte[] bite;
            HttpContext.Session.TryGetValue("msgkey", out bite);
            string someString = Encoding.ASCII.GetString(bite);
            LoginInfo a = new LoginInfo(_userManager, _signInManager, _userDateTime);
            a.Changedeletedtabel(someString);
            return View();
        }

        //ERROR if any goes wrong
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
