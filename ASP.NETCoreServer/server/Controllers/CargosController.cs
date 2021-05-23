using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly EmsContext Context;

        public CargosController(EmsContext context)
        {
            Context = context;
        }

        // GET: api/Cargos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargos>>> GetCargos()
        {
            return await Context.Cargos.ToListAsync();
        }

        // GET: api/Cargos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cargos>> GetCargo(int id)
        {
            var cargo = await Context.Cargos.FindAsync(id);

            if (cargo == null)
            {
                return NotFound();
            }

            return cargo;
        }

        // PUT: api/Cargos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargo(int id, Cargos cargo)
        {
            if (id != cargo.FuncionarioNumero)
            {
                return BadRequest();
            }

            Context.Entry(cargo).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cargos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cargos>> PostCargo(Cargos cargo)
        {
            Context.Cargos.Add(cargo);
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CargoExists(cargo.FuncionarioNumero))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCargo", new { id = cargo.FuncionarioNumero }, cargo);
        }

        // DELETE: api/Cargos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            var cargo = await Context.Cargos.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }

            Context.Cargos.Remove(cargo);
            await Context.SaveChangesAsync();

            return NoContent();
        }

        private bool CargoExists(int id)
        {
            return Context.Cargos.Any(e => e.FuncionarioNumero == id);
        }
    }
}
