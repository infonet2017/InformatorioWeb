using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class Support
    {
        public Support()
        {
            File = new HashSet<File>();
        }

        public int IdSupport { get; set; }
        public string Name { get; set; }
        public int ModuleIdmodule { get; set; }

        public virtual ICollection<File> File { get; set; }
        public virtual Module ModuleIdmoduleNavigation { get; set; }
    }
}
