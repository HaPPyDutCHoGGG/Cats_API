using Microsoft.AspNetCore.Mvc;
using Cats_API;
using Microsoft.EntityFrameworkCore;

namespace Cats_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatsAPIController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public CatsAPIController(ApplicationDbContext context) 
        { 
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat>>> get_cats_list()
        {
            return await _context.cats.ToListAsync();
        }
    }
}
