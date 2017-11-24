using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaFiles.Models
{
    public class SupportContext : DbContext
    {
        public SupportContext()
            : base(nameOrConnectionString: "name=FilesDB")
        {
        }
        public DbSet<Support> Supports { get; set; }
        public DbSet<FileDetail> FileDetails { get; set; }
    }
}