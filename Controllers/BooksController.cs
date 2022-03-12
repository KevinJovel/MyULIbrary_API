using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyULibrary_API.Interfaces;
using MyULibrary_API.Models;
using System;
using System.Threading.Tasks;

namespace MyULibrary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _book;
        public BooksController(IBookRepository book)
        {
            _book = book;
        }

        [HttpGet]
        public async Task<IActionResult> getAllBooks()
        {
            try
            {
                return Ok(await _book.GetAllBooks());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> getBookById(int Id)
        {
            try
            {
                return Ok(await _book.GetBookById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult> deleteBook(int Id)
        {
            try
            {
                return Ok(await _book.deleteBook(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> createBanco([FromBody] Book book)
        {
            try
            {
                return Ok(await _book.createBook(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> updateBanco([FromBody] Book book)
        {
            try
            {
                return Ok(await _book.updateBook(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
