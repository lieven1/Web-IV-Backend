using Microsoft.EntityFrameworkCore;
using Web4Api.Models;
using System.Linq;
using System.Collections.Generic;

namespace Web4Api.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Gebruiker> _gebruikers;

        public GebruikerRepository(DbContext dbContext)
        {
            _context = dbContext;
            _gebruikers = dbContext.Gebruikers;
        }

        public IEnumerable<Gebruiker> All()
        {
            return _gebruikers.ToList();
        }

        public Gebruiker GetBy(string email)
        {
            return _gebruikers.SingleOrDefault(g => g.Email == email);
        }

        public void Add(Gebruiker gebruiker)
        {
            _gebruikers.Add(gebruiker);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
