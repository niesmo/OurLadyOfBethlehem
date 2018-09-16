using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OLB.DataAccess;
using OLB.Domain;

namespace OLB.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Classrooms")]
    public class ClassroomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassroomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Classrooms
        [HttpGet]
        public IEnumerable<Classroom> GetClassrooms()
        {
            return _context.Classrooms;
        }

        // GET: api/Classrooms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassroom([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classroom = await _context.Classrooms.SingleOrDefaultAsync(m => m.ClassroomId == id);

            if (classroom == null)
            {
                return NotFound();
            }

            return Ok(classroom);
        }

        // PUT: api/Classrooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassroom([FromRoute] Guid id, [FromBody] Classroom classroom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classroom.ClassroomId)
            {
                return BadRequest();
            }

            _context.Entry(classroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomExists(id))
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

        // POST: api/Classrooms
        [HttpPost]
        public async Task<IActionResult> PostClassroom([FromBody] Classroom classroom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Classrooms.Add(classroom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassroom", new { id = classroom.ClassroomId }, classroom);
        }

        // DELETE: api/Classrooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroom([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classroom = await _context.Classrooms.SingleOrDefaultAsync(m => m.ClassroomId == id);
            if (classroom == null)
            {
                return NotFound();
            }

            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();

            return Ok(classroom);
        }

        private bool ClassroomExists(Guid id)
        {
            return _context.Classrooms.Any(e => e.ClassroomId == id);
        }
    }
}