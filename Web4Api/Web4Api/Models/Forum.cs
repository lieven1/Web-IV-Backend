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

        public Forum()
        {
        }

        public void addLid(Gebruiker gebruiker)
        {
            ForaLidschappen.Add(new ForumLid(this, gebruiker));
        }
    }
}
