using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

namespace Web4Api.Data.Repositories
{
    public class PostRepository : IPostRepository
    {

        private readonly DbContext _context;
        private readonly DbSet<Post> _posts;

        public PostRepository(DbContext context)
        {
            _context = context;
            _posts = context.Posts;
        }

        public Post GetById(int id)
        {
            return _posts.Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Post> Posts(Forum forum)
        {
            return _posts.Include(p => p.Forum).Where(p => p.Forum.Id == forum.Id).Include(p => p.Poster).Include(p => p.RepliesTo);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
