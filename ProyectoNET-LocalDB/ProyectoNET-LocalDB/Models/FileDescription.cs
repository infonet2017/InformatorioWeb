using System;

namespace ProyectoNET_LocalDB.Models
{
    public class FileDescription
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
        public string ContentType { get; set; }
        public virtual Module Modulo { get; set; }
        public virtual Teacher Teacher { get; set; }
        public string TeacherName { get; set; }
        public string ModuleName { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}