using MyULibrary_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyULibrary_API.Interfaces
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllGenres();
        Task<Genre> GetGenreById(int id);
        Task<Genre> createGenre(Genre Genre);
        Task<Genre> updateGenre(Genre Genre);
        Task<Genre> deleteGenre(int id);
    }
}
