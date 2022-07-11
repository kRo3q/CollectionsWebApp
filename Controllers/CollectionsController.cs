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
using Microsoft.AspNetCore.Authorization;

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

        public async Task<IActionResult> Index()
        {
            return _context.Collections != null ?
                          View(await _context.Collections.ToListAsync()) :
                          Problem("Entity set 'CollectionsWebAppContext.Collections'  is null.");
        }

        // GET: Collections
        [Authorize]
        public async Task<IActionResult> MyCollections()
        {
            var userId = _userMenager.GetUserId(User);
            return _context.Collections != null ? 
                          View(await _context.Collections.Where(x => x.UserId == userId).ToListAsync()) :
                          Problem("Entity set 'CollectionsWebAppContext.Collections'  is null.");
        }

        // GET: Collections/Details/5
        [Authorize]
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
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Collections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Collection model)
        {
            var userId = _userMenager.GetUserId(User);

            if (userId != null)
            {
                var currentUser = _context.Users.Include(c => c.Collections).First(c => c.Id == userId);
                List<Collection> collections = new List<Collection>();
                collections = currentUser.Collections.ToList();
                collections.Add(new Collection() {
                    Name = model.Name,
                    Description = model.Description,
                    Image = model.Image
                });
                currentUser.Collections = collections;
                await _context.SaveChangesAsync();
            }
                return RedirectToAction(nameof(MyCollections));
        }

        // GET: Collections/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Collections == null)
            {
                return NotFound();
            }

            var model = await _context.Collections.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Collections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, Collection model)
        {
            if (id != model.CollectionId)
            {
                return NotFound();
            }

            try
            {
                var userId = _userMenager.GetUserId(User);
                var currentUser = _context.Users.Include(c => c.Collections).First(c => c.Id == userId);

                List<Collection> collections = new List<Collection>();
                collections = currentUser.Collections.ToList();
                var index = collections.FindIndex(c => c.CollectionId == id);

                collections[index] = new Collection()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Image = model.Image
                };
                currentUser.Collections = collections;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(model.CollectionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(MyCollections));
        }

        // GET: Collections/Delete/5
        [Authorize]
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
        [Authorize]
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
            return RedirectToAction(nameof(MyCollections));
        }

        private bool CollectionExists(int id)
        {
          return (_context.Collections?.Any(e => e.CollectionId == id)).GetValueOrDefault();
        }
    }
}
