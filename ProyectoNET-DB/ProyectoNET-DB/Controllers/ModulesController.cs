using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoNET_DB.Info2017;

namespace ProyectoNET_LocalDB.Controllers
{
    public class ModulesController : Controller
    {
        private readonly info2017Context _context;

        public ModulesController(info2017Context context)
        {
            _context = context;
        }

        // GET: Modules
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Informatorio";
            List<Auxiliarmodules> Modulos = await _context.Auxiliarmodules.ToListAsync();
            foreach (var item in Modulos)
            {
                item.Teacher = await _context.Teacher.Where(p => p.IdAuxiliarModules == item.IdModule).ToListAsync();
            }
            return View(Modulos);
        }

        // GET: Modules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var module = _context.Auxiliarmodules.FirstOrDefault(m => m.IdauxiliarModules == id);
            var teacher = _context.Teacher.LastOrDefault(m => m.IdAuxiliarModules == id);

            if (_context.Actualmodule.Any())
            {
                _context.Database.ExecuteSqlCommand("TRUNCATE TABLE Actualmodule");
            }

            var ActualModule = new Actualmodule();
            ActualModule.ActualModule = module.IdModule;
            ActualModule.IdTeacher = teacher.IdUser;

            _context.Actualmodule.Add(ActualModule);

            _context.SaveChanges();

            if (@module == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index","Posts", new { Module = module.IdModule });
        }

        //// GET: Modules/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Modules/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Name")] Auxiliarmodules @module)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(@module);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(@module);
        //}


    }
}
