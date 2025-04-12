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

        [HttpPost]
        public async Task<ActionResult<Cat>> post_cat(Cat product)
        {
            _context.cats.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { name = product.name, age = product.age, breed = product.breed, 
                gender = product.gender, color = product.color }, product);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteByName(string name)
        {
           
            var product = await _context.cats.SingleOrDefaultAsync(p => p.name == name); 
            
            if (product == null)
            {
                return NotFound(); //404
            }

            _context.cats.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent(); //204 No Content
        }
    }
}
