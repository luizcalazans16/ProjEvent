using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjEventWeb
{

    public class EventController : ControllerBase
    {
        private readonly ProjEventWeb _context;
        public EventController(ProjEventWeb context)
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
            catch (System.Exception ex)
            {
                return ex;
            }
        }



        // GET BY ID
        [HttpGet("{Id}")]
        public async Task<ActionResult<Event>> GetEvent(int Id)
        {
            try
            {
                var result = await _context.Event.FindAsync(Id);
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
                _context.Event.Add(events);
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
        public async Task<ActionResult> Put([FromBody] EventArgs events) {
            try
            {
                var getEvent = await _context.Event.FindAsync(events.Id);
                if (getEvent != null) {
                    _context.Event.Update(events);
                    await _context.Event.SaveChangesAsync();
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







