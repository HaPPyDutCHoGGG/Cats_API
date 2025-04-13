using Microsoft.AspNetCore.Mvc;
using Cats_API;
using Microsoft.EntityFrameworkCore;

namespace Cats_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatsAPIController : ControllerBase
    {

        private readonly Cat empty_cat = new Cat { name = "empty" };

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
            if (product == null) { return Ok(empty_cat); }
            
            var buf = await _context.cats.FindAsync(product.name);
            if (buf == null) { _context.cats.Add(product); }
            else 
            {
                buf.breed = product.breed;
                buf.age = product.age;  
                buf.color = product.color;
                buf.gender = product.gender;
            }

            await _context.SaveChangesAsync();

            return Ok();
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

            return Ok(empty_cat); //204 No Content
        }
    }
}
