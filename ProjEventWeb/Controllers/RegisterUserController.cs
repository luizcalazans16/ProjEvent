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
        public async Task<IActionResult> Index() {
             var userLogged = HttpContext.Session.GetString("Usuario");
             var usuario = JsonConvert.DeserializeObject<UserProfile>(userLogged);

            var eventSold = from m in _context.Events
                                where m.Id != 0
                                select m;
                                
            var ue = await _context.UserProfiles.Include(o => o.UserEvents).ThenInclude(i => i.Event).FirstOrDefaultAsync(o => o.Id == usuario.Id);

           var zz = new UserEventListViewModel {
               
               UserEvent = ue.UserEvents,
               UserProfile = ue
            };
            return View(zz);
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
            HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(user));
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
