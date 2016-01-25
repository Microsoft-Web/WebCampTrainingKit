using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using GeekQuiz.Models;

namespace GeekQuiz.Controllers
{
    public class OptionController : Controller
    {
        private TriviaContext _context;

        public OptionController(TriviaContext context)
        {
            _context = context;    
        }

        // GET: Option
        public async Task<IActionResult> Index()
        {
            var triviaContext = _context.TriviaOption.Include(t => t.TriviaQuestion);
            return View(await triviaContext.ToListAsync());
        }

        // GET: Option/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TriviaOption triviaOption = await _context.TriviaOption.SingleAsync(m => m.Id == id);
            if (triviaOption == null)
            {
                return HttpNotFound();
            }

            return View(triviaOption);
        }

        // GET: Option/Create
        public IActionResult Create()
        {
            ViewData["QuestionId"] = new SelectList(_context.TriviaQuestion, "Id", "TriviaQuestion");
            return View();
        }

        // POST: Option/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TriviaOption triviaOption)
        {
            if (ModelState.IsValid)
            {
                _context.TriviaOption.Add(triviaOption);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["QuestionId"] = new SelectList(_context.TriviaQuestion, "Id", "TriviaQuestion", triviaOption.QuestionId);
            return View(triviaOption);
        }

        // GET: Option/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TriviaOption triviaOption = await _context.TriviaOption.SingleAsync(m => m.Id == id);
            if (triviaOption == null)
            {
                return HttpNotFound();
            }
            ViewData["QuestionId"] = new SelectList(_context.TriviaQuestion, "Id", "TriviaQuestion", triviaOption.QuestionId);
            return View(triviaOption);
        }

        // POST: Option/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TriviaOption triviaOption)
        {
            if (ModelState.IsValid)
            {
                _context.Update(triviaOption);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["QuestionId"] = new SelectList(_context.TriviaQuestion, "Id", "TriviaQuestion", triviaOption.QuestionId);
            return View(triviaOption);
        }

        // GET: Option/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TriviaOption triviaOption = await _context.TriviaOption.SingleAsync(m => m.Id == id);
            if (triviaOption == null)
            {
                return HttpNotFound();
            }

            return View(triviaOption);
        }

        // POST: Option/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            TriviaOption triviaOption = await _context.TriviaOption.SingleAsync(m => m.Id == id);
            _context.TriviaOption.Remove(triviaOption);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
