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
    public class CupomController : ControllerBase
    {
        public readonly ProjEventDbContext _context;

        public CupomController(ProjEventDbContext context)
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
        public async Task<ActionResult> Post(Cupom cupons) {
            try
            {
                _context.Cupons.Add(cupons);
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