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

        public IEnumerable<Forum> All()
        {
            return _fora.Include(f => f.Posts).ToList();
        }

        public Forum GetBy(string naam)
        {
            return _fora.Include(f => f.ForaLidschappen).SingleOrDefault(f => f.Naam == naam);
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
