using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoNET_LocalDB.Models;
using Microsoft.AspNetCore.Routing;

namespace ProyectoNET_LocalDB.Controllers
{
    public class ModulesController : Controller
    {
        private readonly InfoDbContext _context;

        public ModulesController(InfoDbContext context)
        {
            _context = context;
        }

        // GET: Modules
        public async Task<IActionResult> Index()
        {
            return View(await _context.Modules.ToListAsync());
        }

        // GET: Modules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = _context.Modules.FirstOrDefault(m => m.ID == id);
            var teacher = _context.Teachers.LastOrDefault(m => m.ModuleID.ID == id);

            if (_context.ActualModules.Any())
            {
                _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [ActualModules]");
            }

            var ActualModule = new ActualModule();
            ActualModule.ActualModulo = module.ID;
            ActualModule.TeacherID = teacher.ID;

            _context.ActualModules.Add(ActualModule);

            await _context.SaveChangesAsync();

            if (@module == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index","Posts", new { Module = id });
        }

        // GET: Modules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Module @module)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@module);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@module);
        }


    }
}
