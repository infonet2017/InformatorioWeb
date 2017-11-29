using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoNET_LocalDB.Models;
using Microsoft.AspNetCore.Routing;
using ProyectoNET_LocalDB.Models.RestModels;
using Newtonsoft.Json;
using System.IO;
using RestSharp;

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



            var restResult = LoadFakeResponse();//cargo el jotason desde un archivo para simular la request a la api rancia del equipo de django
            var modules = new List<Module>();
            foreach (var respModule in restResult.Modulos)
            {
                var newMod = new Module();
                newMod.ID = respModule.IDModulo;
                newMod.Name = respModule.Descripcion;
                modules.Add(newMod);
            }

            return View(modules);
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

        public ModuleResponse LoadFakeResponse()
        {
            ModuleResponse fakeResponse;
            using (StreamReader r = new StreamReader("fakeResponse.json"))
            {
                string json = r.ReadToEnd();
                
                fakeResponse = JsonConvert.DeserializeObject<ModuleResponse>(json);
            }
            return fakeResponse;
        }

        //public ModuleResponse LoadModules(int idAlumno, int idCurso)
        //{
        //    var client = new RestClient("http://example.com");
        //    // client.Authenticator = new HttpBasicAuthenticator(username, password);

        //    var request = new RestRequest("modulo/", Method.GET);
        //    request.AddParameter("IDAlumno", idAlumno); // adds to POST or URL querystring based on Method
        //    request.AddParameter("IDCurso", idCurso);
        //    // or automatically deserialize result
        //    // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
        //    RestResponse<ModuleResponse> response2 = client.Execute<ModuleResponse>(request);
        //   // var name = response2.Data.Name;
        //    return algo

        //}
    }
}
