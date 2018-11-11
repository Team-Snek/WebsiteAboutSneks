using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace WebsiteAboutSneks.Models
{
    public class ContactInfo
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select a subject")]
        public int Subject { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        public string Message { get; set; }

        public ContactInfo()
        {

        }

        //This is all the code to send an email to confirmation email to the user

        static string smtpAddress = "smtp.gmail.com";
        static int portNumber = 587;
        static bool enableSSL = true;
        private static string emailFromAddress = "**********@Gmail.com"; //Sender Email Address  
        private static string password = "**********"; //Sender Password  
        public static string emailToAddress = "receiver@gmail.com"; //Receiver Email Address  
        public static string subject = "Hello";
        public static string body = "Hello, This is Email sending test using gmail.";
        static void Main(string[] args)
        {
            SendEmail();
        }
        public static void SendEmail()
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }

            }
        }
    }
}
