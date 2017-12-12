using ProyectoNET_DB.Info2017;
using System;
using System.Collections.Generic;

namespace ProyectoNET_DB.Extra_Models
{
    public class FileResult
    {
        public List<string> FileNames { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
        public List<string> ContentTypes { get; set; }

        public virtual int? idModule { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}