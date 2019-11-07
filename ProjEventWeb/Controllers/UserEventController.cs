using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjEventWeb.Models;

namespace ProjEventWeb.Controllers
{
    public class UserEventController : Controller
    {
        private readonly ProjEventDbContext _context;

        public UserEventController(ProjEventDbContext context)
        {
            _context = context;
        }

        //GET: UserId
        public async Task<IActionResult> getById(int Id) {
            return View(await _context.Users.ToListAsync());
        }
        // GET: UserEvent
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.Where(o => o.Id == 1 ).Select(e=> e.UserEvents).ToListAsync());
        }

        // GET: UserEvent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEvent = await _context.UserEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEvent == null)
            {
                return NotFound();
            }

            return View(userEvent);
        }

        // GET: UserEvent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserEvent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Payment,Certificate,UserId,CupomId,EventId,Quantity")] UserEvent userEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userEvent);
        }

        // GET: UserEvent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEvent = await _context.UserEvent.FindAsync(id);
            if (userEvent == null)
            {
                return NotFound();
            }
            return View(userEvent);
        }

        // POST: UserEvent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Payment,Certificate,UserId,CupomId,EventId,Quantity")] UserEvent userEvent)
        {
            if (id != userEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserEventExists(userEvent.Id))
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
            return View(userEvent);
        }

        // GET: UserEvent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEvent = await _context.UserEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEvent == null)
            {
                return NotFound();
            }

            return View(userEvent);
        }

        // POST: UserEvent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userEvent = await _context.UserEvent.FindAsync(id);
            _context.UserEvent.Remove(userEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserEventExists(int id)
        {
            return _context.UserEvent.Any(e => e.Id == id);
        }
    }
}
