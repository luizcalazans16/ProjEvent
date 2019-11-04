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
    [Controller]
    [Route("api/[controller]")]

    public class EventController : ControllerBase
    {
        private readonly ProjEventDbContext _context;
        public EventController(ProjEventDbContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Event>>> GetAll()
        {
            try
            {
                var result = await _context.Events.ToListAsync();
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



        // GET BY ID
        [HttpGet("{Id}")]
        public async Task<ActionResult<Event>> getEvent(int Id)
        {
            try
            {
                var result = await _context.Events.FindAsync(Id);
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
        [HttpPost]
        public async Task<ActionResult> POST(Event events)
        {
            try
            {
                _context.Events.Add(events);
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
        public async Task<ActionResult> Put([FromBody] Event events)
        {
            try
            {
                var getEvent = await _context.Events.FindAsync(events.Id);
                if (getEvent != null)
                {
                    _context.Events.Update(events);
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







