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
    public class SellingController : Controller
    {
        private readonly ProjEventDbContext _context;

        public SellingController(ProjEventDbContext context)
        {
            _context = context;
        }

        //GET: Selling
        public async Task<IActionResult> Index()
        {
            var @event = from m in _context.Events
                         select m;
            var x = new EventCategoryViewModel
            {
                Events = await @event.ToListAsync()
            };
            return View(x);
        }

        // GET: Selling/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var y = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (y == null)
            {
                return NotFound();
            }

            return View(y);
        }

        // GET: Selling/Create
        public IActionResult Create()
        {
            return View();
        }


        public IActionResult BuyTicket([Bind("EventId","Payment","Certificate")] UserEvent uservent)
        {
            _context.Add(uservent);
            return RedirectToAction("", "RegisterUser", null);
        }

        // POST: Selling/Create
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

        // GET: Selling/Edit/5
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

        // POST: Selling/Edit/5
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

        public async Task<IActionResult> TicketPurchase(int? id)
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


        // GET: Selling/Delete/5
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

        // POST: Selling/Delete/5
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
