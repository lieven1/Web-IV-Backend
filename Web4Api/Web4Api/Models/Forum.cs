using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4Api.Models
{
    public class Forum
    {
        public int Id { get; set; }

        public string Naam { get; set; }

        public List<ForumLid> ForaLidschappen { get; set; }

        public List<Post> Posts { get; set; }

        public Forum()
        {
        }

        public bool heeftLid(Gebruiker gebruiker)
        {
            if (gebruiker != null)
            {
                return ForaLidschappen.Any(fl => fl.GebruikerId == gebruiker.Id);
            }
            return false;
        }

        public void addLid(Gebruiker gebruiker)
        {
            ForaLidschappen.Add(new ForumLid(this, gebruiker));
        }
    }
}
