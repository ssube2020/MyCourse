#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCourse.Data;
using MyCourse.Models;

namespace MyCourse.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category cat)
        {
            if (ModelState.IsValid)
            {
                _context.Category.Add(cat);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {


            var currentItem = _context.Category.Find(id);
            if(currentItem != null)
            {
                return View(currentItem);
            }
            



            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var category = await _context.Category.FindAsync(id);
            //if (category == null)
            //{
            //    return NotFound();
            //}
            return NotFound();
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category cat ,int  id)
        {
            if (_context.Category.Find(id) == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var todelete = _context.Category.Find(id);
                if(todelete != null)
                {
                    _context.Category.Remove(todelete);
                    _context.Category.Add(cat);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return View(cat);

        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.id == id);
        }
    }
}
