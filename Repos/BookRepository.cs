using Microsoft.EntityFrameworkCore;
using MyULibrary_API.Interfaces;
using MyULibrary_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyULibrary_API.Repos
{
    public class BookRepository : IBookRepository
    {
        private readonly MyULibraryContext _ctx;


        public BookRepository(MyULibraryContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Book> createBook(Book book)
        {
            await _ctx.Books.AddAsync(book);
            await _ctx.SaveChangesAsync();
            return book;
        }

        public async Task<Book> deleteBook(int id)
        {
            Book book = await _ctx.Books.Where(x => x.BookID == id).FirstOrDefaultAsync();
            _ctx.Books.Remove(book);
            await _ctx.SaveChangesAsync(true);
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _ctx.Books.ToListAsync();
        }
        public async Task<Book> GetBookById(int id)
        {
            return await _ctx.Books.Where(x => x.BookID == id).FirstOrDefaultAsync();
        }

        public async Task<Book> updateBook(Book book)
        {
            _ctx.Books.Update(book);
            await _ctx.SaveChangesAsync();
            return book;
        }
    }
}
