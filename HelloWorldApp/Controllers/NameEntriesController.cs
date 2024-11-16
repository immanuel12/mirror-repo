using HelloWorldApp.Data;
using HelloWorldApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorldApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameEntriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NameEntriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/NameEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NameEntry>>> GetNameEntries()
        {
            return await _context.NameEntries.ToListAsync();
        }

        // GET: api/NameEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NameEntry>> GetNameEntry(int id)
        {
            var nameEntry = await _context.NameEntries.FindAsync(id);

            if (nameEntry == null)
            {
                return NotFound();
            }

            return nameEntry;
        }

        // POST: api/NameEntries
        [HttpPost]
        public async Task<ActionResult<NameEntry>> PostNameEntry(NameEntry nameEntry)
        {
            _context.NameEntries.Add(nameEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNameEntry), new { id = nameEntry.Id }, nameEntry);
        }
    }
}
