using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4Api.Models
{
    public interface IPostRepository
    {
        IEnumerable<Post> Posts(Forum forum);
        Post GetById(int id);
        void Add(Post post);
        void Delete(Post post);
        void SaveChanges();
    }
}
