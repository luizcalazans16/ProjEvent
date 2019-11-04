using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjEventWeb.Controllers
{
    public class CupomController : ControllerBase
    {
        public readonly ProjEventWeb _context;

        public CupomController(ProjEventWeb context)
        {
            _context = context;
        }

        //GET 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cupom>>> getAll()
        {
            try
            {
                var result = await _context.Cupons.ToListAsync();
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

        //GET by ID
        [HttpGet("{Id}")]
        public async Task<ActionResult<Cupom>> getCupom(int Id)
        {
            try
            {
                var result = await _context.Cupons.FindAsync(Id);
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
        public async Task<ActionResult> Post(Cupom cupom) {
            try
            {
                _context.Cupons.Add(cupom);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}