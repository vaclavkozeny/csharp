#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_School.Data;
using API_School.Models;
using API_School.ViewModel;

namespace API_School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClassroomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Classrooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classroom>>> Getclassrooms()
        {
            return await _context.classrooms.ToListAsync();
        }

        // GET: api/Classrooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classroom>> GetClassroom(int id)
        {
            var classroom = await _context.classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound();
            }

            return classroom;
        }
        // PUT: api/Classrooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassroom(int id, Classroom classroom)
        {
            if (id != classroom.Id)
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Classroom>> PostClassroom(Classroom classroom)
        {
            _context.classrooms.Add(classroom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassroom", new { id = classroom.Id }, classroom);
        }

        // DELETE: api/Classrooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroom(int id)
        {
            var classroom = await _context.classrooms.FindAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }

            _context.classrooms.Remove(classroom);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("{id}/students")]
        public async Task<ActionResult<Classroom>> GetClassroomStudents(int id)
        {
            var classroom = await _context.classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound("class does not exists");
            }

            _context.Entry(classroom).Collection(c => c.Students).Load();

            return Ok(classroom.Students);
        }

        private bool ClassroomExists(int id)
        {
            return _context.classrooms.Any(e => e.Id == id);
        }
        [HttpPost("{id}/students")]
        public async Task<ActionResult> AddStudentToClass(int id, [FromBody] IdVM student)
        {
            var classroom = await _context.classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound("class does not exists");
            }
            var st = await _context.students.FindAsync(student.Id);
            if (st == null)
            {
                return NotFound("student does not exists");
            }
            var stclass = await _context.students.Where(s => s.Id == student.Id && classroom.Id == id).SingleOrDefaultAsync();
            if (stclass == null)
            {
                st.ClassroomId = id;
                await _context.SaveChangesAsync();
                return Ok(st);

            }
            else
            {
                return NoContent();
            }
        }
        [HttpDelete("{id}/students/{studentId}")]
        public async Task<ActionResult> RemoveFromClass(int id, int studentId)
        {
            var classroom = await _context.classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound("class does not exists");
            }
            var st = await _context.students.FindAsync(studentId);
            if (st == null)
            {
                return NotFound("student does not exists");
            }
            var stclass = await _context.students.Where(s => s.Id == studentId && classroom.Id == id).SingleOrDefaultAsync();
            if (stclass == null)
            {
                return BadRequest();

            }
            else
            {
                st.Classroom = null;
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpDelete("{id}/students/")]
        public async Task<ActionResult> ClearStudents(int id)
        {
            var classroom = await _context.classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound("class does not exists");
            }
            _context.Entry(classroom).Collection(c => c.Students).Load();
            classroom.Students.Clear();
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
