using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoNET_LocalDB.Models;

namespace ProyectoNET_LocalDB.Controllers
{
    public class EvaluationsController : Controller
    {
        private readonly InfoDbContext _context;

        public EvaluationsController(InfoDbContext context)
        {
            _context = context;
        }

        // GET: Evaluations
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Informatorio";

            var Modulo = _context.ActualModules.FirstOrDefault();
            List<Evaluation> Evaluation = await _context.Evaluations.Where(p=> p.Module.ID == Modulo.ActualModulo).ToListAsync();
            foreach (var item in Evaluation)
            {
                item.Feedbacks= await _context.Feedbacks.Where(p => p.Evaluation == item).Include("Student").ToListAsync();

            }


            return View(Evaluation);
        }

        // GET: Evaluations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evaluations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,DateEvaluation")] Evaluation evaluation)
        {
            evaluation.DateEvaluation = DateTime.Today;
            var Modulo = _context.ActualModules.FirstOrDefault();
            evaluation.Module= _context.Modules.Single(p => p.ID == Modulo.ActualModulo);
            List<Student> Student = _context.Students.ToList();
            evaluation.Feedbacks = new List<Feedback>();
            foreach (var stu in Student)
            {
                Feedback feed = new Feedback();
                feed.Teacher = _context.Teachers.FirstOrDefault(m => m.ID == Modulo.TeacherID);
                feed.Student = stu;
                feed.Evaluation = evaluation;
                evaluation.Feedbacks.Add(feed);
            }
            
            if (ModelState.IsValid)
            {
                _context.Add(evaluation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evaluation);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateFeedback([Bind("ID,Name,DateEvaluation")] List<Feedback> Feedback)
        //{
        //    evaluation.DateEvaluation = DateTime.Today;
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(evaluation);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(CreateFeedback));
        //    }
        //    return View(evaluation);
        //}

        // GET: Evaluations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var evaluation = _context.Evaluations.Single(m => m.ID == id);
            evaluation.Feedbacks = await _context.Feedbacks.Where(p => p.Evaluation == evaluation).Include("Student").ToListAsync();
            if (evaluation == null)
            {
                return NotFound();
            }
            return View(evaluation);
        }
        

        // GET: Evaluations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluations
                .SingleOrDefaultAsync(m => m.ID == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // POST: Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluation = await _context.Evaluations.SingleOrDefaultAsync(m => m.ID == id);
            List<Feedback> Feed = await _context.Feedbacks.Where(p => p.Evaluation.ID == id).ToListAsync();

            foreach (var feed in Feed)
            {
                var feedback = await _context.Feedbacks.SingleOrDefaultAsync(m => m.ID == feed.ID);
                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
            }

            _context.Evaluations.Remove(evaluation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationExists(int id)
        {
            return _context.Evaluations.Any(e => e.ID == id);
        }
    }
}
