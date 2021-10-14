using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Magic_BismarkAramayo.Data;
using Magic_BismarkAramayo.Models;

namespace Magic_BismarkAramayo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuturosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FuturosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Futuros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Futuro>>> GetFuturo()
        {
            return await _context.Futuro.ToListAsync();
        }

        // GET: api/Futuros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Futuro>> GetFuturo(string id)
        {
            var futuro = await _context.Futuro.FindAsync(id);

            if (futuro == null)
            {
                return NotFound();
            }

            return futuro;
        }

        // PUT: api/Futuros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuturo(string id, Futuro futuro)
        {
            if (id != futuro.FuturoId)
            {
                return BadRequest();
            }

            _context.Entry(futuro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuturoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Futuros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Futuro>> PostFuturo(Futuro futuro)
        {
            _context.Futuro.Add(futuro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FuturoExists(futuro.FuturoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFuturo", new { id = futuro.FuturoId }, futuro);
        }

        // DELETE: api/Futuros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuturo(string id)
        {
            var futuro = await _context.Futuro.FindAsync(id);
            if (futuro == null)
            {
                return NotFound();
            }

            _context.Futuro.Remove(futuro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuturoExists(string id)
        {
            return _context.Futuro.Any(e => e.FuturoId == id);
        }
    }
}
