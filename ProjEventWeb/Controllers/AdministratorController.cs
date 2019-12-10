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
    public class AdministratorController : Controller
    {
        private readonly ProjEventDbContext _context;

        public AdministratorController(ProjEventDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            //  var userLogged = HttpContext.Session.GetString("Usuario");
            //  var usuario = JsonConvert.DeserializeObject<UserProfile>(userLogged);

            var eventSold = from m in _context.Events
                            where m.Id != 0
                            select m;

            var ue = _context.UserProfiles.Include(o => o.UserEvents).ThenInclude(i => i.Event).ToList();

            //List<UserEvent> list = ue.ToList();

            List<ManagementViewModel> listEvent = new List<ManagementViewModel>();

            foreach (var item in ue)
            {
                foreach (var itemb in item.UserEvents)
                {
                    listEvent.Add(new ManagementViewModel
                    {

                        UserName = item.Name,
                        EventName = itemb.Event.Description,
                        EventDate = itemb.Event.Date,
                        EventType = itemb.Event.Category,
                        EventCertificate = itemb.Certificate 

                        
                    });
                }

            }
            return View(listEvent);
            //return View();

        }
    }
}
