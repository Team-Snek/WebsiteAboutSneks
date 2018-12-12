using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteAboutSneks.Models
{
    [Table("Answers")]
    public class Answers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerID { get; set; }

        public int QuestionID {get;set;}
        public virtual Questions Questions { get; set; }

        public string AnswerText { get; set; }

    }
}