using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoNET_DB.Info2017;
using ProyectoNET_DB.Extra_Models;

namespace ProyectoNET_DB.Extra_Models
{

    public class FileRepository
    {

        private readonly info2017Context _context;
        

        public FileRepository(info2017Context context)
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
                var module = _context.Actualmodule.FirstOrDefault();

                var fileDescription = new Filedescription
                {
                    ContentType = fileResult.ContentTypes[i],
                    FileName = shortName,
                    CreatedTimestamp = fileResult.CreatedTimestamp,
                    UpdatedTimestamp = fileResult.UpdatedTimestamp,
                    Description = fileResult.Description,
                    IdModule = _context.Auxiliarmodules.Single(p => p.IdModule == module.ActualModule).IdModule,
                    IdTeacher = _context.Teacher.Single(n => n.IdUser == module.IdTeacher).IdUser,
                    IsDeleted = false
                };

                fileDescription.TeacherName = _context.Teacher.Single(n => n.IdUser == fileDescription.IdTeacher).Name;

                fileDescription.ModuleName = _context.Auxiliarmodules.Single(p => p.IdModule == fileDescription.IdModule).Name;

                filenames.Add(fileResult.FileNames[i]);
                _context.Filedescription.Add(fileDescription);
            }

            _context.SaveChanges();
            return GetNewFiles(filenames);
        }

        private IEnumerable<FileDescriptionShort> GetNewFiles(List<string> filenames)
        {
            IEnumerable<Filedescription> x = _context.Filedescription.Where(r => filenames.Contains(r.FileName));
            return x.Select(t => new FileDescriptionShort { Id = t.IdfileDescription, Description = t.Description });
        }


    }
}

