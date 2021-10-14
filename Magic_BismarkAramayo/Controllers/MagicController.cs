using Magic_BismarkAramayo.Data;
using Magic_BismarkAramayo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magic_BismarkAramayo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagicController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MagicController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Futuro>> GetFuturo()
        {
            var list = await _context.Futuro.ToListAsync();
            var max = list.Count;
            int index = new Random().Next(0, max);
            var futuro = list[index];

            if (futuro == null)
            {
                return NoContent();
            }
            return futuro;
        }
    }
}
