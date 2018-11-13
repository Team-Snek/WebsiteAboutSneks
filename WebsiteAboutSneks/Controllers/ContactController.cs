/*
 This is the Contact controller created by Matt Smith.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteAboutSneks.Models;

namespace WebsiteAboutSneks.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactInfo contact)
        {
            /*This code is optional, but it would be for sending a confirmation email to whoever submitted a contact info form.*/
            string sSubject="";
            
            if (contact.Subject==1)
            {
                sSubject = "Questions about snakes";
            }
            else if (contact.Subject==2)
            {
                sSubject = "My snake story";
            }
            else if (contact.Subject==3)
            {
                sSubject = "Snake Care";
            }
            else
            {
                sSubject = "Other";
            }

            ContactInfo.emailToAddress = contact.Email;
            ContactInfo.subject = "Thank you for contacing us!";
            ContactInfo.body = "Thank you for reaching out to us " + contact.Name + "! Our team is in the process of reviewing your message" +
                ". We will get back to you as soon as we can." + "<br /><br />" + "Subject: " + sSubject + "<br /><br />" + "Message: " + contact.Message;
            /*ContactInfo.SendEmail();*/
            if (ModelState.IsValid)
            {
                return View("Confirmation", contact);
            }
            else
            {
                return View();
            }
            
        }

    }
}