using Microsoft.EntityFrameworkCore;
using MyULibrary_API.Interfaces;
using MyULibrary_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyULibrary_API.Repos
{
    public class GenresRepository : IGenreRepository
    {
        private readonly MyULibraryContext _ctx;


        public GenresRepository(MyULibraryContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Genre> createGenre(Genre Genre)
        {
            await _ctx.Genres.AddAsync(Genre);
            await _ctx.SaveChangesAsync();
            return Genre;
        }

        public async Task<Genre> deleteGenre(int id)
        {
            Genre genre = await _ctx.Genres.Where(x => x.GenreId == id).FirstOrDefaultAsync();
            _ctx.Genres.Remove(genre);
            await _ctx.SaveChangesAsync(true);
            return genre;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _ctx.Genres.ToListAsync();
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await _ctx.Genres.Where(x => x.GenreId == id).FirstOrDefaultAsync();
        }

        public async Task<Genre> updateGenre(Genre Genre)
        {
            _ctx.Genres.Update(Genre);
            await _ctx.SaveChangesAsync();
            return Genre;
        }
    }
}
