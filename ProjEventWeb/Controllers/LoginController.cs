using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjEventWeb.Models;

namespace ProjEventWeb.Controllers
{
    public class LoginController : Controller
    {

        private readonly ProjEventDbContext _context;

        public LoginController(ProjEventDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Email, Password")]Login login)
        {
            if (ModelState.IsValid)
            {

                var user = _context.Users.FirstOrDefault(x => x.Email.Equals(login.Email) && x.Password.Equals(login.Password));

                if (user == null)
                {

                    return RedirectToAction("", "Login", null);
                }
                else 
                {
                    HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(user));
                    var xyz = HttpContext.Session.GetString("Usuario");
                    if (user.Administrator)
                    {
                        return RedirectToAction("", "Administrator", null);
                    }
                    return RedirectToAction("", "UserContext", null);
                }
            }
            return null;

        }
        public IActionResult Redirect()
        {
            return RedirectToAction("Create", "RegisterUser", null);
        }
    }
}