using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteAboutSneks.Models
{
    public class Snake
    {
        [Key]
        public int snakeID { get; set; }
        public string snakeName { get; set; }
        public string ownerName { get; set; }
        public string snakeBreed { get; set; }
        public string snakeAge { get; set; }
        public string snakeTalk { get; set; }
        public string linkToPic { get; set; }

        public Snake()
        {

        }

        public Snake(int id, string snakename, string ownername, string breed, string age, string comments, string link)
        {
            this.snakeID = id;
            this.snakeName = snakename;
            this.ownerName = ownername;
            this.snakeBreed = breed;
            this.snakeAge = age;
            this.snakeTalk = comments;
            this.linkToPic = link;
        }
    }
}