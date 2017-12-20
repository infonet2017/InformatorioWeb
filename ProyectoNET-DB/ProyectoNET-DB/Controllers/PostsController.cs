using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoNET_DB.Info2017;
using ProyectoNET_DB.Extra_Models;

namespace ProyectoNET_DB.Controllers
{
    public class PostsController : Controller
    {
        private readonly info2017Context _context;

        public Auxiliarmodules Modulo { get; set; }

        public PostsController(info2017Context context)
        {
            _context = context;
        }

    // GET: Posts/Module
    public async Task<IActionResult> Index()
        {
            var module = _context.Actualmodule.FirstOrDefault();

            UserData user = new UserData
            {
                FirstName = module.FirstName,
                LastName = module.LastName,
                Dni = module.Dni,
                Email = module.Email
            };

            ViewBag.user = user;

            ViewBag.title = _context.Auxiliarmodules.Single(p => p.IdModule == module.ActualModule).Name;

            List<Post> post = await _context.Post.Where(m => m.IdModule == module.ActualModule).ToListAsync();
            return View(post);
        }
        

        // GET: Posts/Create
        public IActionResult Create()
        {

            var module = _context.Actualmodule.FirstOrDefault();

            UserData user = new UserData
            {
                FirstName = module.FirstName,
                LastName = module.LastName,
                Dni = module.Dni,
                Email = module.Email
            };

            ViewBag.user = user;

            ViewBag.title = _context.Auxiliarmodules.Single(p => p.IdModule == module.ActualModule).Name;

            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Post post)
        {
            var Modulo = _context.Actualmodule.FirstOrDefault();

            post.IdModule = Modulo.ActualModule;
            post.IdTeacher = Modulo.IdTeacher;
            post.NameTeacher = _context.Teacher.FirstOrDefault(m => m.IdUser == Modulo.IdTeacher).Lastname +" "+ _context.Teacher.FirstOrDefault(m => m.IdUser == Modulo.IdTeacher).Firstname;
            post.DateTime = DateTime.Now;
            post.IdTeacherNavigation = _context.UsuarioUsers.FirstOrDefault(m => m.Id == Modulo.IdTeacher);

           _context.Add(post);
            await _context.SaveChangesAsync();

           return RedirectToAction("Index", "Posts", new { Module = Modulo.ActualModule });
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var module = _context.Actualmodule.FirstOrDefault();

            UserData user = new UserData
            {
                FirstName = module.FirstName,
                LastName = module.LastName,
                Dni = module.Dni,
                Email = module.Email
            };

            ViewBag.user = user;
            
            ViewBag.title = _context.Auxiliarmodules.Single(p => p.IdModule == module.ActualModule).Name;

            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.SingleOrDefaultAsync(m => m.IdPost == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPost,Title,Description,DateTime")] Post post)
        {
            if (id != post.IdPost)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var pos = _context.Post.FirstOrDefault(p => p.IdPost == id);
                    pos.Title = post.Title;
                    pos.Description = post.Description;
                    pos.DateTime = DateTime.Now;


                    _context.Update(pos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.IdPost))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Posts");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var module = _context.Actualmodule.FirstOrDefault();

            UserData user = new UserData
            {
                FirstName = module.FirstName,
                LastName = module.LastName,
                Dni = module.Dni,
                Email = module.Email
            };

            ViewBag.user = user;

            ViewBag.title = _context.Auxiliarmodules.Single(p => p.IdModule == module.ActualModule).Name;
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .SingleOrDefaultAsync(m => m.IdPost == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var post = await _context.Post.SingleOrDefaultAsync(m => m.IdPost == id);

            _context.Post.Remove(post);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Posts");
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.IdPost == id);
        }
    }
}
