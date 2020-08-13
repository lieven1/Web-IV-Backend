using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4Api.Models
{
    public interface IForumRepository
    {
        IEnumerable<Forum> All();
        Forum GetBy(string naam);
        void Add(Forum forum);
        void SaveChanges();
    }
}
