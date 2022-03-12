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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _User;
        public UsersController(IUserRepository User)
        {
            _User = User;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _User.GetAllUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            try
            {
                return Ok(await _User.GetUserById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult> deleteUser(int Id)
        {
            try
            {
                return Ok(await _User.deleteUser(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> createBanco([FromBody] User User)
        {
            try
            {
                return Ok(await _User.createUser(User));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> updateBanco([FromBody] User User)
        {
            try
            {
                return Ok(await _User.updateUser(User));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
