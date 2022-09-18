using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FruitWebApiREST.Data;
using FruitWebApiREST.Models;

namespace FruitWebApiREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        private readonly FruitContext _context;

        public FruitsController(FruitContext context)
        {
            _context = context;
        }

        // GET: api/Fruits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fruits>>> GetFruit()
        {
            return await _context.Fruit.ToListAsync();
        }

        // GET: api/Fruits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fruits>> GetFruits(int id)
        {
            var fruits = await _context.Fruit.FindAsync(id);

            if (fruits == null)
            {
                return NotFound();
            }

            return fruits;
        }

        // PUT: api/Fruits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFruits(int id, Fruits fruits)
        {
            if (id != fruits.Id)
            {
                return BadRequest();
            }

            _context.Entry(fruits).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FruitsExists(id))
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

        // POST: api/Fruits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fruits>> PostFruits(Fruits fruits)
        {
            _context.Fruit.Add(fruits);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFruits", new { id = fruits.Id }, fruits);

        }

        // DELETE: api/Fruits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFruits(int id)
        {
            var fruits = await _context.Fruit.FindAsync(id);
            if (fruits == null)
            {
                return NotFound();
            }

            _context.Fruit.Remove(fruits);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        private bool FruitsExists(int id)
        {
            return _context.Fruit.Any(e => e.Id == id);
        }
    }
}
