using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteAboutSneks.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage ="Please enter your first name")]
        public string UserFirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter your last name")]
        public string UserLastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress]
        public string UserEmail { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }
    }
}