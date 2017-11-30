﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoNET_LocalDB.Models
{
    public class Module
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
        public List<Teacher> Teachers { get; set; }
       // public List<FileDescriptionShort> FileShortDescriptions { get; set; }
    }
}