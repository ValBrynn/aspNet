using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using chatApp.Models;
using chatApp.Models.AccountViewModels;
using chatApp.Services;
using chatApp.Data;
using chatApp.Models.Homeviewmodel;
using System.Collections;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace chatApp.Models
{
    public class InfoHandler
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _userDateTime;

        private readonly SignInManager<ApplicationUser> _signInManager;

        //Constructor
        public InfoHandler(
           UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext userDateTime
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userDateTime = userDateTime;
        }

        //Get the UserID and Date/Time when a user logs in 
        public async Task<bool> Login(LoginViewModel model, string returnUrl)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {       
                var userID = await _userManager.FindByEmailAsync(model.Email);
                var userDateTimeInfo = new userLoginInfo { LogInDate = DateTime.Now };
                String usrDT = userID.Id;
                userDateTimeInfo.Id = usrDT;
                _userDateTime.Add(userDateTimeInfo);
                _userDateTime.SaveChanges();
                return true;
            }

            // If we got this far, something failed, redisplay form
            return false;
        }

        public async Task<bool> reg(RegisterViewModel model, string returnUrl)
        {
                var userID = await _userManager.FindByEmailAsync(model.Email);
                var userDateTimeInfo = new userLoginInfo { LogInDate = DateTime.Now };
                String usrDT = userID.Id;
                userDateTimeInfo.Id = usrDT;
                _userDateTime.Add(userDateTimeInfo);
                _userDateTime.SaveChanges();
                return true;     
        }

        //Get users lastest login Date/Time 
        public void Datelogin(String user, Indexviewmodel model)
        {
                var save = _userDateTime.userDateTimeInfo.LastOrDefault(g => g.Id == user);
                model.Datum = save.LogInDate;
            
        }

        //Get users total login in a month 
        public void Totallogin(String user, Indexviewmodel model)
        {
            int total = 0;

            var save = _userDateTime.userDateTimeInfo.Where(g => g.Id == user).ToList();
            foreach (userLoginInfo saves in save)
            {
                if (saves.LogInDate.Month.Equals(DateTime.Now.Month))
                {
                    total++;
                }
                
            }
            model.TotalLogin = total;
        }

        //Get users unread messages
        public void unReadmsg(String user, Indexviewmodel model)
        {
            int total = 0;

            var FakeunRead = _userDateTime.Users.LastOrDefault(g => g.Id == user);
            var unRead = _userDateTime.msg.Where(f => f.receiverID == FakeunRead.Email);
            foreach (var unRead_ in unRead)
            {
                if (unRead_.isRead==1)
                {
                    total++;
                }

            }
            model.Message = total;
        }

        //Get user unread messages
        public void Readmsg(String user, InboxViewModel model)
        {
            int total = 0;

            var FakeunRead = _userDateTime.Users.LastOrDefault(g => g.Id == user);
            var unRead = _userDateTime.msg.Where(f => f.receiverID == FakeunRead.Email);
            foreach (var unRead_ in unRead)
            {
                if (unRead_.isRead == 0)
                {
                    total++;
                }

            }
            model.Read = total;
        }

        //Get users deleted messages
        public void deletedMsg(String user, InboxViewModel model)
        {
            int total = 0;

            var deletedMsg = _userDateTime.Users.LastOrDefault(g => g.Id == user);
            var deletedMessage = _userDateTime.msg.Where(f => f.receiverID == deletedMsg.Email);
            foreach (var deletedMsg_ in deletedMessage)
            {
                if (deletedMsg_.isDeleted == 1)
                {
                    total++;
                }

            }
            model.Deleted = total;
        }

        //Add new message (New Message)
        public void send(String user, NewMassageviewmodel model)
        { 
            var reciver = model.Receiver;
            var correctemail = _userDateTime.Users.LastOrDefault(g => g.Email == reciver);
            var sender = _userDateTime.Users.LastOrDefault(g => g.Id == user);
            if (correctemail!=null)
            {
                var newmess = new Message();
                newmess.title = model.Titel;
                newmess.receiverID= reciver;
                newmess.senderID = sender.Email;
                newmess.message = model.Message;
                newmess.isRead = 1;
                newmess.sendTimeStample = DateTime.Now;
                _userDateTime.Add(newmess);
                _userDateTime.SaveChanges();
                
                var save2 = _userDateTime.msg.LastOrDefault(g => g.receiverID == reciver);       
                model.MessageId=save2.msgID;
                model.Date = DateTime.Now;
                model.SendInfoMessage = "Message number " + model.MessageId + "  to: " + reciver + " , " + model.Date;
            }

        }

        //Get list of senders
        public void inbox(String user, InboxViewModel model)
        {
            var u = _userDateTime.Users.LastOrDefault(m => m.Id == user);
            List<Message> msg = new List<Message>();
            List<Message> myMessage = _userDateTime.msg.Where(g => g.receiverID == u.Email && g.isDeleted==0).ToList();
            List<String> newList = new List<string>();
                foreach (Message rececivedMsg in myMessage)
                {

                if (!newList.Contains(rececivedMsg.senderID))
                {
                    newList.Add(rececivedMsg.senderID);
                    msg.Add(rececivedMsg);
                }

                }
           
            model.getMsg = msg;
        }

        //Get message details like title and Date/Time
       public void msgDetails(String user, MessageDetailviewmodel model)
        {
 
            List<Message> myMessage = _userDateTime.msg.Where(g => g.senderID == user && g.isDeleted==0).ToList();            
                    model.getMsg2 = myMessage;
        }

        //Show the Messages
        public void Themsg(String messageId, TheMassageviewmodel model)
        {

            int msgid = Convert.ToInt32(Convert.ToDouble(messageId));
            var myMessage = _userDateTime.msg.LastOrDefault(g => g.msgID== msgid);         
            model.getMsg = myMessage.message;
        }

        //Check if a message is Read
        public void Changereadtabel(String user, MessageDetailviewmodel model)
        {
            
            int msgid = Convert.ToInt32(Convert.ToDouble(user));
            var MessageId = _userDateTime.msg.LastOrDefault(g => g.msgID == msgid);
            MessageId.isRead = 0;
            _userDateTime.SaveChanges();

        }

        //Check if a message is deleted
        public void Changedeletedtabel(String user)
        {

            int msgid = Convert.ToInt32(Convert.ToDouble(user));
            var MessageId = _userDateTime.msg.LastOrDefault(g => g.msgID == msgid);
            MessageId.isDeleted =1;
            _userDateTime.SaveChanges();

        }
    }
}

