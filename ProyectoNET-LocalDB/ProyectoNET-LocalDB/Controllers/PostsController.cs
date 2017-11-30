using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoNET_LocalDB.Models;

namespace ProyectoNET_LocalDB.Controllers
{
    public class PostsController : Controller
    {
        private readonly InfoDbContext _context;

        public Module Modulo { get; set; }

        public PostsController(InfoDbContext context)
        {
            _context = context;
        }

    // GET: Posts/Module
    public async Task<IActionResult> Index(int Module)
        {
            var Modulo = _context.ActualModules.FirstOrDefault();
            List<Post> post = await _context.Posts.Where(m => m.Module.ID == Module).ToListAsync();
            return View(post);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.SingleOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Post post)
        {
            var Modulo = _context.ActualModules.FirstOrDefault();

            post.Module = _context.Modules.FirstOrDefault(m => m.ID == Modulo.ActualModulo);
            post.Teacher = _context.Teachers.FirstOrDefault(m => m.ID == Modulo.TeacherID);
            post.NameTeacher = post.Teacher.Name;
            post.DateTime = DateTime.Today;

                _context.Add(post);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Posts", new { Module = Modulo.ActualModulo });
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.SingleOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DateTime")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var Modulo = _context.ActualModules.FirstOrDefault();
                return RedirectToAction("Index", "Posts", new { Module = Modulo });
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .SingleOrDefaultAsync(m => m.Id == id);
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
            var post = await _context.Posts.SingleOrDefaultAsync(m => m.Id == id);
            var Modulo = _context.ActualModules.FirstOrDefault();
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Posts", new { Module = Modulo});
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
