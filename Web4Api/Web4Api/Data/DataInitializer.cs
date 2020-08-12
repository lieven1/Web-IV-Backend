using Microsoft.AspNetCore.Identity;
using Web4Api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Web4Api.Data
{
    public class DataInitializer
    {
        private readonly DbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(DbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Gebruiker gebruiker1 = new Gebruiker { UserName = "peterpan", Email = "peterpan@gmail.be", FirstName = "Peter", LastName = "Pan" };
                _dbContext.Gebruikers.Add(gebruiker1);
                await CreateUser(gebruiker1.Email, "P@ssword1234");
                Gebruiker gebruiker2 = new Gebruiker { UserName = "alpacino", Email = "al@gmail.be", FirstName = "Al", LastName = "Pacino" };
                _dbContext.Gebruikers.Add(gebruiker2);
                await CreateUser(gebruiker2.Email, "P@ssword1234");

                Forum forum1 = new Forum { Naam = "Fotografie" };
                Forum forum2 = new Forum { Naam = "Paleontologie" };
                Forum forum3 = new Forum { Naam = "Astrografie" };
                _dbContext.Fora.Add(forum1);
                _dbContext.Fora.Add(forum2);
                _dbContext.Fora.Add(forum3);

                _dbContext.Forumleden.Add(new ForumLid(forum1, gebruiker1));
                _dbContext.Forumleden.Add(new ForumLid(forum2, gebruiker2));
                _dbContext.Forumleden.Add(new ForumLid(forum3, gebruiker1));
                _dbContext.Forumleden.Add(new ForumLid(forum3, gebruiker2));

                _dbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}

