using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public CustomerController(AuthenticationContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.Customers.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}