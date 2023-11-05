#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Books.Data;
using Books.Model;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Získá všechny autory
        /// </summary>
        /// <returns>List of Author</returns>
        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _context.Authors.Include(t =>t.Books).ToListAsync();
        }

        /// <summary>
        /// Získá autora podle nazvu
        /// </summary>
        /// <param search="strin">AuthorId</param>
        /// <returns>Author / NotFound</returns>
        [HttpGet("search/{strin}")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthorSearch(string strin)
        {
            var author = await _context.Authors.Include(t => t.Books).Where(t => t.Firstname.Contains(strin.ToLower().ToUpper()) || t.Lastname.Contains(strin.ToLower().ToUpper())).ToListAsync();

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }
        /// <summary>
        /// Získá autora podle id
        /// </summary>
        /// <param name="id">AuthorId</param>
        /// <returns>Author / NotFound</returns>
        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _context.Authors.Include(t => t.Books).Where(t => t.AuthorId == id).FirstOrDefaultAsync();

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }
        /// <summary>
        /// Získá počet autorových knih podle id
        /// </summary>
        /// <param name="id">AuthorId</param>
        /// <returns>Author / NotFound</returns>
        // GET: api/Authors/5
        [HttpGet("{id}/count")]
        public async Task<ActionResult<int>> GetAuthorBooks(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }
            /*Console.WriteLine(author);
            Console.WriteLine(author.Books);*/
            _context.Entry(author).Collection(c => c.Books).Load();
            return Ok(author.Books.Count());
        }
        /// <summary>
        /// Získá autorovy knihy
        /// </summary>
        /// <param name="id">AuthorId</param>
        /// <returns>Author / NotFound</returns>
        // GET: api/Authors/5
        [HttpGet("{id}/books")]
        public async Task<ActionResult<Author>> GetAuthorBooksList(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }
            _context.Entry(author).Collection(c => c.Books).Load();
            //var books = _context.Books.Where(t=>t.AuthorId == author.Id).ToList();
            return Ok(author.Books);
            
        }
        /// <summary>
        /// Nahradí tělo autor získaného podle id
        /// </summary>
        /// <param name="id">AuthorID</param>
        /// <param name="author">Boby from swagger</param>
        /// <returns>
        /// BadRequest -> když se id neshoduje
        /// </returns>
        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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
        /// <summary>
        ///Přidá autora ke knize
        /// </summary>
        /// <param name="bookid">BookId</param>
        /// <param name="id">AuthorId</param>
        /// <returns></returns>
        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}/{bookid}")]
        public async Task<ActionResult> PostAuthorBook(int id, int bookid)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound("author not found");
            }
            var bk = await _context.Books.FindAsync(bookid);
            if (bk == null)
            {
                return NotFound("book not found");
            }
            if(bk.AuthorId != null)
            {
                return BadRequest("already has an author");
            }
            bk.Author = author;
            //author.Books.Add(bk);
            await _context.SaveChangesAsync();
            return Ok(bk);
        }
        /// <summary>
        /// Odebere od knihy autora
        /// </summary>
        /// <param name="bookid">BookId</param>
        /// <returns></returns>
        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpDelete("{bookid}/delete")]
        public async Task<IActionResult> PostAuthorBookDelete(int bookid)
        {
            var bk = await _context.Books.FindAsync(bookid);
            if (bk == null)
            {
                return NotFound("book not found");
            }
            bk.AuthorId = 0;
            //author.Books.Add(bk);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        /// <summary>
        ///  Přidá autora pomocí body
        /// </summary>
        /// <param name="author">Body from swagger</param>
        /// <returns></returns>
        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
        }
        /// <summary>
        /// Odstrani autora
        /// </summary>
        /// <param name="id">AuthorId</param>
        /// <returns></returns>
        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            var b = _context.Books.Where(t=>t.AuthorId == id).ToList();
            _context.Books.RemoveRange(b);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        /// <summary>
        /// Odstrani autora
        /// </summary>
        /// <param name="id">AuthorId</param>
        /// <returns></returns>
        // DELETE: api/Authors/5
        [HttpDelete("{id}/books")]
        public async Task<IActionResult> DeleteAuthorBooks(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Entry(author).Collection(c => c.Books).Load();
            author.Books.Clear();
            await _context.SaveChangesAsync();
            return Ok(author);
        }
        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorId == id);
        }
    }
}
