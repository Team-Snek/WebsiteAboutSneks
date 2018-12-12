using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteAboutSneks.Models
{
    [Table("Breed")]
    public class Breed
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BreedID { get; set; }

        [DisplayName("Breed")]
        public string BreedDescription { get; set; }
    }
}