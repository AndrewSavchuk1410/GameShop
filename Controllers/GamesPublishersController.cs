using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameShop.Models;

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesPublishersController : ControllerBase
    {
        private readonly GameShopContext _context;

        public GamesPublishersController(GameShopContext context)
        {
            _context = context;
        }

        // GET: api/GamesPublishers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GamesPublishers>>> GetGamesPublishers()
        {
            return await _context.GamesPublishers.ToListAsync();
        }

        // GET: api/GamesPublishers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GamesPublishers>> GetGamesPublishers(int id)
        {
            var gamesPublishers = await _context.GamesPublishers.FindAsync(id);

            if (gamesPublishers == null)
            {
                return NotFound();
            }

            return gamesPublishers;
        }

        // PUT: api/GamesPublishers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGamesPublishers(int id, GamesPublishers gamesPublishers)
        {
            if (id != gamesPublishers.Id)
            {
                return BadRequest();
            }

            _context.Entry(gamesPublishers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesPublishersExists(id))
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

        // POST: api/GamesPublishers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GamesPublishers>> PostGamesPublishers(GamesPublishers gamesPublishers)
        {
            _context.GamesPublishers.Add(gamesPublishers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGamesPublishers", new { id = gamesPublishers.Id }, gamesPublishers);
        }

        // DELETE: api/GamesPublishers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GamesPublishers>> DeleteGamesPublishers(int id)
        {
            var gamesPublishers = await _context.GamesPublishers.FindAsync(id);
            if (gamesPublishers == null)
            {
                return NotFound();
            }

            _context.GamesPublishers.Remove(gamesPublishers);
            await _context.SaveChangesAsync();

            return gamesPublishers;
        }

        private bool GamesPublishersExists(int id)
        {
            return _context.GamesPublishers.Any(e => e.Id == id);
        }
    }
}
