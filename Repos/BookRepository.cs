using Microsoft.EntityFrameworkCore;
using MyULibrary_API.DTOs;
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

        public async Task<IEnumerable<BookDTo>> GetAllBooks()
        {
            List<BookDTo> lista = await (from book in _ctx.Books
                                        join genre in _ctx.Genres
                                        on book.GenreId equals genre.GenreId
                                       select new BookDTo
                                       {
                                           BookID = book.BookID,
                                           GenreId = genre.GenreId,
                                           Author = book.Author,
                                           GenreName = genre.Name,
                                           PublishedYear = book.PublishedYear,
                                           Stock = book.Stock,
                                           Title = book.Title,
                                       }).ToListAsync();
            return lista;
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
