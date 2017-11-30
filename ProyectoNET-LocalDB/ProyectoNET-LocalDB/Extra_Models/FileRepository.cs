using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoNET_LocalDB.Models;

namespace ProyectoNET_LocalDB.Extra_Models
{

    public class FileRepository
    {

        private readonly InfoDbContext _context;
        

        public FileRepository(InfoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FileDescriptionShort> AddFileDescriptions(FileResult fileResult)
        {
            List<string> filenames = new List<string>();
            for (int i = 0; i < fileResult.FileNames.Count(); i++)
            {

                int index = fileResult.FileNames[i].LastIndexOf("\\");
                var shortName = fileResult.FileNames[i].Substring(index + 1);
                var module = _context.ActualModules.FirstOrDefault();

                var fileDescription = new FileDescription
                {
                    ContentType = fileResult.ContentTypes[i],
                    FileName = shortName,
                    CreatedTimestamp = fileResult.CreatedTimestamp,
                    UpdatedTimestamp = fileResult.UpdatedTimestamp,
                    Description = fileResult.Description,
                    Modulo = _context.Modules.Single(p => p.ID == module.ActualModulo),
                    Teacher = _context.Teachers.Single(n => n.ID == module.TeacherID)
                };

                fileDescription.TeacherName = fileDescription.Teacher.Name;

                fileDescription.ModuleName = fileDescription.Modulo.Name;

                filenames.Add(fileResult.FileNames[i]);
                _context.FileDescriptions.Add(fileDescription);
            }

            _context.SaveChanges();
            return GetNewFiles(filenames);
        }

        private IEnumerable<FileDescriptionShort> GetNewFiles(List<string> filenames)
        {
            IEnumerable<FileDescription> x = _context.FileDescriptions.Where(r => filenames.Contains(r.FileName));
            return x.Select(t => new FileDescriptionShort { Id = t.Id, Description = t.Description });
        }


    }
}

