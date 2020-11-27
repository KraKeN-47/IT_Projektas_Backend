using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.IntventoriusRequestModels;
using Org.BouncyCastle.Ocsp;

namespace IT_Projektas_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriusController : ControllerBase
    {
        private readonly it_projektasContext _context;

        public InventoriusController(it_projektasContext context)
        {
            _context = context;
        }

        // GET: api/Inventorius
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventorius>>> GetInventorius()
        {
            return await _context.Inventorius.ToListAsync();
        }

        // GET: api/Inventorius/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventorius>> GetInventorius(int id)
        {
            var inventorius = await _context.Inventorius.FindAsync(id);

            if (inventorius == null)
            {
                return NotFound();
            }

            return inventorius;
        }

        // PUT: api/Inventorius/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("kkk")]
        public async Task<IActionResult> PutInventorius(int id, Inventorius inventorius)
        {
            if (id != inventorius.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventorius).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoriusExists(id))
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

        // POST: api/Inventorius
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Inventorius>> PostInventorius(inventoriusgetrequest request)
        {
            var obj = new Inventorius
            {
                Pavadinimas = request.Pavadinimas,
                Kiekis = request.Kiekis,
                KabinetoNumeris = request.KabinetoNumeris
            };

            _context.Inventorius.Add(obj);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetInventorius", new { id = inventorius.Id }, inventorius);
            return Ok();
        }

        // DELETE: api/Inventorius/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inventorius>> DeleteInventorius(int id)
        {
            var inventorius = await _context.Inventorius.FindAsync(id);
            if (inventorius == null)
            {
                return NotFound();
            }

            _context.Inventorius.Remove(inventorius);
            await _context.SaveChangesAsync();

            return inventorius;
        }

        private bool InventoriusExists(int id)
        {
            return _context.Inventorius.Any(e => e.Id == id);
        }
    }
}
