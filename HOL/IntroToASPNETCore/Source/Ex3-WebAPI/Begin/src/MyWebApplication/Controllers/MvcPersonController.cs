using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MyWebApplication.Models;

namespace MyWebApplication.Controllers
{
    public class MvcPersonController : Controller
    {
        private PersonContext _context;

        public MvcPersonController(PersonContext context)
        {
            _context = context;    
        }

        // GET: MvcPerson
        public async Task<IActionResult> Index()
        {
            return View(await _context.Person.ToListAsync());
        }

        // GET: MvcPerson/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Person person = await _context.Person.SingleAsync(m => m.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // GET: MvcPerson/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MvcPerson/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Person.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: MvcPerson/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Person person = await _context.Person.SingleAsync(m => m.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: MvcPerson/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Update(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: MvcPerson/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Person person = await _context.Person.SingleAsync(m => m.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // POST: MvcPerson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Person person = await _context.Person.SingleAsync(m => m.Id == id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
