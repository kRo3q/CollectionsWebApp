using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollectionsWebApp.Data;
using CollectionsWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace CollectionsWebApp.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly CollectionsWebAppContext _context;
        private readonly UserManager<User> _userMenager;


        public CollectionsController(CollectionsWebAppContext context, UserManager<User> userManager)
        {
            _context = context;
            _userMenager = userManager;
        }

        // GET: Collections
        public async Task<IActionResult> Index()
        {
              return _context.Collections != null ? 
                          View(await _context.Collections.ToListAsync()) :
                          Problem("Entity set 'CollectionsWebAppContext.Collections'  is null.");
        }

        // GET: Collections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Collections == null)
            {
                return NotFound();
            }

            var collection = await _context.Collections
                .FirstOrDefaultAsync(m => m.CollectionId == id);
            if (collection == null)
            {
                return NotFound();
            }

            return View(collection);
        }

        // GET: Collections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Collections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollectionId,Name,Description,Image,UserId")] Collection collection)
        {
            collection.UserId = _userMenager.GetUserId(User);

                _context.Add(collection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }

        // GET: Collections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Collections == null)
            {
                return NotFound();
            }

            var collection = await _context.Collections.FindAsync(id);
            if (collection == null)
            {
                return NotFound();
            }
            return View(collection);
        }

        // POST: Collections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollectionId,Name,Description,Image")] Collection collection)
        {
            if (id != collection.CollectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollectionExists(collection.CollectionId))
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
            return View(collection);
        }

        // GET: Collections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Collections == null)
            {
                return NotFound();
            }

            var collection = await _context.Collections
                .FirstOrDefaultAsync(m => m.CollectionId == id);
            if (collection == null)
            {
                return NotFound();
            }

            return View(collection);
        }

        // POST: Collections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Collections == null)
            {
                return Problem("Entity set 'CollectionsWebAppContext.Collections'  is null.");
            }
            var collection = await _context.Collections.FindAsync(id);
            if (collection != null)
            {
                _context.Collections.Remove(collection);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollectionExists(int id)
        {
          return (_context.Collections?.Any(e => e.CollectionId == id)).GetValueOrDefault();
        }
    }
}
