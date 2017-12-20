using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoNET_DB.Info2017;
using ProyectoNET_DB.Extra_Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ProyectoNET_DB.Controllers
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

            var module = _context.Actualmodule.FirstOrDefault();

            UserData user = new UserData
            {
                id=module.IdTeacher,
                FirstName = module.FirstName,
                LastName = module.LastName,
                Dni = module.Dni,
                Email = module.Email
            };

            ViewBag.user = user;

            List<Evaluation> Evaluation = await _context.Evaluation.Where(p => p.IdModule == module.ActualModule & p.IsDeleted == false).Include("Feedback").ToListAsync();

            return View(Evaluation);
        }

        // GET: Evaluations/Create
        public IActionResult Create()
        {
            var module = _context.Actualmodule.FirstOrDefault();
            UserData user = new UserData
            {
                id=module.IdTeacher,
                FirstName = module.FirstName,
                LastName = module.LastName,
                Dni = module.Dni,
                Email = module.Email
            };

            ViewBag.user = user;
            return View();
        }

        // POST: Evaluations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,DateEvaluation")] Evaluation evaluation)
        {
            var module = _context.Actualmodule.FirstOrDefault();

            _context.Database.ExecuteSqlCommand("SET FOREIGN_KEY_CHECKS=0");

            evaluation.DateEvaluation = DateTime.Now;

            evaluation.IdModule = module.ActualModule;
            //evaluation.IdModuleNavigation = _context.Modules.Single(p => p.Idmodule == module.ActualModule);
            List<Student> Student = _context.Student.ToList();
            evaluation.IdTeacher = module.IdTeacher;
            evaluation.IdTeacherNavigation = _context.UsuarioUsers.FirstOrDefault(p => p.Id == module.IdTeacher);
            evaluation.IsDeleted = false;
            evaluation.Feedback = new List<Feedback>();

            foreach (var stu in Student)
            {
                Feedback feed = new Feedback();
                feed.IdStudent = stu.IdUsuario;
                feed.IdEvaluation = evaluation.IdEvaluation;
                feed.NameStudent =_context.UsuarioUsers.FirstOrDefault(p => p.Id == stu.IdUsuario).FirstName + " " + _context.UsuarioUsers.FirstOrDefault(p => p.Id == stu.IdUsuario).LastName;
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



        // GET: Evaluations/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var module = _context.Actualmodule.FirstOrDefault();

            UserData user = new UserData
            {
                id=module.IdTeacher,
                FirstName = module.FirstName,
                LastName = module.LastName,
                Dni = module.Dni,
                Email = module.Email
            };

            ViewBag.user = user;

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
        public async Task<IActionResult> Delete(int id)
        {
            var module = _context.Actualmodule.FirstOrDefault();

            UserData user = new UserData
            {
                id=module.IdTeacher,
                FirstName = module.FirstName,
                LastName = module.LastName,
                Dni = module.Dni,
                Email = module.Email
            };

            ViewBag.user = user;

            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation
                .SingleOrDefaultAsync(m => m.IdEvaluation == id);

            evaluation.Feedback = await _context.Feedback.Where(p => p.IdEvaluation == id).ToListAsync();

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


        
        public async Task<ActionResult> GetStudents()
        {
            int idModule = _context.Actualmodule.FirstOrDefault().ActualModule;

            var fakeResponse = LoadStudentsAsync(idModule);//cargo el jotason desde un archivo para simular la request a la api rancia del equipo de django

            var task = StudentMappingAsync(fakeResponse.Result);

            return RedirectToAction("Index", "Evaluations");
        }



        public async Task<List<Student>> StudentMappingAsync(StudentResponse restResult)
        {
            var modules = new List<Student>();

            if (_context.Student.Any())
            {
                _context.Database.ExecuteSqlCommand("TRUNCATE TABLE student");
            }


            foreach (var respStu in restResult.Students)
            {
                Student newStu = new Student
                {
                    IdUsuario = respStu.user_iduser,
                    Name = respStu.last_name + respStu.first_name
                };


                _context.Add(newStu);

                _context.SaveChanges();

            }

            return modules;
        }

        [HttpPost]
        public async Task<StudentResponse> LoadStudentsAsync(int idModule)
        {
            //var Url = "http://www.mocky.io/v2/5a3a794731000082148e95ab";

            var Url = "http://192.168.42.27/studentsJson/" + idModule;

            string data;
            
            var StudentRequest = new StudentRequest
            {
                idModule = idModule
            };

            string Json = JsonConvert.SerializeObject(StudentRequest);

            var request = new StringContent(Json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(Url))
                {
                    using (HttpContent content = res.Content)
                    {
                        data = await content.ReadAsStringAsync();
                    }
                }
            }

            return JsonConvert.DeserializeObject<StudentResponse>(data);
        }
    }
}
