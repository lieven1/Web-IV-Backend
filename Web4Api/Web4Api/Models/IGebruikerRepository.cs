using System.Collections.Generic;

namespace Web4Api.Models
{
    public interface IGebruikerRepository
    {
        IEnumerable<Gebruiker> All();
        Gebruiker GetBy(string email);
        void Add(Gebruiker gebruiker);
        void SaveChanges();
    }
}