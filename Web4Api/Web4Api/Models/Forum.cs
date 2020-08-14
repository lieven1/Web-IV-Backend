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

        //public List<Gebruiker> getLeden()
        //{
        //    return ForaLidschappen.Select(fl => fl.Gebruiker).ToList();
        //}

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

        public void addPost(Post post)
        {
            if (ForaLidschappen.Any(f => f.GebruikerId == post.Poster.Id)) {
                Posts.Add(post);
            } else
            {
                throw new ArgumentException("Enkel volgers kunnen posts maken");
            }
        }
    }
}
