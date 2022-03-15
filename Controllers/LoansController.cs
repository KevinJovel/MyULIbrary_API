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
    public class LoansController : ControllerBase
    {
        private readonly ILoansRepository _loan;
        public LoansController(ILoansRepository loan)
        {
            _loan = loan;
        }
        [HttpPost]
        public async Task<ActionResult> createLoan([FromBody] LoanHistory loan)
        {
            try
            {
                return Ok(await _loan.createLoan(loan));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> getAllBooks()
        {
            try
            {
                return Ok(await _loan.getAllLoans());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<ActionResult> returnLoan([FromBody] LoanHistory loan)
        {
            try
            {
                return Ok(await _loan.returnLoan(loan));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
