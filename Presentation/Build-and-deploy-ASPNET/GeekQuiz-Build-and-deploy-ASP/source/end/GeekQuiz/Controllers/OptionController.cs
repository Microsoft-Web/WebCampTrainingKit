using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GeekQuiz.Models;

namespace GeekQuiz.Controllers
{
    public class OptionController : Controller
    {
        private TriviaContext db = new TriviaContext();

        // GET: Option
        public async Task<ActionResult> Index()
        {
            var triviaOptions = db.TriviaOptions.Include(t => t.TriviaQuestion);
            return View(await triviaOptions.ToListAsync());
        }

        // GET: Option/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriviaOption triviaOption = await db.TriviaOptions.FindAsync(id);
            if (triviaOption == null)
            {
                return HttpNotFound();
            }
            return View(triviaOption);
        }

        // GET: Option/Create
        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(db.TriviaQuestions, "Id", "Title");
            return View();
        }

        // POST: Option/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,QuestionId,Title,IsCorrect")] TriviaOption triviaOption)
        {
            if (ModelState.IsValid)
            {
                db.TriviaOptions.Add(triviaOption);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(db.TriviaQuestions, "Id", "Title", triviaOption.QuestionId);
            return View(triviaOption);
        }

        // GET: Option/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriviaOption triviaOption = await db.TriviaOptions.FindAsync(id);
            if (triviaOption == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.TriviaQuestions, "Id", "Title", triviaOption.QuestionId);
            return View(triviaOption);
        }

        // POST: Option/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,QuestionId,Title,IsCorrect")] TriviaOption triviaOption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(triviaOption).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.TriviaQuestions, "Id", "Title", triviaOption.QuestionId);
            return View(triviaOption);
        }

        // GET: Option/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriviaOption triviaOption = await db.TriviaOptions.FindAsync(id);
            if (triviaOption == null)
            {
                return HttpNotFound();
            }
            return View(triviaOption);
        }

        // POST: Option/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TriviaOption triviaOption = await db.TriviaOptions.FindAsync(id);
            db.TriviaOptions.Remove(triviaOption);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
