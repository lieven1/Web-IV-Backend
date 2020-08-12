using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4Api.Models
{
    public class ForumLid
    {

        public int ForumId { get; set; }
        public Forum Forum { get; set; }
        public int GebruikerId { get; set; }
        public Gebruiker Gebruiker { get; set; }

        public ForumLid()
        {
        }

        public ForumLid(Forum forum, Gebruiker gebruiker)
        {
            Forum = forum;
            Gebruiker = gebruiker;
            ForumId = forum.Id;
            GebruikerId = gebruiker.Id;
        }
    }
}
