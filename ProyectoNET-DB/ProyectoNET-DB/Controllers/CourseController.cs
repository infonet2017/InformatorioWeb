using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoNET_DB.Extra_Models;
using Microsoft.AspNetCore.Routing;
using ProyectoNET_DB.Info2017;
using System.IO;
using ProyectoNET_DB.Models.RestModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ProyectoNET_DB.Controllers
{
    public class CourseController : Controller
    {
        private readonly info2017Context _context;

        public CourseController(info2017Context context)
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


        // GET: Course/Modules
        //[HttpPost]
        //public async Task<IActionResult> Modules([FromBody] CourseResponse courseResponse)
        //{
        //    var fakeResponse = LoadModulesAsync(courseResponse);//cargo el jotason desde un archivo para simular la request a la api rancia del equipo de django

        //    var modules = ModuleMapping(fakeResponse.Result);


        //    return Ok(courseResponse);
        //    return RedirectToAction("Index", "Course");
        //}

               // GET: Course/Modules
        //[HttpPost]
        //public List<Auxiliarmodules> Modules([FromBody] CourseResponse courseResponse)
        //{
        //    var fakeResponse = LoadModulesAsync(courseResponse);//cargo el jotason desde un archivo para simular la request a la api rancia del equipo de django

        //    var modules = ModuleMapping(fakeResponse.Result);


        //    return modules;
        //    //return RedirectToAction("Index", "Course");
        //}



        public List<Auxiliarmodules> ModuleMapping(ModuleResponse restResult)
        {
            var modules = new List<Auxiliarmodules>();
            foreach (var respModule in restResult.Modulos)
            {
                var newMod = new Auxiliarmodules();
                newMod.IdModule = respModule.IDModulo;
                newMod.Name = respModule.Name;
                newMod.Teacher = new List<Teacher>();

                foreach (var teacher in respModule.Docentes)
                {
                    var tea = new Teacher();
                    tea.IdTeacher = teacher.IDDocente;
                    tea.IdAuxiliarModules = newMod.IdauxiliarModules;
                    tea.Name = teacher.Nombre;
                    newMod.Teacher.Add(tea);

                }
                newMod.Description = respModule.Descripcion;
                modules.Add(newMod);
            }
            return modules;
        }


        public async Task<string> LoadModulesAsync(CourseResponse course)
        {
            var Url = "http://localhost:61350/Modules/ProudModulesAsync";

            string data;

            string Json = JsonConvert.SerializeObject(course);

            var request = new StringContent(Json, Encoding.UTF8,"application/json");

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(Url,request))
                {
                    using (HttpContent content = res.Content)
                    {
                        data = await content.ReadAsStringAsync();
                    }
                }
            }

            //return JsonConvert.DeserializeObject<ModuleResponse>(data);

            return data;
        }

        [HttpPost]
        public string ProudModulesAsync([FromBody] CourseResponse course)
        {

            return JsonConvert.SerializeObject(course);
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
        //    // var name = response2.Data.Name;
        //    return algo

        //}

    }
}
