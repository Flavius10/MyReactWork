using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezultateController : ControllerBase
    {
        private readonly RezultateDbContext _context;

        public RezultateController(RezultateDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Rezultate>>> GetRezultate()
        {
            var rezultate = await _context.Rezultat.ToListAsync();

            return Ok(rezultate);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<Rezultate>>> GetRezultate(int id)
        {
            var rezultat = await _context.Rezultat.FirstOrDefaultAsync(r => r.ConcurentId == id);

            if(rezultat == null)
            {
                return NotFound();
            }

            return Ok(rezultat);    
        }

        [HttpPost]  

        public async Task<ActionResult<Rezultate>> PostRezultate(Rezultate rezultate)
        {
            _context.Rezultat.Add(rezultate);
            await _context.SaveChangesAsync();  

            return NoContent();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Rezultate>> PutRezultate(int id, Rezultate rezultate)
        {
            if(id != rezultate.ConcurentId)
                return BadRequest();

            if (!ExistaRezultat(id))
                return NotFound();

            _context.Entry(rezultate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        private bool ExistaRezultat(int id)
        {
            return _context.Rezultat.Any(e => e.ConcurentId == id);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Rezultate>> DeleteRezultate(int id)
        {
            var rezultate = await _context.Rezultat.FindAsync(id);

            if (rezultate == null)
                return NotFound();

            _context.Rezultat.Remove(rezultate);
            await _context.SaveChangesAsync();  

            return NoContent();
        }
    }
}
