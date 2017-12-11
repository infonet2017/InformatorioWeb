using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoNET_DB.Info2017;

namespace ProyectoNET_LocalDB.Controllers
{
    public class EvaluationsController : Controller
    {
        private readonly info2017Context _context;

        public EvaluationsController(info2017Context context)
        {
            _context = context;
        }

        // GET: Evaluations
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Informatorio";

            var Modulo = _context.Actualmodule.FirstOrDefault();
            List<Evaluation> Evaluation = await _context.Evaluation.Where(p=> p.IdModule == Modulo.ActualModule & p.IsDeleted == false).ToListAsync();
            foreach (var item in Evaluation)
            {
                item.Feedback= await _context.Feedback.Where(p => p.IdEvaluation == item.IdEvaluation).Include("IdStudentNavigation").ToListAsync();

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
            evaluation.DateEvaluation = DateTime.Now;
            var Modulo = _context.Actualmodule.FirstOrDefault();
            evaluation.IdModule= _context.Auxiliarmodules.Single(p => p.IdModule == Modulo.ActualModule).IdModule;
            List<Student> Student = _context.Student.ToList();
            evaluation.IsDeleted = false;
            evaluation.Feedback = new List<Feedback>();
            
            foreach (var stu in Student)
            {
                Feedback feed = new Feedback();
                feed.IdTeacher = _context.Teacher.FirstOrDefault(m => m.IdAuxiliarModules == Modulo.TeacherId).IdTeacher;
                feed.IdStudent = stu.Idstudent;
                feed.IdEvaluation = evaluation.IdEvaluation;
                evaluation.Feedback.Add(feed);
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
        //    evaluation.DateEvaluation = DateTime.Now;
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
            var evaluation = _context.Evaluation.Single(m => m.IdEvaluation == id);
            evaluation.Feedback = await _context.Feedback.Where(p => p.IdEvaluation == evaluation.IdEvaluation).Include("Usuarios").ToListAsync();
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

            var evaluation = await _context.Evaluation
                .SingleOrDefaultAsync(m => m.IdEvaluation == id);
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
            var evaluation = await _context.Evaluation.SingleOrDefaultAsync(m => m.IdEvaluation == id);
            evaluation.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationExists(int id)
        {
            return _context.Evaluation.Any(e => e.IdEvaluation == id);
        }
    }
}
