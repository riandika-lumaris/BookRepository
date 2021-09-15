using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DOT;
using DOT.Core;

namespace DOT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksDBContext _context;

        public BooksController(BooksDBContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound("Book not found");
            }

            return book;
        }

        // GET: api/Books/5/Author
        [HttpGet("{id}/Author")]
        public async Task<ActionResult<Author>> GetBookAuthor(Guid id) {
            var book = await _context.Books.FindAsync(id);

            if (book == null) {
                return NotFound();
            }

            return book.Author;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Guid id, Book book)
        {
            var bookItem = await _context.Books.FindAsync(id);
            if (bookItem == null)
            {
                return NotFound("Book not found");
            }
            
            bookItem.AuthorID = book.AuthorID;
            bookItem.Title = book.Title;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(bookItem);
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.ID }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound("Book not found");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool BookExists(Guid id)
        {
            return _context.Books.Any(e => e.ID == id);
        }
    }
}
