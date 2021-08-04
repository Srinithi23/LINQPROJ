using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LINQPROJ.Data;
using LINQPROJ.Models;

namespace LINQPROJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpdetailsController : ControllerBase
    {
        private readonly LINQPROJContext _context;

        public EmpdetailsController(LINQPROJContext context)
        {
            _context = context;
        }

        // GET: api/Empdetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empdetail>>> GetEmpdetail()
        {
            return await _context.Empdetail.ToListAsync();
        }

        // GET: api/Empdetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empdetail>> GetEmpdetail(int id)
        {
            var empdetail = await _context.Empdetail.FindAsync(id);

            if (empdetail == null)
            {
                return NotFound();
            }

            return empdetail;
        }

        // PUT: api/Empdetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpdetail(int id, Empdetail empdetail)
        {
            if (id != empdetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(empdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpdetailExists(id))
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

        // POST: api/Empdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empdetail>> PostEmpdetail(Empdetail empdetail)
        {
            _context.Empdetail.Add(empdetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpdetail", new { id = empdetail.Id }, empdetail);
        }

        // DELETE: api/Empdetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpdetail(int id)
        {
            var empdetail = await _context.Empdetail.FindAsync(id);
            if (empdetail == null)
            {
                return NotFound();
            }

            _context.Empdetail.Remove(empdetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpdetailExists(int id)
        {
            return _context.Empdetail.Any(e => e.Id == id);
        }
    }
}
