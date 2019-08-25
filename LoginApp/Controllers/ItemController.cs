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

    public class ItemController : Controller
    {

        private readonly AuthenticationContext _context;

        public ItemController(AuthenticationContext context)
        {
            _context = context;

        }


        [HttpGet]
            public async Task<ActionResult<IEnumerable<OrderItemsModel>>> GetItems()
            {
                return await _context.OrderItems.ToListAsync();

            }

    }
}