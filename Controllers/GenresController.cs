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
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genre;
        public GenresController(IGenreRepository genre)
        {
            _genre = genre;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            try
            {
                return Ok(await _genre.GetAllGenres());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetGenreById(int Id)
        {
            try
            {
                return Ok(await _genre.GetGenreById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult> deleteGenre(int Id)
        {
            try
            {
                return Ok(await _genre.deleteGenre(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> createGenre([FromBody] Genre genre)
        {
            try
            {
                return Ok(await _genre.createGenre(genre));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> updateGenre([FromBody] Genre genre)
        {
            try
            {
                return Ok(await _genre.updateGenre(genre));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
