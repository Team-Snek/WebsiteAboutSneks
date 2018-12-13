using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteAboutSneks.Models
{
    [Table("Snake")]
    public class Snake
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SnakeID { get; set; }
        
        public int OwnerID { get; set; }
        public virtual Owner Owner { get; set; }

        [DisplayName("Snake Name")]
        public string SnakeName { get; set; }

        public int BreedID { get; set; }
        public virtual Breed Breed { get; set; }

        public int SnakeAge { get; set; }
        public string SnakeTalk { get; set; }
    }
}