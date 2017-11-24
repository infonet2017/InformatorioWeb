using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class ModuleUser
    {
        public int IdModule { get; set; }
        public int IdUser { get; set; }

        public virtual Module IdModuleNavigation { get; set; }
    }
}
