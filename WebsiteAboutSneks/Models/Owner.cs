using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteAboutSneks.Models
{
    [Table("Owner")]
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerID { get; set; }

        [DisplayName("First Name")]
        public string OwnerFirstName { get; set; }

        [DisplayName("Last Name")]
        public string OwnerLastName { get; set; }

        [DisplayName("Age")]
        public int? OwnerAge { get; set; }
    }
}