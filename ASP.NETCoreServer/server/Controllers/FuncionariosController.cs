using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;
namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly EmsContext _context;


        public FuncionariosController(EmsContext context)
        {
            _context = context;
        }

        // GET: api/Funcionarios
        //[EnableCors("ReactAdmin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionarios>>> GetFuncionarios()
        {
            
            var res = await _context.Funcionarios.OrderByDescending(funcionario => funcionario.Cpf).ToListAsync();
            foreach(var funcionario in res)
            {
                funcionario.Salarios = await _context.Salarios.Where(x => x.FuncionarioNumero == funcionario.FuncionarioNumero).ToListAsync();
                funcionario.Cargos = await _context.Cargos.Where(x => x.FuncionarioNumero == funcionario.FuncionarioNumero).ToListAsync();
            }
            Response.Headers.Add("Content-Range", "funcionarios 0-5/10");

            return res;
        }

        // GET: api/Funcionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionarios>> GetFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(funcionario => funcionario.FuncionarioNumero == id);
            funcionario.Salarios = await _context.Salarios.Where(x => x.FuncionarioNumero == id).ToListAsync();
            funcionario.Cargos = await _context.Cargos.Where(x => x.FuncionarioNumero == id).ToListAsync();

       
            //var query = context.Funcionarios.Where(c => c.nome.Contains("")).ToList()
            //funcionario.Salarios = await _context.Salarios.Where(c => c.FuncionarioNumero == funcionario.FuncionarioNumero).ToListAsync();
            //Console.WriteLine(funcionario);
            //var query = _context.Salarios.Where( s => s.)

            if (funcionario == null)
            {
                return NotFound();
            }

            return funcionario;
        }

        // PUT: api/Funcionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionario(int id, Funcionarios funcionario)
        {
            if (id != funcionario.FuncionarioNumero)
            {
                return BadRequest();
            }

            _context.Entry(funcionario).State = EntityState.Modified;
            //_context.Funcionarios.Update(funcionario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
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

        // POST: api/Funcionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Funcionarios>> PostFuncionario(Funcionarios funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionario", new { id = funcionario.FuncionarioNumero }, funcionario);
        }

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionarios.Any(e => e.FuncionarioNumero == id);
        }
    }
}
