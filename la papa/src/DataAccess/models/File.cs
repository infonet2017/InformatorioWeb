using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class File
    {
        public int IdFile { get; set; }
        public string Extension { get; set; }
        public int? SupportId { get; set; }
        public int SupportIdSupport { get; set; }

        public virtual Support SupportIdSupportNavigation { get; set; }
    }
}
