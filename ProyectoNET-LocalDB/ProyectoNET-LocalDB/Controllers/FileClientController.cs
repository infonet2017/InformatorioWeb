using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using ProyectoNET_LocalDB.Extra_Models;
using ProyectoNET_LocalDB.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoNET_LocalDB.Controllers
{
    public class FileClientController : Controller
    {
        private readonly FileRepository _fileRepository;
        private readonly InfoDbContext _context;
        private string pathFolder = "./Files";

        public FileClientController(FileRepository fileRepository, InfoDbContext context)
        {
            _fileRepository = fileRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Modulo = _context.ActualModules.FirstOrDefault();
            List<FileDescription> Files = await _context.FileDescriptions.Where(m => m.Modulo.ID == Modulo.ActualModulo).ToListAsync();

            ViewBag.title = _context.Modules.Single(p => p.ID == Modulo.ActualModulo).Name;
            return View(Files);
        }

        public ActionResult AgregarArchivos()
        {

            var Modulo = _context.ActualModules.FirstOrDefault();
            ViewBag.title = _context.Modules.Single(p => p.ID == Modulo.ActualModulo).Name;
            return View();
        }

        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {

            var Modulo = _context.ActualModules.FirstOrDefault();
            ViewBag.title = _context.Modules.Single(p => p.ID == Modulo.ActualModulo).Name;

            if (id == null)
            {
                return NotFound();
            }


            var File = _context.FileDescriptions.Single(m => m.Id == id);
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

            var File = _context.FileDescriptions.Single(m => m.Id == id);
            var Modulo = _context.ActualModules.FirstOrDefault();

            _context.FileDescriptions.Remove(File);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "FileClient", "");
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
        /// <summary>
        /// Just a test method to view all files.
        /// </summary>


        [Route("download/{id}")]
        [HttpGet]
        public FileStreamResult Download(int id)
        {
            FileDescription fileDescription = _context.FileDescriptions.Single(m => m.Id == id);

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

                var module = _context.ActualModules.FirstOrDefault();

                var files = new ProyectoNET_LocalDB.Models.FileResult
                {
                    FileNames = names,
                    ContentTypes = contentTypes,
                    Description = fileDescriptionShort.Description,
                    CreatedTimestamp = DateTime.UtcNow,
                    UpdatedTimestamp = DateTime.UtcNow,
                    Modulo = _context.Modules.Single(p => p.ID == module.ActualModulo),
                    Teacher = _context.Teachers.Single(p => p.ID == module.TeacherID)
                };

                _fileRepository.AddFileDescriptions(files);
            }
            return RedirectToAction("Index", "FileClient");
        }

    }
}
