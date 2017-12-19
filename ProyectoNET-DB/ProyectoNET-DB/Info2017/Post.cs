using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ProyectoNET_DB.Info2017
{
    public partial class Post
    {
        
        public int IdPost { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }

        [JsonIgnore]
        public int IdModule { get; set; }

        [JsonIgnore]
        public int IdTeacher { get; set; }

        public string NameTeacher { get; set; }

        [JsonIgnore]
        public Modules IdModuleNavigation { get; set; }
    }
}
