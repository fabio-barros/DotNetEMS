using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Filters;
using server.Models;
using server.Models.InputModels.EmployeeInputModel;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FuncionariosController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public FuncionariosController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Funcionarios
        [EnableCors("ReactAdmin")]
        [HttpGet]
        [Route("list_employees")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios()
        {

            var res = await _employeeService.GetAll();

            if (res.Count == 0)
            {
                return NoContent();
            }

            Response.Headers.Add("Content-Range", $"funcionarios 0-24/{res.Count}");

            return Ok(res);

        }

        // GET: api/Funcionarios/5
        [HttpGet("{id}", Name ="GetFuncionario")]
        [EnableCors("ReactAdmin")]
        public async Task<ActionResult<Funcionario>> GetFuncionario(int id)
        {

            var funcionario = await _employeeService.Get(id);

            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);

        }

        // POST: api/Funcionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("ReactAdmin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ModelStateValidation]
        public async Task<ActionResult<Funcionario>> PostFuncionario(Funcionario funcionario)
        {
            if (funcionario is null)
                return BadRequest(new ArgumentNullException());

            try
            {
                var entity = await _employeeService.Add(funcionario);

                return CreatedAtAction(nameof(GetFuncionario), new { id = entity.Id }, entity);

            }
            //GameAlreadyExistsException
            catch (Exception e)
            {

                return UnprocessableEntity(e.Message);
            }

        }

        // PUT: api/Funcionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [EnableCors("ReactAdmin")]
        [ModelStateValidation]
        public async Task<IActionResult> PutFuncionario(int id, EmployeeInputModel funcionario)
        {
   
            try
            {
                await _employeeService.Update(id, funcionario);
                return Ok();

            }
            //GameDoesNotExistException
            catch (Exception e)
            {
                return NotFound(e);
            }

        }  

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {

            try
            {
                await _employeeService.Delete(id);
                return Ok();
            }

            //GameDoesNotExist
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

    }
}
