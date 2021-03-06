﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using ProyectoNET_DB.Extra_Models;
using Microsoft.EntityFrameworkCore;
using ProyectoNET_DB.Info2017;

namespace ProyectoNET_DB.Controllers
{
    public class FileClientController : Controller
    {
        private readonly FileRepository _fileRepository;
        private readonly info2017Context _context;
        private string pathFolder = "./Files";

        public FileClientController(FileRepository fileRepository, info2017Context context)
        {
            _fileRepository = fileRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var module = _context.Actualmodule.FirstOrDefault();

            UserData user = new UserData
            {
                FirstName = module.FirstName,
                LastName = module.LastName,
                Dni = module.Dni,
                Email = module.Email
            };

            ViewBag.user = user;

            ViewBag.title = _context.Auxiliarmodules.Single(p => p.IdModule == module.ActualModule).Name;

            List<Filedescription> Files = await _context.Filedescription.Where(m => m.IdModule == module.ActualModule & m.IsDeleted==false).ToListAsync();

            return View(Files);
        }

        public ActionResult AgregarArchivos()
        {
            var module = _context.Actualmodule.FirstOrDefault();

            UserData user = new UserData
            {
                FirstName = module.FirstName,
                LastName = module.LastName,
                Dni = module.Dni,
                Email = module.Email
            };

            ViewBag.user = user;
            
            ViewBag.title = _context.Auxiliarmodules.Single(p => p.IdModule == module.ActualModule).Name;

            return View();
        }

        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var module = _context.Actualmodule.FirstOrDefault();

            UserData user = new UserData
            {
                FirstName = module.FirstName,
                LastName = module.LastName,
                Dni = module.Dni,
                Email = module.Email
            };

            ViewBag.user = user;

            ViewBag.title = _context.Auxiliarmodules.Single(p => p.IdModule == module.ActualModule).Name;

            if (id == null)
            {
                return NotFound();
            }


            var File = _context.Filedescription.Single(m => m.IdfileDescription == id);
            if (File == null)
            {
                return NotFound();
            }

            return View(File);
        }


        [Route("delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var File = _context.Filedescription.Single(m => m.IdfileDescription == id);
            var Modulo = _context.Actualmodule.FirstOrDefault();

            File.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "FileClient", "");
        }
        
        /// <summary>
        /// Just a test method to view all files.
        /// </summary>


        [Route("download/{id}")]
        [HttpGet]
        public FileStreamResult Download(int id)
        {
            Filedescription fileDescription = _context.Filedescription.Single(m => m.IdfileDescription == id);

            var path = pathFolder + "\\" + fileDescription.FileName;
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, fileDescription.ContentType);
        }


        [Route("files")]
        [HttpPost]
        public async Task<IActionResult> UploadFiles(FileDescriptionShort fileDescriptionShort)
        {
            var names = new List<string>();
            var contentTypes = new List<string>();
            if (fileDescriptionShort.File != null)
            {
                if (ModelState.IsValid)
                {
                    // http://www.mikesdotnetting.com/article/288/asp-net-5-uploading-files-with-asp-net-mvc-6
                    // http://dotnetthoughts.net/file-upload-in-asp-net-5-and-mvc-6/

                    foreach (var file in fileDescriptionShort.File)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');
                            contentTypes.Add(file.ContentType);

                            names.Add(fileName);

                            // Extension method update RC2 has removed this 
                            await file.SaveAsAsync(Path.Combine(pathFolder, fileName));
                        }
                    }
                }

                var module = _context.Actualmodule.FirstOrDefault();

                var files = new ProyectoNET_DB.Extra_Models.FileResult
                {
                    FileNames = names,
                    ContentTypes = contentTypes,
                    Description = fileDescriptionShort.Description,
                    CreatedTimestamp = DateTime.Now,
                    UpdatedTimestamp = DateTime.Now,
                    idModule = module.ActualModule,
                    Teacher = _context.Teacher.Single(p => p.IdUser == module.IdTeacher)
                    
                };

                _fileRepository.AddFileDescriptions(files);
            }
            return RedirectToAction("Index", "FileClient");
        }

    }
}
