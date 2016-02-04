using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using MyWebApplication.Models;

namespace MyWebApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/ApiPerson")]
    public class ApiPersonController : Controller
    {
        private PersonContext _context;

        public ApiPersonController(PersonContext context)
        {
            _context = context;
        }

        // GET: api/ApiPerson
        [HttpGet]
        public IEnumerable<Person> GetPerson()
        {
            return _context.Person;
        }

        // GET: api/ApiPerson/5
        [HttpGet("{id}", Name = "GetPerson")]
        public async Task<IActionResult> GetPerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Person person = await _context.Person.SingleAsync(m => m.Id == id);

            if (person == null)
            {
                return HttpNotFound();
            }

            return Ok(person);
        }

        // PUT: api/ApiPerson/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson([FromRoute] int id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/ApiPerson
        [HttpPost]
        public async Task<IActionResult> PostPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Person.Add(person);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonExists(person.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/ApiPerson/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Person person = await _context.Person.SingleAsync(m => m.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Count(e => e.Id == id) > 0;
        }
    }
}