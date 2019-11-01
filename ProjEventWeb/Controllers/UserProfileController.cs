using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ProjEventWeb
{
    public class UserProfileController : ControllerBase
    {
        private readonly ProjEventDbContext _context;
        public UserProfileController(ProjEventDbContext context)
        {
            _context = context;
        }

        //     //GET
        //     [HttpGet]
        //     public async Task
    }
}
