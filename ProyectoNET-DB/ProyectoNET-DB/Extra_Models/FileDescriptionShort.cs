using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using ProyectoNET_DB.Info2017;

namespace ProyectoNET_DB.Info2017
{
    public class FileDescriptionShort
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public ICollection<IFormFile> File { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}