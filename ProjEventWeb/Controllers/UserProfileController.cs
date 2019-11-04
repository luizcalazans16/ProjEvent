using System;
using System.Collections.Generic;
using System.Linq;
using ProjEventWeb.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ProjEventWeb.Controllers
{
    public class UserProfileController : ControllerBase
    {
        private readonly ProjEventDbContext _context;
        public UserProfileController(ProjEventDbContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfile>>> GetAll()
        {
            try
            {
                var result = await _context.Users.ToListAsync();
                if (result.Any())
                {
                    return result;
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //GET
        [HttpGet("{Id}")]

        public async Task<ActionResult<UserProfile>> getUser(int Id)
        {
            try
            {
                var result = await _context.Users.FindAsync(Id);
                if (result != null)
                {
                    return result;
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //POST
        [HttpPost]
        public async Task<ActionResult> POST(UserProfile user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //UPDATE
        [HttpPut]

        public async Task<ActionResult> Put([FromBody]UserProfile user)
        {
            try
            {
                var getUser = await _context.Users.FindAsync(user.Id);
                if (getUser != null)
                {
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //DELETE
        [HttpDelete("{Id}")]

        public async Task<ActionResult> Delete(int Id)
        {
            try
            {
                var dlt = await _context.Users.FindAsync(Id);
                if (dlt != null)
                {
                    _context.Users.RemoveRange(dlt);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
