using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ProyectoNET_LocalDB.Models
{
    public class FileDescriptionShort
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public ICollection<IFormFile> File { get; set; }
        public virtual Module Modulo { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}