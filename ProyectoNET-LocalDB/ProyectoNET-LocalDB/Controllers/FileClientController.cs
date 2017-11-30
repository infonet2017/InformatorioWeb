using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using ProyectoNET_LocalDB.Extra_Models;
using ProyectoNET_LocalDB.Models;

namespace ProyectoNET_LocalDB.Controllers
{
    public class FileClientController : Controller
    {
        private readonly IFileRepository _fileRepository;

        private string pathFolder = "./Files";

        public FileClientController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Index Page";

            return View();
        }

        public ActionResult Client()
        {
            ViewBag.Title = "Cargar Archivo";

            return View();
        }
        

        /// <summary>
        /// Just a test method to view all files.
        /// </summary>
        public ActionResult ViewAllFiles()
        {
            var model = new AllUploadedFiles {FileShortDescriptions = _fileRepository.GetAllFiles().ToList()};
            return View(model);
        }

        [Route("download/{id}")]
        [HttpGet]
        public FileStreamResult Download(int id)
        {
            var fileDescription = _fileRepository.GetFileDescription(id);

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

            var files = new ProyectoNET_LocalDB.Models.FileResult
            {
                FileNames = names,
                ContentTypes = contentTypes,
                Description = fileDescriptionShort.Description,
                CreatedTimestamp = DateTime.UtcNow,
                UpdatedTimestamp = DateTime.UtcNow,
            };

            _fileRepository.AddFileDescriptions(files);

            return RedirectToAction("ViewAllFiles", "FileClient");
        }

    }
}
