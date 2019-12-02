using System;
using System.Collections.Generic;
using System.Linq;
using ProjEventWeb.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjEventWeb.Controllers
{
    public class EventController : Controller
    {

        private readonly ProjEventDbContext _context;
        public EventController(ProjEventDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string eventCategory, string searchString)
        {
            IQueryable<string> categoryQuery = from m in _context.Events
                                               orderby m.Category
                                               select m.Category;
            var @event = from m in _context.Events
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                @event = @event.Where(s => s.Description.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(eventCategory))
            {
                @event = @event.Where(x => x.Category == eventCategory);
            }

            var eventCategoryVM = new EventCategoryViewModel {
                Categories = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Events = await @event.ToListAsync()
            };
            return View(eventCategoryVM);
            // var @event = from m in _context.Events
            //             select m;

            // if (!String.IsNullOrEmpty(searchString)){
            //     @event = @event.Where(s => s.Description.Contains(searchString));
            // }                       
            // return View(await @event.ToListAsync());
        }
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on" + searchString;
        }

        //GET: Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @event = await _context.Events
                .FirstOrDefaultAsync(e => e.Id == id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        //GET: Event/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Price,Date,Details, Quantity")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        //GET: Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        //POST: Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Price,Date,Category,Details, Quantity")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            return View(@event);
        }

        //GET: Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        //POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}