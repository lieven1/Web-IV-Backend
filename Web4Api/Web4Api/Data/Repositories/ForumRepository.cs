using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Web4Api.Models;

namespace Web4Api.Data.Repositories
{
    public class ForumRepository : IForumRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Forum> _fora;

        public ForumRepository(DbContext context)
        {
            _context = context;
            _fora = context.Fora;
        }

        public IEnumerable<Forum> Fora(string filter)
        {
            if (filter == "undefined")
            {
                return _fora.Include(f => f.Posts);
            } else
            {
                return _fora.Where(f => f.Naam.ToLower().StartsWith(filter.ToLower())).Include(f => f.Posts);
            }
        }

        public Forum GetById(int id)
        {
            return _fora.Include(f => f.ForaLidschappen).Include(f => f.Posts).SingleOrDefault(f => f.Id == id);
        }

        public Forum GetBy(string naam)
        {
            return _fora.Include(f => f.ForaLidschappen).Include(f => f.Posts).SingleOrDefault(f => f.Naam == naam);
        }

        public void Add(Forum forum)
        {
            _fora.Add(forum);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
