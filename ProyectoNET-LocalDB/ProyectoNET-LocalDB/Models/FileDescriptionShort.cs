using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ProyectoNET_LocalDB.Models
{
    public class AllUploadedFiles
    {
        public List<FileDescriptionShort> FileShortDescriptions { get; set; }
       // public Module IdModule { get; set; }
    }

    public class FileDescriptionShort
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public ICollection<IFormFile> File { get; set; }
    }
}