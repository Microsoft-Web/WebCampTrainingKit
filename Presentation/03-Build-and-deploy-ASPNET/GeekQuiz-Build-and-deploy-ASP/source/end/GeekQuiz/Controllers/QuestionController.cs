using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using GeekQuiz.Models;

namespace GeekQuiz.Controllers
{
    public class QuestionController : Controller
    {
        private TriviaContext _context;

        public QuestionController(TriviaContext context)
        {
            _context = context;    
        }

        // GET: Question
        public async Task<IActionResult> Index()
        {
            return View(await _context.TriviaQuestion.ToListAsync());
        }

        // GET: Question/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TriviaQuestion triviaQuestion = await _context.TriviaQuestion.SingleAsync(m => m.Id == id);
            if (triviaQuestion == null)
            {
                return HttpNotFound();
            }

            return View(triviaQuestion);
        }

        // GET: Question/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TriviaQuestion triviaQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.TriviaQuestion.Add(triviaQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(triviaQuestion);
        }

        // GET: Question/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TriviaQuestion triviaQuestion = await _context.TriviaQuestion.SingleAsync(m => m.Id == id);
            if (triviaQuestion == null)
            {
                return HttpNotFound();
            }
            return View(triviaQuestion);
        }

        // POST: Question/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TriviaQuestion triviaQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Update(triviaQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(triviaQuestion);
        }

        // GET: Question/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TriviaQuestion triviaQuestion = await _context.TriviaQuestion.SingleAsync(m => m.Id == id);
            if (triviaQuestion == null)
            {
                return HttpNotFound();
            }

            return View(triviaQuestion);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            TriviaQuestion triviaQuestion = await _context.TriviaQuestion.SingleAsync(m => m.Id == id);
            _context.TriviaQuestion.Remove(triviaQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
