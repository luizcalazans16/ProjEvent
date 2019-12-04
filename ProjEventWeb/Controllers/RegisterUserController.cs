using System;
using System.Collections.Generic;
using System.Linq;
using ProjEventWeb.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ProjEventWeb.Controllers
{
    public class RegisterUserController : Controller
    {
        private readonly ProjEventDbContext _context;
        public RegisterUserController(ProjEventDbContext context)
        {
            _context = context;
        }
        //GET: Register
        public IActionResult Index() {
            return View();
        }

        //GET: UserProfile/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PhoneNumber,CPF,SubscriptionType,Gender,Password,Course")]UserProfile user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(user));
            return RedirectToAction("","Home",null);
        }
        //GET:      
        public IActionResult GetUserEvent() {
            return View();
        }

        //GET: UserProfile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhoneNumber,CPF,SubscriptionType,Gender,Password,Course,")]UserProfile user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProfileExists(user.Id))
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
            return View(user);
        }

        private bool UserProfileExists(int id) {
            return _context.Users.Any(u => u.Id == id);
        }

    }
}
