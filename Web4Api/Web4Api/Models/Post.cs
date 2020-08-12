using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4Api.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Inhoud { get; set; }

        public int likes { get; set; }

        public int dislikes { get; set; }

        public Forum Forum { get; set; }

        public Post()
        {
        }
    }
}
