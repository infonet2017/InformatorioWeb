using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoNET_DB.Models;
using ProyectoNET_DB.Info2017;

namespace ProyectoNET_DB.API
{
    [Produces("application/json")]
    [Route("api/Posts")]
    public class PostsController : Controller
    {
        private readonly info2017Context _context;

        public PostsController(info2017Context context)
        {
            _context = context;
        }

        // GET: api/Posts/idModule
        [HttpGet("{idModule}")]
        public IEnumerable<Post> GetPosts([FromRoute] int idModule)
        {
            return _context.Post.Where(m => m.IdModule == idModule);
        }
        

    }
}