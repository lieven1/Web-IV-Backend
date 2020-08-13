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
                Gebruiker gebruiker3 = new Gebruiker { UserName = "tchai", Email = "tchaikovsky@gmail.be", FirstName = "Pyotr", LastName = "Tchaikovsky" };
                _dbContext.Gebruikers.Add(gebruiker3);
                await CreateUser(gebruiker3.Email, "P@ssword1234");

                Forum forum1 = new Forum { Naam = "Fotografie" };
                Forum forum2 = new Forum { Naam = "Paleontologie" };
                Forum forum3 = new Forum { Naam = "Astrografie" };
                Forum forum4 = new Forum { Naam = "Muziek" };
                _dbContext.Fora.Add(forum1);
                _dbContext.Fora.Add(forum2);
                _dbContext.Fora.Add(forum3);
                _dbContext.Fora.Add(forum4);

                _dbContext.Forumleden.Add(new ForumLid(forum1, gebruiker1));
                _dbContext.Forumleden.Add(new ForumLid(forum2, gebruiker2));
                _dbContext.Forumleden.Add(new ForumLid(forum3, gebruiker1));
                _dbContext.Forumleden.Add(new ForumLid(forum3, gebruiker2));
                _dbContext.Forumleden.Add(new ForumLid(forum4, gebruiker1));
                _dbContext.Forumleden.Add(new ForumLid(forum4, gebruiker3));

                Post post1 = new Post { Forum = forum1, Poster = gebruiker1, Inhoud = "Look at my funny cat photos!!! uwu" };
                Post post2 = new Post { Forum = forum2, Poster = gebruiker2, Inhoud = "[Insert overly long comment about why dinosaur A would beat dinosaur B in a hypothetical fight]" };
                Post post3 = new Post { Forum = forum3, Poster = gebruiker2, Inhoud = "Blablabla black holes blablabla Einstein blablabla look at how smart I am" };
                Post post4 = new Post { Forum = forum4, Poster = gebruiker1, Inhoud = "I think A is better than B" };
                Post post5 = new Post { Forum = forum4, Poster = gebruiker3, RepliesTo = post4, Inhoud = "Your opinion is invalid because clearly B is better than A." };
                Post post6 = new Post { Forum = forum4, Poster = gebruiker1, RepliesTo = post5, Inhoud = "[Insert generic insult]" };
                _dbContext.Posts.Add(post1);
                _dbContext.Posts.Add(post2);
                _dbContext.Posts.Add(post3);
                _dbContext.Posts.Add(post4);
                _dbContext.Posts.Add(post5);
                _dbContext.Posts.Add(post6);

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

