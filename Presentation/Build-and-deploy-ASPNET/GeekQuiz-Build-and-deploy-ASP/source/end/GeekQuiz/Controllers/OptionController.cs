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

        // GET: /Option/
        public async Task<ActionResult> Index()
        {
            var triviaoptions = db.TriviaOptions.Include(t => t.TriviaQuestion);
            return View(await triviaoptions.ToListAsync());
        }

        // GET: /Option/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriviaOption triviaoption = await db.TriviaOptions.FindAsync(id);
            if (triviaoption == null)
            {
                return HttpNotFound();
            }
            return View(triviaoption);
        }

        // GET: /Option/Create
        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(db.TriviaQuestions, "Id", "Title");
            return View();
        }

        // POST: /Option/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,QuestionId,Title,IsCorrect")] TriviaOption triviaoption)
        {
            if (ModelState.IsValid)
            {
                db.TriviaOptions.Add(triviaoption);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(db.TriviaQuestions, "Id", "Title", triviaoption.QuestionId);
            return View(triviaoption);
        }

        // GET: /Option/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriviaOption triviaoption = await db.TriviaOptions.FindAsync(id);
            if (triviaoption == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.TriviaQuestions, "Id", "Title", triviaoption.QuestionId);
            return View(triviaoption);
        }

        // POST: /Option/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,QuestionId,Title,IsCorrect")] TriviaOption triviaoption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(triviaoption).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.TriviaQuestions, "Id", "Title", triviaoption.QuestionId);
            return View(triviaoption);
        }

        // GET: /Option/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriviaOption triviaoption = await db.TriviaOptions.FindAsync(id);
            if (triviaoption == null)
            {
                return HttpNotFound();
            }
            return View(triviaoption);
        }

        // POST: /Option/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TriviaOption triviaoption = await db.TriviaOptions.FindAsync(id);
            db.TriviaOptions.Remove(triviaoption);
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
