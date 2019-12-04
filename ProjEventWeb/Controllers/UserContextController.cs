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
    public class UserContextController : Controller
    {
        private readonly ProjEventDbContext _context;

        public UserContextController(ProjEventDbContext context) {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();

        }
    }
}
