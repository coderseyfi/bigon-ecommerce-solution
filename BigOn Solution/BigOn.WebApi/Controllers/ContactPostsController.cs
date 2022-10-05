using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;

namespace BigOn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPostsController : ControllerBase
    {
        private readonly BigOnDbContext _context;

        public ContactPostsController(BigOnDbContext context)
        {
            _context = context;
        }

        // GET: api/ContactPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactPost>>> GetContactPosts()
        {
            return await _context.ContactPosts.ToListAsync();
        }

        // GET: api/ContactPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactPost>> GetContactPost(int id)
        {
            var contactPost = await _context.ContactPosts.FindAsync(id);

            if (contactPost == null)
            {
                return NotFound();
            }

            return contactPost;
        }

        // PUT: api/ContactPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactPost(int id, ContactPost contactPost)
        {
            if (id != contactPost.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactPostExists(id))
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

        // POST: api/ContactPosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactPost>> PostContactPost(ContactPost contactPost)
        {
            _context.ContactPosts.Add(contactPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactPost", new { id = contactPost.Id }, contactPost);
        }

        // DELETE: api/ContactPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactPost(int id)
        {
            var contactPost = await _context.ContactPosts.FindAsync(id);
            if (contactPost == null)
            {
                return NotFound();
            }

            _context.ContactPosts.Remove(contactPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactPostExists(int id)
        {
            return _context.ContactPosts.Any(e => e.Id == id);
        }
    }
}
