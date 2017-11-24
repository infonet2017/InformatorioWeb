using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.models;

namespace AspNetCoreFileUploadFileTable.Controllers
{
    public class PostsController : Controller
    {
        private readonly info2017Context _context;

        public PostsController()
        {

            _context = new info2017Context();
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var info2017Context = _context.Post.Include(p => p.ModuleIdmoduleNavigation).Include(p => p.TeacherIdTeacherNavigation);
            return View(await info2017Context.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.ModuleIdmoduleNavigation)
                .Include(p => p.TeacherIdTeacherNavigation)
                .SingleOrDefaultAsync(m => m.IdPost == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["ModuleIdmodule"] = new SelectList(_context.Module, "Idmodule", "Name");
            ViewData["TeacherIdTeacher"] = new SelectList(_context.Teacher, "IdTeacher", "Name");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPost,Description,DateTimePost,Title,ModuleIdmodule,TeacherIdTeacher")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModuleIdmodule"] = new SelectList(_context.Module, "Idmodule", "Name", post.ModuleIdmodule);
            ViewData["TeacherIdTeacher"] = new SelectList(_context.Teacher, "IdTeacher", "Name", post.TeacherIdTeacher);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.SingleOrDefaultAsync(m => m.IdPost == id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["ModuleIdmodule"] = new SelectList(_context.Module, "Idmodule", "Name", post.ModuleIdmodule);
            ViewData["TeacherIdTeacher"] = new SelectList(_context.Teacher, "IdTeacher", "Name", post.TeacherIdTeacher);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPost,Description,DateTimePost,Title,ModuleIdmodule,TeacherIdTeacher")] Post post)
        {
            if (id != post.IdPost)
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
                    if (!PostExists(post.IdPost))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModuleIdmodule"] = new SelectList(_context.Module, "Idmodule", "Name", post.ModuleIdmodule);
            ViewData["TeacherIdTeacher"] = new SelectList(_context.Teacher, "IdTeacher", "Name", post.TeacherIdTeacher);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.ModuleIdmoduleNavigation)
                .Include(p => p.TeacherIdTeacherNavigation)
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
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.IdPost == id);
        }
    }
}
