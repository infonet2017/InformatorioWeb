﻿using System;
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
            List<Auxiliarmodules> Modulos = await _context.Auxiliarmodules.Include("Teacher").ToListAsync();

            return View(Modulos);
        }

        // GET: Modules/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var module = _context.Actualmodule.FirstOrDefault();

            module.ActualModule = id;

            _context.Update(module);
            _context.SaveChanges();


            if (@module == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Posts", new { Module = id});
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

        //GET: Course/Modules
        [HttpPost]
        public async Task<ActionResult> GetModules([FromBody] CourseResponse courseResponse)
        {
            var fakeResponse = LoadModulesAsync(courseResponse).Result;//cargo el jotason desde un archivo para simular la request a la api rancia del equipo de django

            var task = ModuleMappingAsync(fakeResponse);

            return RedirectToAction("Index", "Course");
        }



        public async Task<List<Auxiliarmodules>> ModuleMappingAsync(ModuleResponse restResult)
        {
            var modules = new List<Auxiliarmodules>();

            if (_context.Teacher.Any())
            {
                _context.Database.ExecuteSqlCommand("TRUNCATE TABLE teacher");
            }

            if (_context.Student.Any())
            {
                _context.Database.ExecuteSqlCommand("TRUNCATE TABLE student");
            }

            if (_context.Auxiliarmodules.Any())
            {
                _context.Database.ExecuteSqlCommand("SET FOREIGN_KEY_CHECKS=0; TRUNCATE TABLE auxiliarmodules");
            }
            

            foreach (var respModule in restResult.modules)
            {
                Auxiliarmodules newMod = new Auxiliarmodules();
                newMod.IdModule = respModule.idModule;
                newMod.Name = respModule.name;
                newMod.Description = respModule.description;
                newMod.Teacher = new List<Teacher>();

                foreach (var teacher in respModule.teachers)
                {
                    Teacher tea = new Teacher();
                    tea.IdUser = teacher.idTeacher;
                    tea.IdAuxiliarModules = newMod.IdauxiliarModules;
                    tea.Lastname = teacher.lastname;
                    tea.Firstname = teacher.firstname;
                    newMod.Teacher.Add(tea);
                }
                
                _context.Add(newMod);

                _context.SaveChanges();

            }




            return modules;
        }

        [HttpPost]
        public async Task<ModuleResponse> LoadModulesAsync([FromBody] CourseResponse course)
        {
            var Url = "http://www.mocky.io/v2/5a3886d33200003e35eb6c77";

            string data;

            if (_context.Actualmodule.Any())
            {
                _context.Database.ExecuteSqlCommand("TRUNCATE TABLE actualmodule");
            }

            var Actualmodule = new Actualmodule
            {

                IdTeacher = course.id_user,
                FirstName = course.first_name,
                LastName = course.last_name,
                Dni = course.dni,
                Email = course.email,

            };

            _context.Actualmodule.Add(Actualmodule);

            _context.SaveChanges();


            var ModuleRequest = new ModuleRequest
            {
                idCourse = course.id_course,
                idUser = course.id_user
            };

            string Json = JsonConvert.SerializeObject(ModuleRequest);

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

            return JsonConvert.DeserializeObject<ModuleResponse>(data);
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
