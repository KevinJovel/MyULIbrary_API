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
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _Role;
        public RolesController(IRoleRepository Role)
        {
            _Role = Role;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                return Ok(await _Role.GetAllRoles());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetRoleById(int Id)
        {
            try
            {
                return Ok(await _Role.GetRoleById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult> deleteRole(int Id)
        {
            try
            {
                return Ok(await _Role.deleteRole(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> createBanco([FromBody] Role Role)
        {
            try
            {
                return Ok(await _Role.createRole(Role));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> updateBanco([FromBody] Role Role)
        {
            try
            {
                return Ok(await _Role.updateRole(Role));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
